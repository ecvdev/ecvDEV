using ecvLib.Core.ecvDomain.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public class ProductRepository : ecvRepository<Product>, IProductRepository
    {
        public ProductRepository(ecvDBContext context)
            : base(context)
        {

        }

        public ecvDBContext ecvDBContext
        {
            get { return Context as ecvDBContext; }
        }


        public IList<Product> GetAllProducts(string productName = "", int storeId = 0, int pageIndex = 1, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return ecvDBContext.Product
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public string RemoveProduct(int productId)
        {
            var _product = base.Get(productId);
            
            _product.Deleted = true;
            
            return "true";
        }   
        
    }
}
