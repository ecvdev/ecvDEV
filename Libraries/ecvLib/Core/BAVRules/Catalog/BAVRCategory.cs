using ecvLib.Core.ecvFunctions;
using ecvLib.Core.ecvOperationStatus;
using System.Collections.Generic;

namespace ecvLib.Core.ecvDomain.Catalog
{
    public partial class CategoryAA 
    {
        //========> In this class all variable should have [NotMapped] data anotation 
        //========> to prevent field/variable creation in data table      
        //////public List<ecvRuleViolation> ecvGetRuleViolations()
        //////{
        //////    List<ecvRuleViolation> validationIssues = new List<ecvRuleViolation>();

        //////    if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
        //////    {
        //////        validationIssues.Add(
        //////                            new ecvRuleViolation("Name", Name, "Category name cannnot be empty.")
        //////                            );               
        //////    }

        //////    if(AllowCustomersToSelectPageSize.Equals(true))
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
        //////                validationIssues.Add(
        //////                    new ecvRuleViolation("PageSizeOptions", PageSizeOptions, "Invalid PageSizeOptions! Only number and coma is allowed.")
        //////                    );
        //////            }
        //////        }

        //////    }// End of -- if (AllowCustomersToSelectPageSize.Equals(true))
        //////    else if (AllowCustomersToSelectPageSize.Equals(false))
        //////    {
        //////        PageSizeOptions = "10,5,20"; // set default page size options
        //////    }

        //////    return validationIssues;
        //////}

    }// End of --  public partial class BAVRCategory
}