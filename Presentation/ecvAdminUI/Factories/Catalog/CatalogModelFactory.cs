using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using ecvLib.Core.ecvDomain.Catalog;
using ecvLib.Core.ecvMapper;
using ecvLibDAL.ecvUnitOfWork;
using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;
using ecvLibServices.ecvServices.Catalog;

namespace ecvAdminUI.Factories.Catalog
{
    public partial class CatalogModelFactory : ICatalogModelFactory
    {

        //IUnitOfWork _unitOfWork;
        ICategoryService _categoryService;

        public CatalogModelFactory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryListModel> GetCategoryList(bool FirstElementEmpty)
        {
            var model = new List<CategoryListModel>();
            var _categoryList = _categoryService.GetCategoryListWithParent(FirstElementEmpty);

            var categoryListMapper = new ecvMapper<CategoryListDTO, CategoryListModel>();

            model = categoryListMapper.CreateMappedObject(_categoryList);

            model = model.OrderBy(m => m.CategoryFullName).ToList();

            return model;
                
        }

        ////public List<CategoryListModel> GetAllCategoriesList(bool FirstElementEmpty)
        ////{
        ////    //IList<Category> _allCategories = null;

        ////    var model = new List<CategoryListModel>();

        ////    var _allCategories = _categoryService.GetCategoryList().Where(c=> c. Deleted.Equals(false)).ToList();

        ////    CategoryListModel singleModel = null;
        ////    foreach (var cate in _allCategories)
        ////    {
        ////        singleModel = new CategoryListModel();
        ////        singleModel.Id = cate.Id;
        ////        singleModel.CategoryName = cate.CategoryName;
        ////        singleModel.Published = cate.Published;
        ////        singleModel.DisplayOrder = cate.DisplayOrder;
        ////        singleModel.ParentCategoryId = cate.ParentCategoryId;
        ////        if (cate.ParentCategoryId > 0)
        ////        {
        ////            singleModel.CategoryFullName = chkCategoryParent(cate.ParentCategoryId, _allCategories) + ">>" + cate.Name;
        ////        }
        ////        else
        ////        {
        ////            singleModel.CategoryFullName = cate.Name;
        ////        }
        ////        model.Add(singleModel);
        ////    }

        ////    model = model.OrderBy(c => c.CategoryFullName).ToList();

        ////    if (FirstElementEmpty.Equals(true))
        ////    {
        ////        singleModel = new CategoryListModel();
        ////        singleModel.Id = 0;
        ////        singleModel.CategoryName = "";
        ////        singleModel.CategoryFullName = "[None]";

        ////        model.Insert(0, singleModel);
        ////    }

        ////    return model;

        ////}// End of -- public List<CategoryListModel> GetAllCategoriesList()

        ////public string chkCategoryParent(int parentCategoryId, IList<Category> allCategories)
        ////{
        ////    string _categoryFullName = "";

        ////    _categoryFullName = allCategories.Where(c => c.Id == parentCategoryId).Select(c => c.Name).First();

        ////    //Check for Nested sub categories
        ////    int subParentCategoryId = 0;

        ////    subParentCategoryId = allCategories.Where(c => c.Id == parentCategoryId).Select(c => c.ParentCategoryId).First();
        ////    if (subParentCategoryId > 0)
        ////    {
        ////        _categoryFullName = chkCategoryParent(subParentCategoryId, allCategories) + ">>" + _categoryFullName;
        ////    }

        ////    return _categoryFullName;
        ////}


        public CategoryViewModel getCategoryVM(int categoryId)
        {
            CategoryDTO categoryDTO;
            categoryDTO = _categoryService.GetCategoryById(categoryId);

            var categoryViewModel = new CategoryViewModel
            {
                categoryModel = new CategoryModel()
            };

            if (categoryDTO == null)
            {
                //return HttpNotFound("Category not found!");
                categoryViewModel = null;
                return categoryViewModel;
            }

            var categoryMapper = new ecvMapper<CategoryDTO, CategoryModel>();

            categoryViewModel.categoryModel = categoryMapper.CreateMappedObject(categoryDTO);


            //var categoryListModel = GetAllCategoriesList(true);          
            var categoryListModel = GetCategoryList(true);

            //var tt = categoryListModel;            
            //tt.RemoveAll(a => a.Id == categoryViewModel.categoryModel.Id && a.Name == categoryViewModel.categoryModel.Name);

            categoryViewModel.categoryListModel = categoryListModel;

            return categoryViewModel;
        }


