using ecvLib.Core.ecvDomain.Catalog;
using System.Collections.Generic;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        IList<ProductType> GetAllProductTypes(string Description = "", int storeId = 0,
                    int pageIndex = 1, int pageSize = int.MaxValue);


        string RemoveProductType(int productTypeId);        
    }
}
