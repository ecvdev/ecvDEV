using ecvAdminUI.Models;
using ecvAdminUI.Models.Catalog;
using ecvLib.Core.ecvOperationStatus;
using System.Collections.Generic;

namespace ecvAdminUI.ViewModels.Catalog
{
    public class ProductViewModel : ecvOperationStatus
    {
        public ProductModel productModel { get; set; }

        public int ProductPageSize {get;set;}

        public List<int> ProductPageList { get; set; }

        public List<ProductTypeModel> productTypeModel { get; set; }

    }
}