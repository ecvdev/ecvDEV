using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using System.Collections.Generic;

namespace ecvAdminUI.Factories.Catalog
{
    public partial interface ICatalogModelFactory
    {

        //List<CategoryListModel> GetAllCategoriesList(bool FirstElementEmpty);

        List<CategoryListModel> GetCategoryList(bool FirstElementEmpty);

        CategoryViewModel getCategoryVM(int categoryId);

        CategoryViewModel deleteCategory(CategoryViewModel categoryViewModel);

        CategoryViewModel saveCategory(CategoryViewModel categoryViewModel);

    }// End of -- public partial interface ICatalogModelFactory

}
