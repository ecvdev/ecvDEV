using ecvLib.Core.ecvOperationStatus;
using ecvLibDAL.ecvUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDTOs.ecvDTOs.Catalog;
using ecvLib.Core.ecvMapper;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;

namespace ecvLibServices.ecvServices.Catalog
{
    public partial class ManufacturerService : IManufacturerService
    {
        IUnitOfWork _unitOfWork;

        List<ecvRuleViolation> bavrIssues;
        ecvOperationStatus manufacturerServiceStatus;
        //ctor
        public ManufacturerService(IUnitOfWork unitOfWork)
        {
            bavrIssues = new List<ecvRuleViolation>();
            _unitOfWork = unitOfWork;

        }

        public ManufacturerDTO GetManufacturerById(int manufacturerId)
        {
            var _manufacturer = _unitOfWork.manufacturerRepository.Get(manufacturerId);

            ManufacturerDTO _manufacturerDTO;

            if (_manufacturer == null)
            {
                _manufacturerDTO = null;
            }
            else
            {
                _manufacturerDTO = new ManufacturerDTO();
                var manufacturerMapper = new ecvMapper<Manufacturer, ManufacturerDTO>();

                _manufacturerDTO = manufacturerMapper.CreateMappedObject(_manufacturer);
            }

            return _manufacturerDTO;
        }

        public ecvOperationStatus DeleteManufacturer(int manufacturerId)
        {
            //throw new NotImplementedException();
            manufacturerServiceStatus = new ecvOperationStatus();

            if (manufacturerId < 0)
            {
                manufacturerServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                manufacturerServiceStatus.OperationMessage = "Invalid manufacturer id!";

                return manufacturerServiceStatus;
            }

            var manufacturer = privateGetManufacturerById(manufacturerId); //--before marking manufacturer as deleted check it is exist in database
            if (manufacturer == null)
            {
                manufacturerServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                manufacturerServiceStatus.OperationMessage = "Manufacturer not found while deleting!";

                return manufacturerServiceStatus;
            }

            //--Before marking Manufacturer as deleted should it check Business and Validation rules?

            //--Mark Manufacturer as deleted
            _unitOfWork.manufacturerRepository.markAsDeleted(manufacturerId);

            int intCompleteState = 0;
            intCompleteState = _unitOfWork.Complete();

            if (intCompleteState > 0)
            {
                // When successfull
                manufacturerServiceStatus.operationStatus = OperationStatus.Success;
                manufacturerServiceStatus.OperationMessage = "";
            }
            else
            {
                manufacturerServiceStatus.operationStatus = OperationStatus.Error;
                manufacturerServiceStatus.OperationMessage = _unitOfWork.ecvError;
            }

            return manufacturerServiceStatus;
        }

        private Manufacturer privateGetManufacturerById(int manufacturerId)
        {
            var _manufacturer = _unitOfWork.manufacturerRepository.Get(manufacturerId);

            return _manufacturer;
        }

        public IEnumerable<ManufacturerDTO> GetAllManufacturers()
        {
            //throw new NotImplementedException();
            var _manufacturerList = _unitOfWork.manufacturerRepository.GetAll().ToList();

            IList<ManufacturerDTO> _manufacturerDTOs;

            if (_manufacturerList == null)
            {
                _manufacturerDTOs = null;
            }
            else
            {
                var manufacturerMapper = new ecvMapper<Manufacturer, ManufacturerDTO>();
                _manufacturerDTOs = manufacturerMapper.CreateMappedObject(_manufacturerList);
            }

            return _manufacturerDTOs;
        }

        public IEnumerable<ManufacturerListDTO> GetManufacturersList()
        {
            //throw new NotImplementedException();
            var _manufacturersList = _unitOfWork.manufacturerRepository.GetAll().ToList();

            IList<ManufacturerListDTO> _manufacturersListDTOs;

            if (_manufacturersList == null)
            {
                _manufacturersListDTOs = null;
            }
            else
            {
                var manufacturerListMapper = new ecvMapper<Manufacturer, ManufacturerListDTO>();

                _manufacturersListDTOs = manufacturerListMapper.CreateMappedObject(_manufacturersList);                
            }

            return _manufacturersListDTOs;
        }

        public void CreateManufacturer(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public ecvOperationStatus SaveManufacturer(ManufacturerDTO manufacturerDto)
        {
            throw new NotImplementedException();
        }

        public List<ecvRuleViolation> processBAVRules(ManufacturerDTO manufacturerDto)
        {
            throw new NotImplementedException();
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }

    }// End of -- public partial class ManufacturerService
}
