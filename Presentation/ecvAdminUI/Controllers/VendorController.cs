using ecvAdminUI.Factories.Vendors;
using ecvAdminUI.Models.Vendors;
using ecvAdminUI.ViewModels.Vendors;
using ecvLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;

namespace ecvAdminUI.Controllers
{
    public class VendorController : Controller
    {

        IVendorModelFactory _vendorModelFactory;

        public VendorController(IVendorModelFactory vendorModelFactory)
        {
            _vendorModelFactory = vendorModelFactory;
        }

        // GET: Vendor

        public ActionResult List()
        {
            return View();
        }
        public ActionResult ListX(string vendorName = "", int storeId = 0, int pageIndex = 1, int pageSize = 15, bool showHidden = false)
        {
            var query = _vendorModelFactory.GetVendorsList(false);

            PagedList<VendorListModel> model = new PagedList<VendorListModel>(query, pageIndex, pageSize);
            
            return View(model);
        }

        public ActionResult Details(int vendorId)
        {
            var vendorViewModel = _vendorModelFactory.getVendorVM(vendorId);

            if (vendorViewModel == null)
            {
                return HttpNotFound("Vendor's details not found!");
            }
            else if (vendorViewModel.vendorModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Vendor \"{0}\" is marked as deleted!", vendorViewModel.vendorModel.Name);
                return RedirectToAction("List");
            }

            vendorViewModel.operationType = OperationType.Detail;

            return View("VendorForm", vendorViewModel);
        }

        public ActionResult New()
        {
            var vendorViewModel = new VendorViewModel
            {
                vendorModel = new VendorModel()
            };

            vendorViewModel.operationType = OperationType.New;

            vendorViewModel.vendorModel.CreatedOnUtc = DateTime.Now;
            vendorViewModel.vendorModel.UpdatedOnUtc = DateTime.Now;

            return View("VendorForm", vendorViewModel);
        }

        public ActionResult Edit(int vendorId)
        {
            var vendorViewModel = _vendorModelFactory.getVendorVM(vendorId);

            if (vendorViewModel == null)
            {
                return HttpNotFound("Vendor not found to edit!");
            }
            else if (vendorViewModel.vendorModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Vendor \"{0}\" is marked as deleted!", vendorViewModel.vendorModel.Name);
                return RedirectToAction("List");
            }

            vendorViewModel.operationType = OperationType.Edit;
            return View("VendorForm", vendorViewModel);
        }

        public ActionResult Delete(int vendorId)
        {

            var vendorViewModel = _vendorModelFactory.getVendorVM(vendorId);

            if (vendorViewModel == null)
            {
                return HttpNotFound("Vendor not found to delete!");
            }
            else if (vendorViewModel.vendorModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Vendor \"{0}\" is already marked as deleted!", vendorViewModel.vendorModel.Name);
                return RedirectToAction("List");
            }

            vendorViewModel.operationType = OperationType.Delete;
            return View("VendorForm", vendorViewModel);

        }

        [HttpPost]
        public ActionResult Details(VendorViewModel vendorViewModel)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View("VendorForm", vendorViewModel);
            }
        }

        [HttpPost]
        public ActionResult SaveNew(VendorViewModel vendorViewModel)
        {
            vendorViewModel.operationType = OperationType.New;
            if (ModelState.IsValid)
            {
                _vendorModelFactory.saveVendor(vendorViewModel);
                if (vendorViewModel.operationStatus == OperationStatus.Error)
                {
                    if (vendorViewModel.ecvRuleViolation != null && vendorViewModel.ecvRuleViolation.Count() > 0) //if business and validation rules violations
                    {
                        foreach (var _propertyError in vendorViewModel.ecvRuleViolation)
                        {
                            //--Add error property level
                            ModelState.AddModelError("vendorModel." + _propertyError._propertyName, _propertyError._errorMessage);
                        }
                    }
                    else // else only single error
                    {
                        ModelState.AddModelError("", vendorViewModel.OperationMessage);
                    }

                    return View("VendorForm", vendorViewModel);
                }
                TempData["message"] = string.Format("New vendor \"{0}\" has been created.", vendorViewModel.vendorModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                return View("VendorForm", vendorViewModel);
            }
        }

        [HttpPost]
        public ActionResult SaveEdit(VendorViewModel vendorViewModel)
        {
            vendorViewModel.operationType = OperationType.Edit;
            if (ModelState.IsValid)
            {
                _vendorModelFactory.saveVendor(vendorViewModel);
                if (vendorViewModel.operationStatus == OperationStatus.Error)
                {
                    if (vendorViewModel.ecvRuleViolation != null && vendorViewModel.ecvRuleViolation.Count() > 0) //if business and validation rules violations
                    {
                        foreach (var _propertyError in vendorViewModel.ecvRuleViolation)
                        {
                            //--Add error property level
                            ModelState.AddModelError("vendorModel." + _propertyError._propertyName, _propertyError._errorMessage);
                        }
                    }
                    else // else only single error
                    {
                        ModelState.AddModelError("", vendorViewModel.OperationMessage);
                    }
                    
                    return View("VendorForm", vendorViewModel);
                }
                TempData["message"] = string.Format("Vendor \"{0}\" has been updated.", vendorViewModel.vendorModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                return View("VendorForm", vendorViewModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(VendorViewModel vendorViewModel)
        {
            vendorViewModel.operationType = OperationType.Delete;
            if (ModelState.IsValid)
            {
                if (vendorViewModel == null)
                {
                    return HttpNotFound("Vendor not found to delete!");
                }

                string _vendorName = vendorViewModel.vendorModel.Name;

                _vendorModelFactory.deleteVendor(vendorViewModel);

                ///---if error deleting product
                if (vendorViewModel.operationStatus == OperationStatus.Error)
                {
                    TempData["errorMessage"] = string.Format("Error deleting vendor \"{0}\"!, {1}", vendorViewModel.vendorModel.Name, vendorViewModel.OperationMessage);
                    return View("VendorForm", vendorViewModel);
                }
                TempData["message"] = string.Format("Vendor \"{0}\" has been deleted!", _vendorName);
                return RedirectToAction("List");

            }
            else
            {
                return View("VendorForm", vendorViewModel);
            }

        }


    }// End of -- public class VendorController : Controller
}