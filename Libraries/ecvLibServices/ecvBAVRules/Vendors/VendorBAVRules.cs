using ecvLib.Core.ecvFunctions;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs.Vendor;
using System.Collections.Generic;

namespace ecvLibServices.ecvBAVRules.Vendors
{
    /// <summary>
    /// This class implements Business And Validation Rules.
    /// </summary>
    public partial class VendorBAVRules : IRuleEntity
    {
        VendorDTO _vendorDTO = new VendorDTO();

        public VendorBAVRules(VendorDTO vendorDTO)
        {
            _vendorDTO = vendorDTO;
        }

        public List<ecvRuleViolation> ecvGetRuleViolations()
        {
            List<ecvRuleViolation> validationIssues = new List<ecvRuleViolation>();

            //--
            if (string.IsNullOrEmpty(_vendorDTO.Code) || string.IsNullOrWhiteSpace(_vendorDTO.Code))
            {
                validationIssues.Add(
                                    new ecvRuleViolation("Code", _vendorDTO.Code, "Vendor code cannnot be empty.")
                                    );
            }

            //--
            if (string.IsNullOrEmpty(_vendorDTO.Name) || string.IsNullOrWhiteSpace(_vendorDTO.Name))
            {
                validationIssues.Add(
                                    new ecvRuleViolation("Name", _vendorDTO.Name, "Vendor name cannnot be empty.")
                                    );
            }

            //--
            if (_vendorDTO.AllowCustomersToSelectPageSize.Equals(true))
            {
                _vendorDTO.PageSize = 10; // set default page size

                if (string.IsNullOrEmpty(_vendorDTO.PageSizeOptions) || string.IsNullOrWhiteSpace(_vendorDTO.PageSizeOptions))
                {
                    _vendorDTO.PageSizeOptions = "10,5,20"; // set default page size options
                }
                else // Check PageSizeOptions has number only
                {
                    bool _resultStringHasOnlyNumber = false;
                    _resultStringHasOnlyNumber = ecvFunctionsCommon.stringHasOnlyNumber(_vendorDTO.PageSizeOptions, ',');
                    if (_resultStringHasOnlyNumber == false)
                    {                        
                        validationIssues.Add(
                                            new ecvRuleViolation("PageSizeOptions", _vendorDTO.PageSizeOptions, "**Invalid PageSizeOptions! Only number and coma is allowed.")
                                            );

                    }
                }

            }// End of -- if (AllowCustomersToSelectPageSize.Equals(true))
            else if (_vendorDTO.AllowCustomersToSelectPageSize.Equals(false))
            {
                _vendorDTO.PageSizeOptions = "10,5,20"; // set default page size options
            }


            return validationIssues;
        }

    }// End of -- public partial class VendorService : IRuleEntity
}
