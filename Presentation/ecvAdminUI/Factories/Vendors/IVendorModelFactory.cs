using ecvAdminUI.Models.Vendors;
using ecvAdminUI.ViewModels.Vendors;
using System.Collections.Generic;

namespace ecvAdminUI.Factories.Vendors
{
    public partial interface IVendorModelFactory
    {
        List<VendorListModel> GetVendorsList(bool FirstElementEmpty);

        VendorViewModel getVendorVM(int vendorId);

        VendorViewModel deleteVendor(VendorViewModel vendorViewModel);

        VendorViewModel saveVendor(VendorViewModel vendorViewModel);

    }
}
