using System;
using System.Collections.Generic;
using System.Linq;
using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using ecvLibDAL.ecvUnitOfWork;
using ecvLib.Core.ecvDomain.Catalog;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;
using ecvLibServices.ecvServices.Catalog;
using ecvLibDTOs.ecvDTOs.Catalog;
using ecvLib.Core.ecvMapper;

namespace ecvAdminUI.Factories.Catalog
{
    public partial class ManufacturerModelFactory : IManufacturerModelFactory
    {
        //IUnitOfWork _unitOfWork;

        ////public ManufacturerModelFactory(IUnitOfWork unitOfWork)
        ////{
        ////    _unitOfWork = unitOfWork;
        ////}

        MnfService _mnfService;

        public ManufacturerModelFactory(MnfService mnfService, IUnitOfWork unitOfWork)
        {
            _mnfService = mnfService;
        }

        public List<ManufacturerListModel> GetManufacturerList(bool FirstElementEmpty)
        {

            var model = new List<ManufacturerListModel>(); 
             var _manufacturerList = _mnfService.GetList().Where(v => v.Deleted.Equals(false)).ToList();

            var manufacturerListMapper = new ecvMapper<ManufacturerListDTO, ManufacturerListModel>();

            model = manufacturerListMapper.CreateMappedObject(_manufacturerList);

            model = model.OrderBy(m => m.Name).ToList();

            if (FirstElementEmpty.Equals(true))
            {
                ManufacturerListModel singlemanufacturerListModel = null;
                singlemanufacturerListModel = new ManufacturerListModel();
                singlemanufacturerListModel.Id = 0;
                singlemanufacturerListModel.Name = "[None]";

                model.Insert(0, singlemanufacturerListModel);
            }
            
            return model;
        }

        public ManufacturerViewModel getManufacturerVM(int manufacturerId)
        {
            //Get Manufacturer
            var manufacturer = _mnfService.GetEntityById(manufacturerId); //_unitOfWork.manufacturerRepository.Get(manufacturerId);

            var manufacturerViewModel = new ManufacturerViewModel
            {
                manufacturerModel = new ManufacturerModel()
            };

            if (manufacturer == null)
            {
                manufacturerViewModel = null;
                return manufacturerViewModel;
            }

            //Prepare Manufacturere Model
            foreach (var propDest in manufacturerViewModel.manufacturerModel.GetType().GetProperties())
            {
                //Find property in source based on destination name
                var propSrc = manufacturer.GetType().GetProperty(propDest.Name);
                if (propSrc != null)
                {
                    //Get value from source and assign it to destination
                    propDest.SetValue(manufacturerViewModel.manufacturerModel, propSrc.GetValue(manufacturer));
                }
            }

            return manufacturerViewModel;
        }

        public ManufacturerViewModel saveManufacturer(ManufacturerViewModel manufacturerViewModel)
        {
            //throw new NotImplementedException();

            ManufacturerDTO manufacturerDTO = new ManufacturerDTO();

            var manufacturerMapper = new ecvMapper<ManufacturerModel, ManufacturerDTO>();

            manufacturerDTO = manufacturerMapper.CreateMappedObject(manufacturerViewModel.manufacturerModel);

            var _manufacturerServiceStatus = _mnfService.SaveEntity(manufacturerDTO);

            if (_manufacturerServiceStatus.operationStatus == OperationStatus.Error)
            {
                manufacturerViewModel.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_manufacturerServiceStatus.OperationMessage))
                {
                    manufacturerViewModel.OperationMessage = _manufacturerServiceStatus.OperationMessage;
                }

                manufacturerViewModel.ecvRuleViolation = _manufacturerServiceStatus.ecvRuleViolation;
            }
            else
            {
                manufacturerViewModel.operationStatus = OperationStatus.Success;
                if (!string.IsNullOrEmpty(_manufacturerServiceStatus.OperationMessage))
                {
                    manufacturerViewModel.OperationMessage = _manufacturerServiceStatus.OperationMessage;
                }
                manufacturerViewModel.ecvRuleViolation = _manufacturerServiceStatus.ecvRuleViolation;
            }

