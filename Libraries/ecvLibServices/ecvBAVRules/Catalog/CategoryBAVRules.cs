using ecvLib.Core.ecvFunctions;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs.Catalog;
using ecvLibServices.ecvServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLibServices.ecvBAVRules.Catalog
{
    // <summary>
    /// This class implements Business And Validation Rules.
    /// </summary>
    public partial class CategoryBAVRules : IRuleEntity
    {
        CategoryDTO _categoryDTO = new CategoryDTO();

        public CategoryBAVRules(CategoryDTO categoryDTO)
        {
            _categoryDTO = categoryDTO;
        }

        public List<ecvRuleViolation> ecvGetRuleViolations()
        {

            List<ecvRuleViolation> validationIssues = new List<ecvRuleViolation>();

            //--
            if (string.IsNullOrEmpty(_categoryDTO.Name) || string.IsNullOrWhiteSpace(_categoryDTO.Name))
            {
                validationIssues.Add(
                                    new ecvRuleViolation("Name", _categoryDTO.Name, "Category name cannnot be empty.")
                                    );
            }

            //--When category is updated check current category does not have it's own categoryid as ParentCategoryId
            if(_categoryDTO.ParentCategoryId == _categoryDTO.Id)
            {
                validationIssues.Add(
                                    new ecvRuleViolation("ParentCategoryId", _categoryDTO.Name, "Cannot assign Category to itself as a Parent Category!")
                                    );
            }

            //--Check Category is not assign to itself in ParentCategoryId hierarchy.
            //_categoryDTO

            //--
            if (_categoryDTO.AllowCustomersToSelectPageSize.Equals(true))
            {
                _categoryDTO.PageSize = 10; // set default page size

                if (string.IsNullOrEmpty(_categoryDTO.PageSizeOptions) || string.IsNullOrWhiteSpace(_categoryDTO.PageSizeOptions))
                {
                    _categoryDTO.PageSizeOptions = "10,5,20"; // set default page size options
                }
                else // Check PageSizeOptions has number only
                {
                    bool _resultStringHasOnlyNumber = false;
                    _resultStringHasOnlyNumber = ecvFunctionsCommon.stringHasOnlyNumber(_categoryDTO.PageSizeOptions, ',');
                    if (_resultStringHasOnlyNumber == false)
                    {
                        validationIssues.Add(
                            new ecvRuleViolation("PageSizeOptions", _categoryDTO.PageSizeOptions, "Invalid PageSizeOptions! Only number and coma is allowed.")
                            );
                    }
                }

            }// End of -- if (AllowCustomersToSelectPageSize.Equals(true))
            else if (_categoryDTO.AllowCustomersToSelectPageSize.Equals(false))
            {
                _categoryDTO.PageSizeOptions = "10,5,20"; // set default page size options
            }

            return validationIssues;

        }// End of -- public List<ecvRuleViolation> ecvGetRuleViolations()

    }// End of -- public partial class CategoryBAVRules
}