        public CategoryViewModel saveCategory(CategoryViewModel categoryViewModel)
        {

            CategoryDTO categoryDTO = new CategoryDTO();

            var categoryMapper = new ecvMapper<CategoryModel, CategoryDTO>();

            categoryDTO = categoryMapper.CreateMappedObject(categoryViewModel.categoryModel);

            var _categoryServiceStatus = _categoryService.SaveCategory(categoryDTO);

            if (_categoryServiceStatus.operationStatus == OperationStatus.Error)
            {
                categoryViewModel.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_categoryServiceStatus.OperationMessage))
                {
                    categoryViewModel.OperationMessage = _categoryServiceStatus.OperationMessage;
                }

                categoryViewModel.ecvRuleViolation = _categoryServiceStatus.ecvRuleViolation;
            }
            else
            {
                categoryViewModel.operationStatus = OperationStatus.Success;
                if (!string.IsNullOrEmpty(_categoryServiceStatus.OperationMessage))
                {
                    categoryViewModel.OperationMessage = _categoryServiceStatus.OperationMessage;
                }
                categoryViewModel.ecvRuleViolation = _categoryServiceStatus.ecvRuleViolation;
            }

            return categoryViewModel;
        }

        public CategoryViewModel deleteCategory(CategoryViewModel categoryViewModel)
        {

            var _categoryServiceStatus = _categoryService.DeleteCategory(categoryViewModel.categoryModel.Id);

            if (_categoryServiceStatus.operationStatus == OperationStatus.Error)
            {
                categoryViewModel.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_categoryServiceStatus.OperationMessage))
                {
                    categoryViewModel.OperationMessage = _categoryServiceStatus.OperationMessage;
                }

                categoryViewModel.ecvRuleViolation = _categoryServiceStatus.ecvRuleViolation;
            }
            else
            {
                categoryViewModel.operationStatus = OperationStatus.Success;
                if (!string.IsNullOrEmpty(_categoryServiceStatus.OperationMessage))
                {
                    categoryViewModel.OperationMessage = _categoryServiceStatus.OperationMessage;
                }
                categoryViewModel.ecvRuleViolation = _categoryServiceStatus.ecvRuleViolation;
            }
            return categoryViewModel;
        }        

    }// End of -- public partial class CatalogModelFactory

}


////public CategoryViewModel saveCategory(CategoryViewModel categoryViewModel)
////{

////    Category category = new Category();

////    if (categoryViewModel.categoryModel.Id > 0) //Record to update
////    {
////        category = _unitOfWork.categoryRepository.Get(categoryViewModel.categoryModel.Id);
////        if (category == null)
////        {
////            categoryViewModel.operationStatus = OperationStatus.Error;
////            categoryViewModel.OperationMessage = "Category not found while updating!";
////            return categoryViewModel;
////        }
////        categoryViewModel.categoryModel.UpdatedOnUtc = DateTime.Now;
////    }
////    else // Record to add new
////    {
////        categoryViewModel.categoryModel.CreatedOnUtc = DateTime.Now;
////        categoryViewModel.categoryModel.UpdatedOnUtc = DateTime.Now;
////        _unitOfWork.categoryRepository.Add(category);
////    }

////    foreach (var propDest in category.GetType().GetProperties())
////    {
////        //Find property in source based on destination name
////        var propSrc = categoryViewModel.categoryModel.GetType().GetProperty(propDest.Name);

////        if (propSrc != null)
////        {
////            //Get value from source and assign it to destination
////            propDest.SetValue(category, propSrc.GetValue(categoryViewModel.categoryModel));
////        }
////    }

////    var objValidataionList = category.ecvGetRuleViolations();

////    if (objValidataionList.Count() > 0)
////    {
////        categoryViewModel.operationStatus = OperationStatus.Error;
////        categoryViewModel.ecvRuleViolation = objValidataionList;
////        return categoryViewModel;
////    }

////    int intCompeteState = 0;
////    intCompeteState = _unitOfWork.Complete();

////    if (intCompeteState > 0) // When successfully save record
////    {
////        categoryViewModel.operationStatus = OperationStatus.Success;
////        categoryViewModel.OperationMessage = "";
////    }
////    else
////    {
////        categoryViewModel.operationStatus = OperationStatus.Error;
////        categoryViewModel.OperationMessage = _unitOfWork.ecvError;
////    }

////    return categoryViewModel;
////}