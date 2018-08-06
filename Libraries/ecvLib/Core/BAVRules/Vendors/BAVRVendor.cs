using ecvLib.Core.ecvFunctions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecvLib.Core.ecvDomain.Vendors
{
    public partial class VendorAA
    {
        //========> In this class all variable should have [NotMapped] data anotation 
        //========> to prevent field/variable creation in data table            

        //////[NotMapped]
        //////public string ecvBRMessage = "";

        //////[NotMapped]
        //////public int ecvBRInvalid = 0;

        //////public bool processBusinessRules()
        //////{

        //////    bool tmpResult = true; ;

        //////    if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
        //////    {
        //////        if (ecvBRInvalid > 0) ecvBRMessage += System.Environment.NewLine;
        //////        ecvBRMessage += "Vendor name cannnot be empty.";
        //////        ecvBRInvalid++;
        //////        tmpResult = false;
        //////    }

        //////    //if (string.IsNullOrEmpty(Code) || string.IsNullOrWhiteSpace(Code))
        //////    //{
        //////    //    if (ecvBRInvalid > 0) ecvBRMessage += System.Environment.NewLine;
        //////    //    ecvBRMessage += "Vendor code cannnot be empty.";
        //////    //    ecvBRInvalid++;
        //////    //    tmpResult = false;
        //////    //}

        //////    if (AllowCustomersToSelectPageSize.Equals(true))
        //////    {
        //////        PageSize = 10; // set default page size

        //////        if (string.IsNullOrEmpty(PageSizeOptions) || string.IsNullOrWhiteSpace(PageSizeOptions))
        //////        {
        //////            PageSizeOptions = "10,5,20"; // set default page size options
        //////        }
        //////        else // Check PageSizeOptions has number only
        //////        {
        //////            bool _resultStringHasOnlyNumber = false;
        //////            _resultStringHasOnlyNumber = ecvFunctionsCommon.stringHasOnlyNumber(PageSizeOptions, ',');
        //////            if (_resultStringHasOnlyNumber == false)
        //////            {
        //////                if (ecvBRInvalid > 0) ecvBRMessage += System.Environment.NewLine;
        //////                ecvBRMessage += "Invalid PageSizeOptions! Only number and coma is allowed.";
        //////                ecvBRInvalid++;
        //////                tmpResult = false;
        //////            }
        //////        }

        //////    }// End of -- if (AllowCustomersToSelectPageSize.Equals(true))
        //////    else if (AllowCustomersToSelectPageSize.Equals(false))
        //////    {
        //////        PageSizeOptions = "10,5,20"; // set default page size options
        //////    }

        //////    return tmpResult;

        //////}// End of -- public bool processBusinessRules()

    }// End of -- public partial class Vendor
}
