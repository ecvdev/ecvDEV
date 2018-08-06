using ecvLib.Core.ecvDomain.Catalog;
using System.Collections.Generic;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="productName">Category name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Products</returns>
        IList<Product> GetAllProducts(string productName = "", int storeId = 0,
            int pageIndex = 1, int pageSize = int.MaxValue, bool showHidden = false);


        string RemoveProduct(int productId);

        //bool chkBR_Product();

    }
}
