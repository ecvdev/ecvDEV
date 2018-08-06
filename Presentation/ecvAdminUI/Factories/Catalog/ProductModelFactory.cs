using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using ecvLibDAL.ecvUnitOfWork;
using ecvAdminUI.Models;
using ecvLib.Core.ecvDomain.Catalog;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;

namespace ecvAdminUI.Factories.Catalog
{
    public partial class ProductModelFactory : IProductModelFactory
    {
        IUnitOfWork _unitOfWork;
        public ProductModelFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductViewModel deleteProduct(ProductViewModel productViewModel)
        {

            Product product = new Product();

            if (productViewModel.productModel.Id > 0) //Record to delete
            {
                product = _unitOfWork.productRepository.Get(productViewModel.productModel.Id);
                if (product == null)
                {
                    productViewModel.operationStatus = OperationStatus.Error;
                    productViewModel.OperationMessage = "Product not found while deleting!";
                    return productViewModel;
                }

            }
            _unitOfWork.productRepository.RemoveProduct(product.Id);
            _unitOfWork.Complete();

            productViewModel.operationStatus = OperationStatus.Success;
            productViewModel.OperationMessage = "";

            return productViewModel;

        }

        public List<ProductListModel> GetAllProductsList()
        {

            var model = new List<ProductListModel>();

            var tmpAllProducts = _unitOfWork.productRepository.GetAll().Where(p=>p.Deleted.Equals(false)).ToList();

            foreach (var tmpProduct in tmpAllProducts)
            {
                ProductListModel singleProductListModel = new ProductListModel();
                
                //--below loop copy product value from retrieved list
                foreach (var propDest in singleProductListModel.GetType().GetProperties())
                {
                    //Find property in source based on destination name
                    var propSrc = tmpProduct.GetType().GetProperty(propDest.Name);
                    if (propSrc != null)
                    {
                        //Get value from source and assign it to destination
                        propDest.SetValue(singleProductListModel, propSrc.GetValue(tmpProduct));
                    }
                }

                model.Add(singleProductListModel);
                
            }

            return model;
        }

        public ProductViewModel getProductVM(int ProductId)
        {

            //--Get Product 
            var product = _unitOfWork.productRepository.Get(ProductId);

            var productViewModel = new ProductViewModel
            {
                productModel = new ProductModel(),
                productTypeModel = new List<ProductTypeModel>()
            };

            if (product == null)
            {
                productViewModel = null;
                return productViewModel;
            }

            //--Prepare Product Model
            foreach (var propDest in productViewModel.productModel.GetType().GetProperties())
            {
                //Find property in source based on destination name
                var propSrc = product.GetType().GetProperty(propDest.Name);
                if (propSrc != null)
                {
                    //Get value from source and assign it to destination
                    propDest.SetValue(productViewModel.productModel, propSrc.GetValue(product));
                }
            }

            //--Get parent product name if product is part of grouped product.
            if(product.ParentGroupedProductId > 0)
            {
                var parentGroupedProduct = _unitOfWork.productRepository.Get(product.ParentGroupedProductId);
                if (parentGroupedProduct != null)
                {
                    productViewModel.productModel.AssociatedToProductName = parentGroupedProduct.Name;
                }
            }

            //--Prepare ProductType Model

            var productTypeModelList = GetProductTypes();
            if (productTypeModelList != null)
            {
                //ProductTypeModel noneElement = new ProductTypeModel();
                //noneElement.Id = 0;
                //noneElement.StoreID = 0;
                //noneElement.Description = "[None]";
                //productTypeModelList.Insert(0, noneElement);

                productViewModel.productTypeModel =  productTypeModelList;
            }

            return productViewModel; 
        }

        public ProductViewModel saveProduct(ProductViewModel productViewModel)
        {
            Product product = new Product();

            if (productViewModel.productModel.Id > 0) //Record to update
            {
                product = _unitOfWork.productRepository.Get(productViewModel.productModel.Id);

                if (product == null)
                {
                    productViewModel.operationStatus = OperationStatus.Error;
                    productViewModel.OperationMessage = "Product not found while updating!";
                    return productViewModel;
                }
                productViewModel.productModel.UpdatedOnUtc = DateTime.Now;
            }
            else // Record to add new
            {
                productViewModel.productModel.CreatedOnUtc = DateTime.Now;
                productViewModel.productModel.UpdatedOnUtc = DateTime.Now;
                _unitOfWork.productRepository.Add(product);
            }

            foreach (var propDest in product.GetType().GetProperties())
            {
                //Find property in source based on destination name
                var propSrc = productViewModel.productModel.GetType().GetProperty(propDest.Name);

                if (propSrc != null)
                {
                    //Get value from source and assign it to destination
                    propDest.SetValue(product, propSrc.GetValue(productViewModel.productModel));
                }
            }

            //bool BRresult = false;
            //BRresult = product.processBusinessRules();
            //if (BRresult == false)
            //{
            //    productViewModel.operationStatus = OperationStatus.Error;
            //    productViewModel.OperationMessage = product.ecvBRMessage;
            //    return productViewModel;
            //}

            var objValidataionList = product.ecvGetRuleViolations();

            if (objValidataionList.Count() > 0)
            {
                productViewModel.operationStatus = OperationStatus.Error;
                productViewModel.ecvRuleViolation = objValidataionList;
                return productViewModel;
            }


            int intCompeteState = 0;
            intCompeteState = _unitOfWork.Complete();

            if (intCompeteState > 0 )
            {
                productViewModel.operationStatus = OperationStatus.Success;
                productViewModel.OperationMessage = "";
            }
            else
            {
                productViewModel.operationStatus = OperationStatus.Error;
                productViewModel.OperationMessage = _unitOfWork.ecvError;
            }
            

            return productViewModel;
        }

        public List<ProductTypeModel> GetProductTypes()
        {
            List<ProductTypeModel> _productTypeModelList = null;
            var productTypeList = _unitOfWork.productTypeRepository.GetAll().ToList();
            if (productTypeList == null)
            {                
                return _productTypeModelList;
            }
            _productTypeModelList = new List<ProductTypeModel>();
            //-- Go through each record from table
            foreach (var _productType in productTypeList)
            {
                //--Create single Product Type Model and add it to View model 
                ProductTypeModel productTypeModelSingle = new ProductTypeModel();
                foreach (var propDest in productTypeModelSingle.GetType().GetProperties())
                {
                    //Find property in source based on destination name
                    var propSrc = _productType.GetType().GetProperty(propDest.Name);
                    if (propSrc != null)
                    {
                        //Get value from source and assign it to destination
                        propDest.SetValue(productTypeModelSingle, propSrc.GetValue(_productType));
                    }
                }
                _productTypeModelList.Add(productTypeModelSingle);
            }

            //--Below code insert first element as [None]---
            //ProductTypeModel noneElement = new ProductTypeModel();
            //noneElement.Id = 0;
            //noneElement.StoreID = 0;
            //noneElement.Description = "[None]";
            //_productTypeModelList.Insert(0, noneElement);

            return _productTypeModelList;
        }

    }// End of -- public partial class ProductModelFactory : IProductModelFactory
}