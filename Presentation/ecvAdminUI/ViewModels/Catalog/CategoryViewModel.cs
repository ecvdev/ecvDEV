using ecvAdminUI.Models.Catalog;
using ecvLib.Core.ecvOperationStatus;
using System.Collections.Generic;

namespace ecvAdminUI.ViewModels.Catalog
{
    public class CategoryViewModel : ecvOperationStatus
    {
        public IEnumerable<CategoryListModel> categoryListModel { get; set; }

        public CategoryModel categoryModel { get; set; }

    }
}