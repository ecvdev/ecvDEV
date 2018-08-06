using System;
using System.Collections.Generic;
using System.Linq;
using ecvAdminUI.Models.Vendors;
using ecvAdminUI.ViewModels.Vendors;
using ecvLibDAL.ecvUnitOfWork;
using ecvLib.Core.ecvDomain.Vendors;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;
using ecvLibServices.ecvServices.Vendors;
using ecvLibDTOs.ecvDTOs.Vendor;
using ecvLib.Core.ecvMapper;

namespace ecvAdminUI.Factories.Vendors
{
    public partial class VendorModelFactory : IVendorModelFactory
    {

        //IUnitOfWork _unitOfWork;
        IVendorService _vendorService;

        public VendorModelFactory(IVendorService vendorService) //IUnitOfWork unitOfWork,
        {
            //_unitOfWork = unitOfWork;
            _vendorService = vendorService;
        }

        public VendorViewModel deleteVendor(VendorViewModel vendorViewModel)
        {
            
            var _vendorServiceStatus = _vendorService.DeleteVendor(vendorViewModel.vendorModel.Id);

            if (_vendorServiceStatus.operationStatus == OperationStatus.Error)
            {
                vendorViewModel.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_vendorServiceStatus.OperationMessage))
                {
                    vendorViewModel.OperationMessage = _vendorServiceStatus.OperationMessage;
                }

                vendorViewModel.ecvRuleViolation = _vendorServiceStatus.ecvRuleViolation;
            }
            else
            {
                vendorViewModel.operationStatus = OperationStatus.Success;
                if (!string.IsNullOrEmpty(_vendorServiceStatus.OperationMessage))
                {
                    vendorViewModel.OperationMessage = _vendorServiceStatus.OperationMessage;
                }
                vendorViewModel.ecvRuleViolation = _vendorServiceStatus.ecvRuleViolation;
            }

            return vendorViewModel;
        }

        public List<VendorListModel> GetVendorsList(bool FirstElementEmpty)
        {
            
            var model = new List<VendorListModel>();
            var _vendorsList = _vendorService.GetVendorsList().Where(v => v.Deleted.Equals(false)).ToList();

            var vendorListMapper = new ecvMapper<VendorListDTO,VendorListModel>();

            model = vendorListMapper.CreateMappedObject(_vendorsList);

            model = model.OrderBy(m => m.Name).ToList();

            if (FirstElementEmpty.Equals(true))
            {
                VendorListModel singleVendorListModel = null;
                singleVendorListModel = new VendorListModel();
                singleVendorListModel.Id = 0;
                singleVendorListModel.Name = "[None]";

                model.Insert(0, singleVendorListModel);
            }

            return model;
        }

        public VendorViewModel getVendorVM(int vendorId)
        {
            //--Get Vendor 
            VendorDTO vendorDTO ;
            vendorDTO = _vendorService.GetVendorById(vendorId); //

            var vendorViewModel = new VendorViewModel
            {
                vendorModel = new VendorModel()
            };

            if (vendorDTO == null)
            {
                vendorViewModel = null;
                return vendorViewModel;
            }

            var vendorMapper = new ecvMapper<VendorDTO, VendorModel>();

            vendorViewModel.vendorModel = vendorMapper.CreateMappedObject(vendorDTO);

            return vendorViewModel;
        }

        public VendorViewModel saveVendor(VendorViewModel vendorViewModel)
        {

            VendorDTO vendorDTO = new VendorDTO();

            var vendorMapper = new ecvMapper<VendorModel, VendorDTO>();

            vendorDTO = vendorMapper.CreateMappedObject(vendorViewModel.vendorModel);

            var _vendorServiceStatus = _vendorService.SaveVendor(vendorDTO);

            if (_vendorServiceStatus.operationStatus == OperationStatus.Error)
            {
                vendorViewModel.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_vendorServiceStatus.OperationMessage))
                {
                    vendorViewModel.OperationMessage = _vendorServiceStatus.OperationMessage;
                }
                
                vendorViewModel.ecvRuleViolation = _vendorServiceStatus.ecvRuleViolation;               
            }
            else
            {
                vendorViewModel.operationStatus = OperationStatus.Success;
                if (!string.IsNullOrEmpty(_vendorServiceStatus.OperationMessage))
                {
                    vendorViewModel.OperationMessage = _vendorServiceStatus.OperationMessage;
                }
                vendorViewModel.ecvRuleViolation = _vendorServiceStatus.ecvRuleViolation;
            }

            return vendorViewModel;
        }
    }
}


////public VendorViewModel saveVendor(VendorViewModel vendorViewModel)
////{

////    Vendor vendor = new Vendor();

////    if (vendorViewModel.vendorModel.Id > 0) //Record to update
////    {
////        vendor = _vendorService.GetVendorById(vendorViewModel.vendorModel.Id);
////        if (vendor == null)
////        {
////            vendorViewModel.operationStatus = OperationStatus.Error;
////            vendorViewModel.OperationMessage = "Vendor not found while updating!";
////            return vendorViewModel;
////        }
////        vendorViewModel.vendorModel.UpdatedOnUtc = DateTime.Now;
////    }
////    else // Record to add new
////    {
////        vendorViewModel.vendorModel.CreatedOnUtc = DateTime.Now;
////        vendorViewModel.vendorModel.UpdatedOnUtc = DateTime.Now;
////        _vendorService.CreateVendor(vendor);
////    }

////    foreach (var propDest in vendor.GetType().GetProperties())
////    {
////        //Find property in source based on destination name
////        var propSrc = vendorViewModel.vendorModel.GetType().GetProperty(propDest.Name);

////        if (propSrc != null)
////        {
////            //Get value from source and assign it to destination
////            propDest.SetValue(vendor, propSrc.GetValue(vendorViewModel.vendorModel));
////        }
////    }

////    bool BRresult = false;
////    BRresult = vendor.processBusinessRules();
////    if (BRresult == false)
////    {
////        vendorViewModel.operationStatus = OperationStatus.Error;
////        vendorViewModel.OperationMessage = vendor.ecvBRMessage;
////        return vendorViewModel;
////    }

////    int intCompleteState = 0;
////    intCompleteState = _unitOfWork.Complete();

////    if (intCompleteState > 0) // When successfully save record
////    {
////        vendorViewModel.operationStatus = OperationStatus.Success;
////        vendorViewModel.OperationMessage = "";
////    }
////    else
////    {
////        vendorViewModel.operationStatus = OperationStatus.Error;
////        vendorViewModel.OperationMessage = _unitOfWork.ecvError;
////    }

////    return vendorViewModel;
////}


//////    //--Prepare Vendor in --getVendorVM----
//////foreach (var propDest in vendorViewModel.vendorModel.GetType().GetProperties())
//////{
//////    //Find property in source based on destination name
//////    var propSrc = vendor.GetType().GetProperty(propDest.Name);
//////    if (propSrc != null)
//////    {
//////        //Get value from source and assign it to destination
//////        propDest.SetValue(vendorViewModel.vendorModel, propSrc.GetValue(vendor));
//////    }
//////} 