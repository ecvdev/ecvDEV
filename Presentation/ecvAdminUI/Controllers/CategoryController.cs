using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using ecvLib.Core;
using System;
using System.Web.Mvc;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;

namespace ecvAdminUI.Controllers
{
    public class CategoryController : Controller
    {
        ICatalogModelFactory _catalogModelFactory;
        
        public CategoryController(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }
        
        // GET: Category
        public ActionResult List()
        {
            return View();
        }

        ////public ActionResult ListX(string categoryName = "", int storeId = 0, int pageIndex = 1, int pageSize = 9, bool showHidden = false)
        ////{
        ////    var query = _catalogModelFactory.GetAllCategoriesList(false);

        ////    PagedList<CategoryListModel> model = new PagedList<CategoryListModel>(query, pageIndex, pageSize);

        ////    return View(model);

        ////}

        public ActionResult Details(int categoryId)
        {
            var categoryViewModel = _catalogModelFactory.getCategoryVM(categoryId);

            if (categoryViewModel == null)
            {
                return HttpNotFound("Category not found to view details!");
            }
            else if (categoryViewModel.categoryModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Category \"{0}\" is marked as deleted!", categoryViewModel.categoryModel.Name);
                return RedirectToAction("List");
            }

            categoryViewModel.operationType = OperationType.Detail;

            return View("CategoryForm", categoryViewModel);          
        }

        public ActionResult New()
        {
            var categoryViewModel = new CategoryViewModel
            {
                categoryModel = new CategoryModel()
            };

            categoryViewModel.operationType = OperationType.New;

            categoryViewModel.categoryModel.CreatedOnUtc = DateTime.Now;
            categoryViewModel.categoryModel.UpdatedOnUtc = DateTime.Now;

            var categoryListModel = _catalogModelFactory.GetCategoryList(true);
            categoryViewModel.categoryListModel = categoryListModel;

            return View("CategoryForm", categoryViewModel);
        }

        public ActionResult Edit(int categoryId)
        {

            var categoryViewModel = _catalogModelFactory.getCategoryVM(categoryId);

            if (categoryViewModel == null)
            {
                return HttpNotFound("Category not found to edit!");
            }
            else if (categoryViewModel.categoryModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Category \"{0}\" is marked as deleted!", categoryViewModel.categoryModel.Name);
                return RedirectToAction("List");
            }

            categoryViewModel.operationType =  OperationType.Edit;

            return View("CategoryForm", categoryViewModel);
        }

        public ActionResult Delete(int categoryId)
        {
            var categoryViewModel = _catalogModelFactory.getCategoryVM(categoryId);

            if (categoryViewModel == null)
            {
                return HttpNotFound("Category not found to delete!");
            }
            else if (categoryViewModel.categoryModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Category \"{0}\" is already marked as deleted!", categoryViewModel.categoryModel.Name);
                return RedirectToAction("List");
            }

            categoryViewModel.operationType = OperationType.Delete;

            return View("CategoryForm", categoryViewModel);
        }

        [HttpPost]
        public ActionResult Details(CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View("CategoryForm", categoryViewModel);
            }
        }

        [HttpPost]
        public ActionResult SaveNew(CategoryViewModel categoryViewModel)
        {
            categoryViewModel.operationType = OperationType.New;
            if (ModelState.IsValid)
            {
                _catalogModelFactory.saveCategory(categoryViewModel);
                if (categoryViewModel.operationStatus == OperationStatus.Error)
                {
                    //-----After submitting form system loses CategoryList, below code gets it back
                    var categoryListModel = _catalogModelFactory.GetCategoryList(true);
                    if (categoryListModel != null)
                    {
                        categoryViewModel.categoryListModel = categoryListModel;
                    }
                    //---------

                    //---------Below for loop gets collection of validation errors
                    foreach (var _propertyError in categoryViewModel.ecvRuleViolation)
                    {
                        //--Add error on summary level
                        //ModelState.AddModelError(string.Empty, _propertyError._errorMessage);
                        //--Add error property level
                        ModelState.AddModelError("categoryModel." + _propertyError._propertyName, _propertyError._errorMessage);
                    }
                    //-------

                    return View("CategoryForm", categoryViewModel);
                }
                TempData["message"] = string.Format("New category \"{0}\" has been created.", categoryViewModel.categoryModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                var categoryListModel = _catalogModelFactory.GetCategoryList(true);
                categoryViewModel.categoryListModel = categoryListModel;

                return View("CategoryForm",categoryViewModel);
            }            
        }

        [HttpPost]
        public ActionResult SaveEdit(CategoryViewModel categoryViewModel)
        {
            categoryViewModel.operationType = OperationType.Edit;
            if (ModelState.IsValid)
            {
                _catalogModelFactory.saveCategory(categoryViewModel);
                if (categoryViewModel.operationStatus == OperationStatus.Error)
                {
                    //-After submitting form system loses CategoryList, below code gets it back
                    var categoryListModel = _catalogModelFactory.GetCategoryList(true);
                    if (categoryListModel != null)
                    {
                        categoryViewModel.categoryListModel = categoryListModel;
                    }
                    //------

                    //---------Below for loop gets collection of validation errors
                    foreach (var _propertyError in categoryViewModel.ecvRuleViolation)
                    {
                        //--Add error on summary level
                        //ModelState.AddModelError(string.Empty, _propertyError._errorMessage);
                        //--Add error property level
                        ModelState.AddModelError("categoryModel." + _propertyError._propertyName, _propertyError._errorMessage);
                    }
                    //-------
                    
                    return View("CategoryForm", categoryViewModel);
                }
                TempData["message"] = string.Format("Category \"{0}\" has been updated.", categoryViewModel.categoryModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                var categoryListModel = _catalogModelFactory.GetCategoryList(true);
                categoryViewModel.categoryListModel = categoryListModel;

                return View("CategoryForm", categoryViewModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(CategoryViewModel categoryViewModel)
        {
            categoryViewModel.operationType = OperationType.Delete;
            if (ModelState.IsValid)
            {
                if (categoryViewModel == null)
                {
                    return HttpNotFound("Category not found to delete!");
                }

                categoryViewModel.operationType = OperationType.Delete;

                string _categoryName = categoryViewModel.categoryModel.Name;

                _catalogModelFactory.deleteCategory(categoryViewModel);

                if (categoryViewModel.operationStatus == OperationStatus.Error)
                {
                    //return HttpNotFound(categoryViewModel.OperationMessage);
                    TempData["errorMessage"] = string.Format("Error deleting category \"{0}\"!, {1}", categoryViewModel.categoryModel.Name, categoryViewModel.OperationMessage);
                    return View("CategoryForm", categoryViewModel);
                }
                TempData["message"] = string.Format("Category \"{0}\" has been deleted!", _categoryName);
                return RedirectToAction("List");

            }
            else
            {
                return View(categoryViewModel);
            }

        }


    }// End of -- public class CategoryController : Controller
}