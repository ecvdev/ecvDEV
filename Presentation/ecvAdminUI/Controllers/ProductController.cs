using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using ecvLib.Core;
using System;
using System.Web.Mvc;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;

namespace ecvAdminUI.Controllers
{
    public class ProductController : Controller
    {
        IProductModelFactory _productModelFactory;

        public ProductController(IProductModelFactory productModelFactory)
        {
            _productModelFactory = productModelFactory;
        }


        // GET: Product
        public ActionResult List()
        {
            return View();

        }
        // GET: Product
        public ActionResult ListX(string productName = "", int storeId = 0, int pageIndex = 1, int pageSize = 15, bool showHidden = false)
        {
            var query = _productModelFactory.GetAllProductsList();

            PagedList<ProductListModel> model = new PagedList<ProductListModel>(query, pageIndex ,pageSize);
            return View(model);

        }

        public ActionResult Details(int productId)
        {

            var productViewModel = _productModelFactory.getProductVM(productId);

            if (productViewModel == null)
            {
                return HttpNotFound("Product not found to view details!");
            }
            else if (productViewModel.productModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Product \"{0}\" is marked as deleted!", productViewModel.productModel.Name);
                return RedirectToAction("List");
            }

            productViewModel.operationType = OperationType.Detail;

            return View("ProductForm", productViewModel);

        }

        public ActionResult New()
        {
            var productViewModel = new ProductViewModel
            {
                productModel = new ProductModel()
            };

            productViewModel.operationType = OperationType.New;

            productViewModel.productModel.CreatedOnUtc = DateTime.Now;
            productViewModel.productModel.UpdatedOnUtc = DateTime.Now;

            var productTypeModelList = _productModelFactory.GetProductTypes();

            productViewModel.productTypeModel = productTypeModelList;

            return View("ProductForm", productViewModel);
        }        

        public ActionResult Edit(int productId)
        {
            var productViewModel = _productModelFactory.getProductVM(productId);

            if (productViewModel == null)
            {
                return HttpNotFound("Product not found to edit!");
            }
            else if (productViewModel.productModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Product \"{0}\" is marked as deleted!", productViewModel.productModel.Name);
                return RedirectToAction("List");
            }

            productViewModel.operationType = OperationType.Edit;

