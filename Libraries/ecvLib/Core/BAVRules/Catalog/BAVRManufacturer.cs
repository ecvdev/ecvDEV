using ecvLib.Core.ecvFunctions;
using System;
using System.Collections.Generic;
using ecvLib.Core.ecvOperationStatus;

//---------------As this is partial class development set namespace same as base class---------------

namespace ecvLib.Core.ecvDomain.Catalog
{
    public partial class Manufacturer : IRuleEntity
    {

        //========> In this class all variable should have [NotMapped] data anotation 
        //========> to prevent field/variable creation in data table      

        //[NotMapped]
        //public string ecvBRMessage = "";

        //[NotMapped]
        //public int ecvBRInvalid = 0;

        public List<ecvRuleViolation> ecvGetRuleViolations()
        {
            List<ecvRuleViolation> validationIssues = new List<ecvRuleViolation>();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {                
                validationIssues.Add(
                    new ecvRuleViolation("Name",Name,"Manufacturer name cannnot be empty.")
                    );
            }

            if (Convert.ToDouble(PriceRanges) > 250)
            {
                validationIssues.Add(
                                    new ecvRuleViolation("PriceRanges", PriceRanges, "PriceRanges cannot be > 250!")
                                    );
            }

            if (AllowCustomersToSelectPageSize.Equals(true))
            {
                PageSize = 10; // set default page size

                if (string.IsNullOrEmpty(PageSizeOptions) || string.IsNullOrWhiteSpace(PageSizeOptions))
                {
                    PageSizeOptions = "10,5,20"; // set default page size options
                }
                else // Check PageSizeOptions has number only
                {
                    bool _resultStringHasOnlyNumber = false;
                    _resultStringHasOnlyNumber = ecvFunctionsCommon.stringHasOnlyNumber(PageSizeOptions, ',');
                    if (_resultStringHasOnlyNumber == false)
                    {
                        validationIssues.Add(
                            new ecvRuleViolation("PageSizeOptions", PageSizeOptions, "Invalid PageSizeOptions! Only number and coma is allowed.")
                            );
                    }
                }

            }// End of -- if (AllowCustomersToSelectPageSize.Equals(true))
            else if (AllowCustomersToSelectPageSize.Equals(false))
            {
                PageSizeOptions = "10,5,20"; // set default page size options
            }           

            return validationIssues;
        }
        //public override Boolean IsValid(Object value)
        //{
        //    return true;
        //}

        //////public bool processBusinessRules()
        //////{

        //////    bool tmpResult = true;

        //////    if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
        //////    {
        //////        if (ecvBRInvalid > 0) ecvBRMessage += System.Environment.NewLine;
        //////        ecvBRMessage += "Manufacturer name cannnot be empty.";
        //////        ecvBRInvalid++;
        //////        tmpResult = false;
        //////    }

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

       

    }// End of -- public partial class BAVRManufacturer

}
