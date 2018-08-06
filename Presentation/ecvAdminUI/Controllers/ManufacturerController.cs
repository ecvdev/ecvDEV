using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using ecvLib.Core;
using System;
using System.Web.Mvc;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;

namespace ecvAdminUI.Controllers
{
    public class ManufacturerController : Controller
    {
        IManufacturerModelFactory _manufacturerModelFactory;

        public ManufacturerController(IManufacturerModelFactory manufacturerModelFactory)
        {
            _manufacturerModelFactory = manufacturerModelFactory;
        }

        // GET: Manufacturer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
        public ActionResult ListX(string manufacturerName = "", int storeId = 0, int pageIndex = 1, int pageSize = 15, bool showHidden = false)
        {
            var query = _manufacturerModelFactory.GetAllManufacturerList(false);

            PagedList<ManufacturerListModel> model = new PagedList<ManufacturerListModel>(query, pageIndex, pageSize);
            return View(model);

        }

        public ActionResult Details(int manufacturerId)
        {
            var manufacturerViewModel = _manufacturerModelFactory.getManufacturerVM(manufacturerId);

            if (manufacturerViewModel == null)
            {
                return HttpNotFound("Manufacturer's details not found!");
            }
            else if (manufacturerViewModel.manufacturerModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Manufacturer \"{0}\" is marked as deleted!.", manufacturerViewModel.manufacturerModel.Name);
                return RedirectToAction("List");
            }

            manufacturerViewModel.operationType = OperationType.Detail;

            return View("ManufacturerForm", manufacturerViewModel);
        }

        public ActionResult New()
        {
            var manufacturerViewModel = new ManufacturerViewModel
            {
                manufacturerModel = new ManufacturerModel()
            };

            manufacturerViewModel.operationType = OperationType.New;

            manufacturerViewModel.manufacturerModel.CreatedOnUtc = DateTime.Now;
            manufacturerViewModel.manufacturerModel.UpdatedOnUtc = DateTime.Now;

            return View("ManufacturerForm", manufacturerViewModel);
        }

        public ActionResult Edit(int manufacturerId)
        {
            var manufacturerViewModel = _manufacturerModelFactory.getManufacturerVM(manufacturerId);

            if (manufacturerViewModel == null)
            {
                return HttpNotFound("Manufacturer not found to edit!");
            }
            else if (manufacturerViewModel.manufacturerModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Manufacturer \"{0}\" is marked as deleted!.", manufacturerViewModel.manufacturerModel.Name);
                return RedirectToAction("List");
            }

            manufacturerViewModel.operationType = OperationType.Edit;
            return View("ManufacturerForm", manufacturerViewModel);
        }

        public ActionResult Delete(int manufacturerId)
        {
            var manufacturerViewModel = _manufacturerModelFactory.getManufacturerVM(manufacturerId);

            if (manufacturerViewModel == null)
            {
                return HttpNotFound("Manufacturer not found to delete!");
            }
            else if (manufacturerViewModel.manufacturerModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Manufacturer \"{0}\" is already marked as deleted!.", manufacturerViewModel.manufacturerModel.Name);
                return RedirectToAction("List");
            }

            manufacturerViewModel.operationType = OperationType.Delete;
            return View("ManufacturerForm", manufacturerViewModel);

        }

        [HttpPost]
        public ActionResult Details(ManufacturerViewModel manufacturerViewModel)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View("ManufacturerForm", manufacturerViewModel);
            }
        }

        [HttpPost]
        public ActionResult SaveNew(ManufacturerViewModel manufacturerViewModel)
        {
            manufacturerViewModel.operationType = OperationType.New;
            if (ModelState.IsValid)
            {
                _manufacturerModelFactory.saveManufacturer(manufacturerViewModel);
                if (manufacturerViewModel.operationStatus == OperationStatus.Error)
                {
                    foreach (var _propertyError in manufacturerViewModel.ecvRuleViolation)
                    {
                        //--Add error on summary level
                        ModelState.AddModelError(string.Empty, _propertyError._errorMessage);
                        //--Add error property level
                        ModelState.AddModelError("manufacturerModel." + _propertyError._propertyName, _propertyError._errorMessage);
                    }
                    return View("ManufacturerForm", manufacturerViewModel);
                }
                TempData["message"] = string.Format("New manufacturer \"{0}\" has been created.", manufacturerViewModel.manufacturerModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                return View("ManufacturerForm", manufacturerViewModel);
            }
        }

        [HttpPost]
        public ActionResult SaveEdit(ManufacturerViewModel manufacturerViewModel)
        {
            manufacturerViewModel.operationType = OperationType.Edit;
            if (ModelState.IsValid)
            {
                _manufacturerModelFactory.saveManufacturer(manufacturerViewModel);
                if (manufacturerViewModel.operationStatus == OperationStatus.Error)
                {
                    foreach(var _propertyError in manufacturerViewModel.ecvRuleViolation)
                    {
                        //--Add error on summary level
                        ModelState.AddModelError(string.Empty, _propertyError._errorMessage);
                        //--Add error property level
                        ModelState.AddModelError("manufacturerModel." + _propertyError._propertyName, _propertyError._errorMessage); 
                    }
                    return View("ManufacturerForm", manufacturerViewModel);
                }
                TempData["message"] = string.Format("Manufacturer \"{0}\" has been updated.", manufacturerViewModel.manufacturerModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                return View("ManufacturerForm", manufacturerViewModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(ManufacturerViewModel manufacturerViewModel)
        {
            manufacturerViewModel.operationType = OperationType.Delete;
            if (ModelState.IsValid)
            {
                if (manufacturerViewModel == null)
                {
                    return HttpNotFound("Manufacturer not found to delete!");
                }

                string _manufacturerName = manufacturerViewModel.manufacturerModel.Name;

                _manufacturerModelFactory.deleteManufacturer(manufacturerViewModel);

                ///---if error deleting product
                if (manufacturerViewModel.operationStatus == OperationStatus.Error)
                {
                    //return HttpNotFound(productViewModel.OperationMessage);
                    TempData["errorMessage"] = string.Format("Error deleting manufacturer \"{0}\"!, {1}", manufacturerViewModel.manufacturerModel.Name, manufacturerViewModel.OperationMessage);
                    return View("ManufacturerForm", manufacturerViewModel);
                }
                TempData["message"] = string.Format("Manufacturer \"{0}\" has been deleted!", _manufacturerName);
                return RedirectToAction("List");

            }
            else
            {
                return View("ManufacturerForm", manufacturerViewModel);
            }

        }

    }// End of -- public class ManufacturerController
}