            return manufacturerViewModel;

        }

        ////public List<ManufacturerListModel> GetAllManufacturerList(bool FirstElementEmpty)
        ////{
        ////    IList<Manufacturer> _allManufacturers = null;
        ////    var model = new List<ManufacturerListModel>();

        ////    _allManufacturers = _unitOfWork.manufacturerRepository.GetAll().Where(m => m.Deleted.Equals(false)).ToList();

        ////    ManufacturerListModel singleManufacturerListModel = null;

        ////    foreach (var tmpManufacturer in _allManufacturers)
        ////    {
        ////        singleManufacturerListModel = new ManufacturerListModel();

        ////        //below loop copy manufacturer value from retrieved list
        ////        foreach(var propDest in singleManufacturerListModel.GetType().GetProperties())
        ////        {
        ////            //Find property in source based on destination name
        ////            var propSrc = tmpManufacturer.GetType().GetProperty(propDest.Name);
        ////            if(propSrc != null)
        ////            {
        ////                //Get value from source and assign it to destination
        ////                propDest.SetValue(singleManufacturerListModel, propSrc.GetValue(tmpManufacturer));
        ////            }
        ////        }
        ////        model.Add(singleManufacturerListModel);
        ////    }

        ////    model = model.OrderBy(m => m.Name).ToList();

        ////    if (FirstElementEmpty.Equals(true))
        ////    {
        ////        singleManufacturerListModel = new ManufacturerListModel();
        ////        singleManufacturerListModel.Id = 0;
        ////        singleManufacturerListModel.Name = "[None]";

        ////        model.Insert(0, singleManufacturerListModel);
        ////    }

        ////    return model;
        ////}

        ////public ManufacturerViewModel getManufacturerVM(int manufacturerId)
        ////{
        ////    //Get Manufacturer
        ////    var manufacturer = _unitOfWork.manufacturerRepository.Get(manufacturerId);

        ////    var manufacturerViewModel = new ManufacturerViewModel
        ////    {
        ////        manufacturerModel = new ManufacturerModel()
        ////    };

        ////    if (manufacturer == null)
        ////    {
        ////        manufacturerViewModel = null;
        ////        return manufacturerViewModel;
        ////    }

        ////    //Prepare Manufacturere Model
        ////    foreach (var propDest in manufacturerViewModel.manufacturerModel.GetType().GetProperties())
        ////    {
        ////        //Find property in source based on destination name
        ////        var propSrc = manufacturer.GetType().GetProperty(propDest.Name);
        ////        if (propSrc != null)
        ////        {
        ////            //Get value from source and assign it to destination
        ////            propDest.SetValue(manufacturerViewModel.manufacturerModel, propSrc.GetValue(manufacturer));
        ////        }
        ////    }

        ////    return manufacturerViewModel;            
        ////}

        ////public ManufacturerViewModel deleteManufacturer(ManufacturerViewModel manufacturerViewModel)
        ////{

        ////    Manufacturer manufacturer = new Manufacturer();

        ////    if (manufacturerViewModel.manufacturerModel.Id > 0) //Record to delete
        ////    {
        ////        manufacturer = _unitOfWork.manufacturerRepository.Get(manufacturerViewModel.manufacturerModel.Id);
        ////        if (manufacturer == null)
        ////        {
        ////            manufacturerViewModel.operationStatus = OperationStatus.Error;
        ////            manufacturerViewModel.OperationMessage = "Manufacturer not found while deleting!";
        ////            return manufacturerViewModel;
        ////        }

        ////    }
        ////    manufacturerViewModel.manufacturerModel.UpdatedOnUtc = DateTime.Now;
        ////    _unitOfWork.manufacturerRepository.RemoveManufacturer(manufacturer.Id);
        ////    _unitOfWork.Complete();

        ////    manufacturerViewModel.operationStatus = OperationStatus.Success;
        ////    manufacturerViewModel.OperationMessage = "";

        ////    return manufacturerViewModel;
        ////}

        ////public ManufacturerViewModel saveManufacturer(ManufacturerViewModel manufacturerViewModel)
        ////{
        ////    //throw new NotImplementedException();
        ////    Manufacturer manufacturer = new Manufacturer();

        ////    if (manufacturerViewModel.manufacturerModel.Id > 0) //Record to update
        ////    {
        ////        manufacturer = _unitOfWork.manufacturerRepository.Get(manufacturerViewModel.manufacturerModel.Id);
        ////        if (manufacturer == null)
        ////        {
        ////            manufacturerViewModel.operationStatus = OperationStatus.Error;
        ////            manufacturerViewModel.OperationMessage = "Manufacturer not found while updating!";
        ////            return manufacturerViewModel;
        ////        }
        ////        manufacturerViewModel.manufacturerModel.UpdatedOnUtc = DateTime.Now;
        ////    }
        ////    else // Record to add new
        ////    {
        ////        manufacturerViewModel.manufacturerModel.CreatedOnUtc = DateTime.Now;
        ////        manufacturerViewModel.manufacturerModel.UpdatedOnUtc = DateTime.Now;
        ////        _unitOfWork.manufacturerRepository.Add(manufacturer);
        ////    }

        ////    foreach (var propDest in manufacturer.GetType().GetProperties())
        ////    {
        ////        //Find property in source based on destination name
        ////        var propSrc = manufacturerViewModel.manufacturerModel.GetType().GetProperty(propDest.Name);

        ////        if (propSrc != null)
        ////        {
        ////            //Get value from source and assign it to destination
        ////            propDest.SetValue(manufacturer, propSrc.GetValue(manufacturerViewModel.manufacturerModel));
        ////        }
        ////    }

        ////    //bool BRresult = false;
        ////    //BRresult = manufacturer.processBusinessRules();
        ////    //if (BRresult == false)
        ////    //{
        ////    //    manufacturerViewModel.operationStatus = OperationStatus.Error;
        ////    //    manufacturerViewModel.OperationMessage = manufacturer.ecvBRMessage;
        ////    //    return manufacturerViewModel;
        ////    //}

        ////    var objValidataionList = manufacturer.ecvGetRuleViolations();

        ////    if (objValidataionList.Count() > 0)
        ////    {
        ////        manufacturerViewModel.operationStatus = OperationStatus.Error;
        ////        manufacturerViewModel.ecvRuleViolation = objValidataionList;                
        ////        return manufacturerViewModel;
        ////    }

        ////    int intCompeteState = 0;
        ////    intCompeteState = _unitOfWork.Complete();

        ////    if (intCompeteState > 0) // When successfully save record
        ////    {
        ////        manufacturerViewModel.operationStatus = OperationStatus.Success;
        ////        manufacturerViewModel.OperationMessage = "";
        ////    }
        ////    else
        ////    {
        ////        manufacturerViewModel.operationStatus = OperationStatus.Error;
        ////        manufacturerViewModel.OperationMessage = _unitOfWork.ecvError;
        ////    }

        ////    return manufacturerViewModel;

        ////}
    }// End of -- public partial class ManufacturerModelFactory
}