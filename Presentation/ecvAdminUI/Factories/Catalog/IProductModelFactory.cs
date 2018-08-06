using ecvAdminUI.Models;
using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvAdminUI.Factories.Catalog
{
    public partial interface IProductModelFactory
    {

        List<ProductListModel> GetAllProductsList();

        ProductViewModel getProductVM(int ProductId);

        ProductViewModel deleteProduct(ProductViewModel productViewModel);

        ProductViewModel saveProduct(ProductViewModel productViewModel);

        List<ProductTypeModel> GetProductTypes();

    }// End of -- public partial interface IProductModelFactory
}
