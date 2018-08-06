using ecvLib.Core.ecvDomain.Catalog;
using System.Collections.Generic;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="ManufacturerName">Category name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        IList<Manufacturer> GetAllManufacturers(string manufacturerName = "", int storeId = 0,
            int pageIndex = 1, int pageSize = int.MaxValue, bool showHidden = false);


        string RemoveManufacturer(int manufacturerId);
    }
}
