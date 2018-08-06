using ecvLib.Core.ecvDomain.Catalog;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs.Catalog;
using System.Collections.Generic;

namespace ecvLibServices.ecvServices.Catalog
{
    public partial interface ICategoryService
    {
        /// <summary>
        /// Gets a category by category identifier
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        CategoryDTO GetCategoryById(int categoryId);

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="category">Category</param>
        ecvOperationStatus DeleteCategory(int categoryId);

        /// <summary>
        /// Gets all Categories
        /// </summary>
        /// <param name="name">Category name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        IEnumerable<CategoryDTO> GetAllCategory();
        //string name = "",int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)


        IEnumerable<CategoryListDTO> GetCategoryList();

        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="category">Category</param>
        void CreateCategory(Category category);

        /// <summary>
        /// Updates the Category
        /// </summary>
        /// <param name="category">Category</param>
        void UpdateCategory(Category category);


        /// <summary>
        /// Save the Category
        /// </summary>
        /// <param name="category">Category</param>
        ecvOperationStatus SaveCategory(CategoryDTO categoryDto);

        /// <summary>
        /// Check Category Business And Validation Rules
        /// </summary>
        /// <param name="categoryDTO">categoryDTO</param>
        List<ecvRuleViolation> processBAVRules(CategoryDTO categoryDto);

        int Complete();

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------

        List<CategoryListDTO> GetCategoryListWithParent(bool FirstElementEmpty);        

    }
}
