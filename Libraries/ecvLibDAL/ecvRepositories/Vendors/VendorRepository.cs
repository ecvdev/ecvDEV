using ecvLib.Core.ecvDomain.Vendors;
using System.Collections.Generic;
using System.Linq;

namespace ecvLibDAL.ecvRepositories.Vendors
{
    public class VendorRepository : ecvRepository<Vendor>, IVendorRepository
    {

        public VendorRepository(ecvDBContext context)
            : base(context)
        {

        }        

        public ecvDBContext ecvDBContext
        {
            get { return Context as ecvDBContext; }
        }

        public IList<Vendor> GetAllVendors(string vendorName = "", int storeId = 0, int pageIndex = 1, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return ecvDBContext.Vendor
                .OrderBy(v=> v.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public string markAsDeleted(int vendorId)
        {
            var _vendor = base.Get(vendorId);

            _vendor.Deleted = true;

            return "true";
        }
    }
}
