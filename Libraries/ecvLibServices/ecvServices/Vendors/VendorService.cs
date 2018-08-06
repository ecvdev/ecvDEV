using System;
using System.Collections.Generic;
using System.Linq;
using ecvLib.Core.ecvDomain.Vendors;
using ecvLibDAL.ecvUnitOfWork;
using ecvLibServices.ecvBAVRules.Vendors;
using ecvLib.Core.ecvOperationStatus;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs.Vendor;
using ecvLib.Core.ecvMapper;

namespace ecvLibServices.ecvServices.Vendors
{
    public partial class VendorService : IVendorService
    {
        IUnitOfWork _unitOfWork;

        List<ecvRuleViolation> bavrIssues;
        ecvOperationStatus vendorServiceStatus;
        //ctor
        public VendorService(IUnitOfWork unitOfWork)
        {
            bavrIssues = new List<ecvRuleViolation>();
            _unitOfWork = unitOfWork;
        }

        public ecvOperationStatus DeleteVendor(int vendorId)
        {
            vendorServiceStatus = new ecvOperationStatus();

            if (vendorId < 0)
            {
                vendorServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                vendorServiceStatus.OperationMessage = "Invalid vendor id!";

                return vendorServiceStatus;
            }

            var vendor = privateGetVendorById(vendorId); //--before marking vendor as deleted check it is exist in database
            if (vendor == null)
            {
                vendorServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                vendorServiceStatus.OperationMessage = "Vendor not found while deleting!";

                return vendorServiceStatus;
            }

            //--Before marking vendor as deleted should it check Business and Validation rules?

            //--Mark Vendor as deleted
            _unitOfWork.vendorRepository.markAsDeleted(vendorId);
            

            int intCompleteState = 0;
            intCompleteState = _unitOfWork.Complete();

            if (intCompleteState > 0)
            {
                // When successfull
                vendorServiceStatus.operationStatus = OperationStatus.Success;
                vendorServiceStatus.OperationMessage = "";
            }
            else
            {
                vendorServiceStatus.operationStatus = OperationStatus.Error;
                vendorServiceStatus.OperationMessage = _unitOfWork.ecvError;
            }

            return vendorServiceStatus;
        }

        public IEnumerable<VendorDTO> GetAllVendors()
        {
            var _vendorsList =  _unitOfWork.vendorRepository.GetAll().ToList();            

            IList<VendorDTO> _vendorDTOs;

            if(_vendorsList == null)
            {
                _vendorDTOs = null;
            }
            else
            {
                var vendorMapper = new ecvMapper<Vendor, VendorDTO>();
                _vendorDTOs = vendorMapper.CreateMappedObject(_vendorsList);
            }

            return _vendorDTOs;
        }

        public IEnumerable<VendorListDTO> GetVendorsList()
        {
            var _vendorsList = _unitOfWork.vendorRepository.GetAll().ToList();

            IList<VendorListDTO> _vendorListDTOs;

            if (_vendorsList == null)
            {
                _vendorListDTOs = null;
            }
            else
            {
                var vendorListMapper = new ecvMapper<Vendor, VendorListDTO>();
                //_vendorDTOs = new List<VendorDTO>(); 
                _vendorListDTOs = vendorListMapper.CreateMappedObject(_vendorsList);
                //System.IDisposable d = vendorListMapper as System.IDisposable;
                //if (d != null) d.Dispose();
            }

            return _vendorListDTOs;

        }

        public VendorDTO GetVendorById(int vendorId)
        {
            var _vendor = _unitOfWork.vendorRepository.Get(vendorId);

            VendorDTO _vendorDTO; 

            if (_vendor == null)
            {
                _vendorDTO = null;
            }
            else
            {
                _vendorDTO = new VendorDTO();
                var vendorMapper = new ecvMapper<Vendor, VendorDTO>();

                _vendorDTO = vendorMapper.CreateMappedObject(_vendor);
            }

            return _vendorDTO;
        }

        private Vendor privateGetVendorById(int vendorId)
        {
            var _vendor = _unitOfWork.vendorRepository.Get(vendorId);

            return _vendor;
        }

        public void CreateVendor(Vendor vendor)
        {           
            _unitOfWork.vendorRepository.Add(vendor);
        }

        public void UpdateVendor(Vendor vendor)
        {
            _unitOfWork.vendorRepository.Update(vendor);
        }

        public ecvOperationStatus SaveVendor(VendorDTO vendorDto)
        {
            Vendor vendor = new Vendor();
            vendorServiceStatus = new ecvOperationStatus();

            if (vendorDto.Id > 0) //Record to update
            {
                vendor = _unitOfWork.vendorRepository.Get(vendorDto.Id); // privateGetVendorById(vendorDto.Id); //Get vendor entity from database
                if (vendor == null)
                {                   
                    vendorServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                    vendorServiceStatus.OperationMessage = "Vendor not found while updating!";

                    return vendorServiceStatus;
                }
                vendorDto.UpdatedOnUtc = DateTime.Now;
            }
            else // Record to add new
            {
                vendorDto.CreatedOnUtc = DateTime.Now;
                vendorDto.UpdatedOnUtc = DateTime.Now;

                _unitOfWork.vendorRepository.Add(vendor); //Create new vendor
            }

            //--Check business and validation rules
            bavrIssues = new List<ecvRuleViolation>();
            bavrIssues = processBAVRules(vendorDto);

            if (bavrIssues.Count() > 0)
            {
                vendorServiceStatus.operationStatus = OperationStatus.Error;
                vendorServiceStatus.OperationMessage = "Business and validation rules violation!";
                vendorServiceStatus.ecvRuleViolation = bavrIssues;

                return vendorServiceStatus;
            }

            //--Once business and validatin rules are passed copy values from DTO to VendorEntity.
            //--Prepare Vendor Model
            var vendorMapper = new ecvMapper<VendorDTO, Vendor>();            
            vendorMapper.MapObject(vendorDto, vendor); //--Directly mapping object

            int intCompleteState = 0;
            intCompleteState = _unitOfWork.Complete();

            if (intCompleteState > 0) 
            {
                // When successfully save record
                vendorServiceStatus.operationStatus = OperationStatus.Success;
                vendorServiceStatus.OperationMessage = "";
            }
            else
            {
                vendorServiceStatus.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_unitOfWork.ecvError))
                {
                    vendorServiceStatus.OperationMessage = _unitOfWork.ecvError;
                }
                else
                {
                    vendorServiceStatus.OperationMessage = "Error, unexpected error occured cannot save vendor record!";
                }                    
            }

            return vendorServiceStatus;

        }// End of -- public void SaveVendor(VendorDTO vendorDto)

        public int Complete()
        {
            return _unitOfWork.Complete();
        }

        public List<ecvRuleViolation> processBAVRules(VendorDTO vendorDTO)
        {

            VendorBAVRules _vendorBAVRules = new VendorBAVRules(vendorDTO);
            return _vendorBAVRules.ecvGetRuleViolations();            
        }


    }// End of -- public partial class VendorService
}
