using ecvAdminUI.Models.Vendors;
using ecvLib.Core.ecvOperationStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecvAdminUI.ViewModels.Vendors
{
    public class VendorViewModel : ecvOperationStatus
    {
        public IEnumerable<VendorListModel> vendorListModel { get; set; }

        public VendorModel vendorModel { get; set; }
    }
}