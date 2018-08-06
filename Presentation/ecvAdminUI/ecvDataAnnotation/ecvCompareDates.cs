using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecvAdminUI.ecvDataAnnotation
{
    public sealed class ecvCompareDates : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime _birthJoin = Convert.ToDateTime(value);
                if (_birthJoin > DateTime.Now)
                {
                    return new ValidationResult("Start date can not be greater than current date.");
                }
            }
            return ValidationResult.Success;
        }


        ////public string OtherPropertyName { get; private set; }
        ////public ecvCompareDates(string otherPropertyName, bool otherPropertyCanBeNullOrEmpty, string errorMessage = null)
        ////    : base(errorMessage)
        ////{
        ////    this.OtherPropertyName = otherPropertyName;
        ////}



        ////protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        ////{
        ////    ValidationResult validationResult = ValidationResult.Success;
        ////    var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.OtherPropertyName);

        ////    //if(otherPropertyInfo.v)
        ////    // Let's check that otherProperty is of type DateTime as we expect it to be
        ////    if (otherPropertyInfo.PropertyType.Equals(new DateTime().GetType()))
        ////    {
        ////        //--Get current property value
        ////        DateTime toValidate = (DateTime)value;

        ////        DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        ////        // if the end date is lower than the start date, than the validationResult will be set to false and return
        ////        // a properly formatted error message
        ////        if (toValidate.CompareTo(referenceProperty) < 1)
        ////        {
        ////            validationResult = new ValidationResult(this.GetErrorMessage(validationContext));
        ////        }

        ////    }

        ////    return base.IsValid(value, validationContext);
        ////}

        ////private string GetErrorMessage(ValidationContext validationContext)
        ////{
        ////    if (!string.IsNullOrEmpty(this.ErrorMessage))
        ////        return this.ErrorMessage;
        ////    else
        ////    {
        ////        var thisPropName = !string.IsNullOrEmpty(validationContext.DisplayName) ? validationContext.DisplayName : validationContext.MemberName;
        ////        var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.OtherPropertyName);
        ////        var otherPropName = otherPropertyInfo.Name;
        ////        // Check to see if there is a Displayname attribute and use that to build the message instead of the property name
        ////        var displayNameAttrs = otherPropertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
        ////        if (displayNameAttrs.Length > 0)
        ////            otherPropName = ((DisplayNameAttribute)displayNameAttrs[0]).DisplayName;

        ////        return string.Format("{0} must be on or after {1}", thisPropName, otherPropName);
        ////    }
        ////}

        ////public override string FormatErrorMessage(string name)
        ////{
        ////    return "must be greater than " + OtherPropertyName;
        ////}

        ////public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        ////{
        ////    //string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
        ////    string errorMessage = ErrorMessageString;

        ////    // The value we set here are needed by the jQuery adapter
        ////    ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
        ////    dateGreaterThanRule.ErrorMessage = errorMessage;
        ////    dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery adapter will use
        ////                                                            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
        ////    dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", OtherPropertyName);

        ////    yield return dateGreaterThanRule;
        ////}

    }// End of -- public class ecvCompareDates
}