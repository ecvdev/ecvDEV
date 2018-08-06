using ecvLib.Core.ecvDomain.Catalog;
using ecvLib.Core.ecvMapper;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDAL.ecvUnitOfWork;
using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using static ecvLib.Core.ecvOperationStatus.ecvOperationStatus;
using ecvLibServices.ecvBAVRules.Catalog;

namespace ecvLibServices.ecvServices.Catalog
{
    public partial class CategoryService : ICategoryService
    {

        IUnitOfWork _unitOfWork;

        List<ecvRuleViolation> bavrIssues;
        ecvOperationStatus categoryServiceStatus;
        //ctor
        public CategoryService(IUnitOfWork unitOfWork)
        {
            bavrIssues = new List<ecvRuleViolation>();
            _unitOfWork = unitOfWork;
        }

        public ecvOperationStatus DeleteCategory(int categoryId)
        {
            categoryServiceStatus = new ecvOperationStatus();

            if (categoryId < 1)
            {
                categoryServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                categoryServiceStatus.OperationMessage = "Invalid category id!";

                return categoryServiceStatus;
            }

            var category = privateGetCategoryById(categoryId); //--before marking category as deleted check it is exist in database
            if (category == null)
            {
                categoryServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                categoryServiceStatus.OperationMessage = "Category not found while deleting!";

                return categoryServiceStatus;
            }

            //--Before marking category as deleted should it check Business and Validation rules?

            //--Mark Category as deleted
            _unitOfWork.categoryRepository.markAsDeleted(categoryId);


            int intCompleteState = 0;
            intCompleteState = _unitOfWork.Complete();

            if (intCompleteState > 0)
            {
                // When successfull
                categoryServiceStatus.operationStatus = OperationStatus.Success;
                categoryServiceStatus.OperationMessage = "";
            }
            else
            {
                categoryServiceStatus.operationStatus = OperationStatus.Error;
                categoryServiceStatus.OperationMessage = _unitOfWork.ecvError;
            }

            return categoryServiceStatus;
        }

        public IEnumerable<CategoryDTO> GetAllCategory()
        {
            var _categorysList = _unitOfWork.categoryRepository.GetAll().ToList();

            IList<CategoryDTO> _categoryDTOs;

            if (_categorysList == null)
            {
                _categoryDTOs = null;
            }
            else
            {
                var categoryMapper = new ecvMapper<Category, CategoryDTO>();
                _categoryDTOs = categoryMapper.CreateMappedObject(_categorysList);
            }

            return _categoryDTOs;
        }

        public IEnumerable<CategoryListDTO> GetCategoryList()
        {
            var _categorysList = _unitOfWork.categoryRepository.GetAll().ToList();

            IList<CategoryListDTO> _categoryListDTOs;

            if (_categorysList == null)
            {
                _categoryListDTOs = null;
            }
            else
            {
                var categoryListMapper = new ecvMapper<Category, CategoryListDTO>();
                _categoryListDTOs = categoryListMapper.CreateMappedObject(_categorysList);
            }

            return _categoryListDTOs;

        }

        public CategoryDTO GetCategoryById(int categoryId)
        {
            var _category = _unitOfWork.categoryRepository.Get(categoryId);

            CategoryDTO _categoryDTO;

            if (_category == null)
            {
                _categoryDTO = null;
            }
            else
            {
                _categoryDTO = new CategoryDTO();
                var categoryMapper = new ecvMapper<Category, CategoryDTO>();

                _categoryDTO = categoryMapper.CreateMappedObject(_category);
            }

            return _categoryDTO;
        }

        private Category privateGetCategoryById(int categoryId)
        {
            var _category = _unitOfWork.categoryRepository.Get(categoryId);

            return _category;
        }

        public void CreateCategory(Category category)
        {
            _unitOfWork.categoryRepository.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.categoryRepository.Update(category);
        }

