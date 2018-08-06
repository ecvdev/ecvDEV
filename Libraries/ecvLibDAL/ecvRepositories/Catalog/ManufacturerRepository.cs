using ecvLib.Core.ecvDomain.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public class ManufacturerRepository : ecvRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(ecvDBContext context)
            :base(context)
        {

        }

        public ecvDBContext ecvDBContext
        {
            get { return Context as ecvDBContext; }
        }

        public IList<Manufacturer> GetAllManufacturers(string manufacturerName = "", int storeId = 0, int pageIndex = 1, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return ecvDBContext.Manufacturer
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public string RemoveManufacturer(int manufacturerId)
        {
            var _manufacturer = base.Get(manufacturerId);

            _manufacturer.Deleted = true;

            return "true";
        }
    }
}
