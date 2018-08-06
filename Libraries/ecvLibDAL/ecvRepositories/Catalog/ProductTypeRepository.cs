using ecvLib.Core.ecvDomain.Catalog;
using System;
using System.Collections.Generic;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public class ProductTypeRepository : ecvRepository<ProductType>, IProductTypeRepository
    {
    
        public ProductTypeRepository(ecvDBContext context)
            : base(context)
        {

        }

        public ecvDBContext ecvDBContext
        {
            get { return Context as ecvDBContext; }
        }


        public IList<ProductType> GetAllProductTypes(string Description = "", int storeId = 0, int pageIndex = 1, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public string RemoveProductType(int productTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