        public ecvOperationStatus SaveCategory(CategoryDTO categoryDto)
        {
            Category category = new Category();
            categoryServiceStatus = new ecvOperationStatus();

            if (categoryDto.Id > 0) //Record to update
            {
                category = _unitOfWork.categoryRepository.Get(categoryDto.Id); // privateGetCategoryById(categoryDto.Id); //Get category entity from database
                if (category == null)
                {
                    categoryServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                    categoryServiceStatus.OperationMessage = "Category not found while updating!";

                    return categoryServiceStatus;
                }
                else
                {
                    //validate category hierarchy
                    var parentCategory = _unitOfWork.categoryRepository.Get(categoryDto.ParentCategoryId);
                    while(parentCategory != null)
                    {
                        if(categoryDto.Id == parentCategory.Id)
                        {
                            categoryDto.ParentCategoryId = 0;
                            //break;
                            categoryServiceStatus.operationStatus = ecvOperationStatus.OperationStatus.Error;
                            categoryServiceStatus.OperationMessage = "Invalid category hierarchy!";
                            bavrIssues = new List<ecvRuleViolation>();
                            bavrIssues.Add(
                                    new ecvRuleViolation("ParentCategoryId", categoryDto.ParentCategoryId, "Invalid category hierarchy!")
                                    );

                            categoryServiceStatus.ecvRuleViolation = bavrIssues;

                            return categoryServiceStatus; //should exit from here
                        }
                        parentCategory = _unitOfWork.categoryRepository.Get(parentCategory.ParentCategoryId);                       
                    }
                }
                               
                categoryDto.UpdatedOnUtc = DateTime.Now;
            }
            else // Record to add new
            {
                categoryDto.CreatedOnUtc = DateTime.Now;
                categoryDto.UpdatedOnUtc = DateTime.Now;

                _unitOfWork.categoryRepository.Add(category); //Create new category
            }

            //--Check business and validation rules
            bavrIssues = new List<ecvRuleViolation>();
            bavrIssues = processBAVRules(categoryDto);

            if (bavrIssues.Count() > 0)
            {
                categoryServiceStatus.operationStatus = OperationStatus.Error;
                categoryServiceStatus.OperationMessage = "Business and validation rules violation!";
                categoryServiceStatus.ecvRuleViolation = bavrIssues;

                return categoryServiceStatus;
            }

            //--Once business and validation rules are passed, copy values from DTO to CategoryEntity.
            //--Prepare Category Model
            var categoryMapper = new ecvMapper<CategoryDTO, Category>();
            categoryMapper.MapObject(categoryDto, category); //--Directly mapping object

            int intCompleteState = 0;
            intCompleteState = _unitOfWork.Complete();

            if (intCompleteState > 0)
            {
                // When successfully save record
                categoryServiceStatus.operationStatus = OperationStatus.Success;
                categoryServiceStatus.OperationMessage = "";
            }
            else
            {
                categoryServiceStatus.operationStatus = OperationStatus.Error;
                if (!string.IsNullOrEmpty(_unitOfWork.ecvError))
                {
                    categoryServiceStatus.OperationMessage = _unitOfWork.ecvError;
                }
                else
                {
                    categoryServiceStatus.OperationMessage = "Error, unexpected error occured cannot save category record!";
                }
            }

            return categoryServiceStatus;

        }// End of -- public void SaveCategory(CategoryDTO categoryDto)

        public int Complete()
        {
            return _unitOfWork.Complete();
        }

        public List<ecvRuleViolation> processBAVRules(CategoryDTO categoryDTO)
        {

            CategoryBAVRules _categoryBAVRules = new CategoryBAVRules(categoryDTO);
            return _categoryBAVRules.ecvGetRuleViolations();
        }


        //----------------------------------------------------------------------
        //----------------------------------------------------------------------

        public List<CategoryListDTO> GetCategoryListWithParent(bool FirstElementEmpty)
        {
            //IList<Category> _allCategories = null;

            var _categoryListDTO = new List<CategoryListDTO>();

            var _allCategories = GetCategoryList().Where(c => c.Deleted.Equals(false)).ToList();

            CategoryListDTO singleCategoryDTO = null;

            foreach (var cate in _allCategories)
            {
                singleCategoryDTO = new CategoryListDTO();
                singleCategoryDTO.Id = cate.Id;
                singleCategoryDTO.Name = cate.Name;
                singleCategoryDTO.Published = cate.Published;
                singleCategoryDTO.DisplayOrder = cate.DisplayOrder;
                singleCategoryDTO.ParentCategoryId = cate.ParentCategoryId;
                if (cate.ParentCategoryId > 0)
                {
                    singleCategoryDTO.CategoryFullName = chkCategoryParent(cate.ParentCategoryId, _allCategories) + ">>" + cate.Name;
                }
                else
                {
                    singleCategoryDTO.CategoryFullName = cate.Name;
                }
                _categoryListDTO.Add(singleCategoryDTO);
            }

            _categoryListDTO = _categoryListDTO.OrderBy(c => c.CategoryFullName).ToList();

            if (FirstElementEmpty.Equals(true))
            {
                singleCategoryDTO = new CategoryListDTO();
                singleCategoryDTO.Id = 0;
                singleCategoryDTO.Name = "";
                singleCategoryDTO.CategoryFullName = "[None]";

                _categoryListDTO.Insert(0, singleCategoryDTO);
            }

            return _categoryListDTO;

        }// End of -- public List<CategoryListModel> GetAllCategoriesList()

        public string chkCategoryParent(int parentCategoryId, IList<CategoryListDTO> allCategories)
        {
            string _categoryFullName = "";

            _categoryFullName = allCategories.Where(c => c.Id == parentCategoryId).Select(c => c.Name).First();

            //Check for Nested sub categories
            int subParentCategoryId = 0;

            subParentCategoryId = allCategories.Where(c => c.Id == parentCategoryId).Select(c => c.ParentCategoryId).First();
            if (subParentCategoryId > 0)
            {
                _categoryFullName = chkCategoryParent(subParentCategoryId, allCategories) + ">>" + _categoryFullName;
            }

            return _categoryFullName;
        }

    }// End of -- public partial class CatagoryService
}
