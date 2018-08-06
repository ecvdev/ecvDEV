using ecvLib.Core.ecvDomain.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLibDAL.ecvRepositories.Vendors
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        /// <summary>
        /// Gets all vendors
        /// </summary>
        /// <param name="vendorName">Vendor name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Products</returns>
        IList<Vendor> GetAllVendors(string vendorName = "", int storeId = 0,
            int pageIndex = 1, int pageSize = int.MaxValue, bool showHidden = false);


        string markAsDeleted(int vendorId);      

    }
}