            return View("ProductForm", productViewModel);
        }

        public ActionResult Delete(int productId)
        {
            var productViewModel = _productModelFactory.getProductVM(productId);

            if (productViewModel == null)
            {
                return HttpNotFound("Product not found to delete!");
            }
            else if (productViewModel.productModel.Deleted.Equals(true))
            {
                TempData["message"] = string.Format("Product \"{0}\" is already marked as deleted!", productViewModel.productModel.Name);
                return RedirectToAction("List");
            }

            productViewModel.operationType = OperationType.Delete;

            return View("ProductForm", productViewModel);
            
        }

        [HttpPost]
        public ActionResult Details(ManufacturerViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View("ProductForm", productViewModel);
            }
        }

        [HttpPost]
        public ActionResult SaveNew(ProductViewModel productViewModel)
        {
            productViewModel.operationType = OperationType.New;
            if (ModelState.IsValid)
            {
                _productModelFactory.saveProduct(productViewModel);
                if (productViewModel.operationStatus == OperationStatus.Error)
                {
                    //-----After submitting form system loses ProductTypeModelList, below code gets it back
                    var productTypeModelList = _productModelFactory.GetProductTypes();
                    if (productTypeModelList != null)
                    {
                        productViewModel.productTypeModel = productTypeModelList;
                    }
                    //-----

                    //---------Below for loop gets collection of validation errors
                    foreach (var _propertyError in productViewModel.ecvRuleViolation)
                    {
                        //--Add error on summary level
                        //ModelState.AddModelError(string.Empty, _propertyError._errorMessage);
                        //--Add error property level
                        ModelState.AddModelError("productModel." + _propertyError._propertyName, _propertyError._errorMessage);
                    }
                    //-------

                    return View("ProductForm", productViewModel);
                    //throw new Exception(productViewModel.OperationMessage);
                }
                TempData["message"] = string.Format("New product \"{0}\" has been created.", productViewModel.productModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                var productTypeModelList = _productModelFactory.GetProductTypes();
                if (productTypeModelList != null)
                {
                    productViewModel.productTypeModel = productTypeModelList;
                }
                return View("ProductForm", productViewModel);
            }


        }// End of -- public ActionResult Save(ProductViewModel productViewModel)

        [HttpPost]
        public ActionResult SaveEdit(ProductViewModel productViewModel)
        {
            productViewModel.operationType = OperationType.Edit;
            if (ModelState.IsValid)
            {
                _productModelFactory.saveProduct(productViewModel);
                if (productViewModel.operationStatus == OperationStatus.Error)
                {
                    //-----After submitting form system loses ProductTypeModelList, below code gets it back
                    var productTypeModelList = _productModelFactory.GetProductTypes();
                    if (productTypeModelList != null)
                    {
                        productViewModel.productTypeModel = productTypeModelList;
                    }
                    //-----

                    //---------Below for loop gets collection of validation errors
                    foreach (var _propertyError in productViewModel.ecvRuleViolation)
                    {
                        //--Add error on summary level
                        //ModelState.AddModelError(string.Empty, _propertyError._errorMessage);
                        //--Add error property level
                        ModelState.AddModelError("productModel." + _propertyError._propertyName, _propertyError._errorMessage);
                    }
                    //-------

                    return View("ProductForm", productViewModel);
                    //throw new Exception(productViewModel.OperationMessage);
                }
                TempData["message"] = string.Format("Product \"{0}\" has been updated.", productViewModel.productModel.Name);
                return RedirectToAction("List");
            }
            else
            {
                var productTypeModelList = _productModelFactory.GetProductTypes();
                if (productTypeModelList != null)
                {
                    productViewModel.productTypeModel = productTypeModelList;
                }
                return View("ProductForm", productViewModel);
            }


        }// End of -- public ActionResult Save(ProductViewModel productViewModel)

        [HttpPost]
        public ActionResult DeleteConfirmed(ProductViewModel productViewModel)
        {
            productViewModel.operationType = OperationType.Delete;
            if (ModelState.IsValid)
            {
                if (productViewModel == null)
                {
                    return HttpNotFound("Product not found to delete!");
                }               

                string _productName = productViewModel.productModel.Name;

                _productModelFactory.deleteProduct(productViewModel);

                ///---if error deleting product
                if (productViewModel.operationStatus == OperationStatus.Error)
                {
                    //return HttpNotFound(productViewModel.OperationMessage);
                    var productTypeModelList = _productModelFactory.GetProductTypes();
                    if (productTypeModelList != null)
                    {
                        productViewModel.productTypeModel = productTypeModelList;
                    }
                    TempData["errorMessage"] = string.Format("Error deleting product \"{0}\"!, {1}", productViewModel.productModel.Name, productViewModel.OperationMessage);
                    return View("ProductForm", productViewModel);
                }
                TempData["message"] = string.Format("Product \"{0}\" has been deleted!", _productName);
                return RedirectToAction("List");

            }
            else
            {
                var productTypeModelList = _productModelFactory.GetProductTypes();
                if (productTypeModelList != null)
                {
                    productViewModel.productTypeModel = productTypeModelList;
                }
                return View("ProductForm", productViewModel);
            }

        }

    }// End of -- public class ProductController : Controller
}




//public ActionResult New()
//{
//    var productViewModel = new ProductViewModel
//    {
//        productModel = new ProductModel()
//    };

//    productViewModel.operationType = OperationType.New;

//    //---Setup default new product values

//    //-----General Information -----
//    //-----------Basic--------
//    productViewModel.productModel.ShortDescription = null;
//    productViewModel.productModel.FullDescription = null;
//    productViewModel.productModel.Sku = null;
//    //-----------Advanced--------
//    productViewModel.productModel.ProductTypeId = 5;
//    productViewModel.productModel.VisibleIndividually = true;
//    productViewModel.productModel.Published = true;
//    productViewModel.productModel.AllowCustomerReviews = true;
//    ///productViewModel.productModel.ProductTags---Still need to be add;



//    //-----Prices -----
//    //-----------Basic--------
//    productViewModel.productModel.Price = 0.0000M;
//    productViewModel.productModel.IsTaxExempt = false;
//    productViewModel.productModel.TaxCategoryId = 0;

//    //-------Inventory-------
//    //-----------Basic--------
//    productViewModel.productModel.ManageInventoryMethodId = 0;

//    //-------Shipping-------
//    //-----------Basic--------
//    productViewModel.productModel.IsShipEnabled = true;

//    //-------Dimension-------
//    //-----------Basic--------
//    productViewModel.productModel.Weight = 0.0000M;
//    productViewModel.productModel.Height = 0.0000M;
//    productViewModel.productModel.Length = 0.0000M;
//    productViewModel.productModel.Width = 0.0000M;


//    productViewModel.productModel.CreatedOnUtc = DateTime.Now;
//    productViewModel.productModel.UpdatedOnUtc = DateTime.Now;

//    var productTypeModelList = _productModelFactory.GetProductTypes();

//    productViewModel.productTypeModel = productTypeModelList;

//    return View("ProductForm", productViewModel);
//}