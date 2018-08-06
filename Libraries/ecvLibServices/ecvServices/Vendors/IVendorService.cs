using ecvLib.Core.ecvDomain.Vendors;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs.Vendor;
using System.Collections.Generic;

namespace ecvLibServices.ecvServices.Vendors
{
    public partial interface IVendorService
    {
        /// <summary>
        /// Gets a vendor by vendor identifier
        /// </summary>
        /// <param name="vendorId">Vendor identifier</param>
        /// <returns>Vendor</returns>
        VendorDTO GetVendorById(int vendorId);

        /// <summary>
        /// Delete a vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        ecvOperationStatus DeleteVendor(int vendorId);

        /// <summary>
        /// Gets all vendors
        /// </summary>
        /// <param name="name">Vendor name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Vendors</returns>
        IEnumerable<VendorDTO> GetAllVendors();
        //string name = "",int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)


        IEnumerable<VendorListDTO> GetVendorsList();

        /// <summary>
        /// Create a vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        void CreateVendor(Vendor vendor);

        /// <summary>
        /// Updates the vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        void UpdateVendor(Vendor vendor);


        /// <summary>
        /// Save the vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        ecvOperationStatus SaveVendor(VendorDTO vendorDto);

        /// <summary>
        /// Check vendro Business And Validation Rules
        /// </summary>
        /// <param name="vendorDTO">VendorDTO</param>
        List<ecvRuleViolation> processBAVRules(VendorDTO vendorDto);

        int Complete();

    }
}
