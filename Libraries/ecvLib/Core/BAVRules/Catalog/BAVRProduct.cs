using System.Collections.Generic;
using ecvLib.Core.ecvOperationStatus;

//---------------As this is partial class development set namespace same as base class---------------

namespace ecvLib.Core.ecvDomain.Catalog
{
    public partial class Product : IRuleEntity
    {
        //========> In this class all variable should have [NotMapped] data anotation 
        //========> to prevent field/variable creation in data table              

        public List<ecvRuleViolation> ecvGetRuleViolations()
        {
            List<ecvRuleViolation> validationIssues = new List<ecvRuleViolation>();

            //-----
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                validationIssues.Add(
                                    new ecvRuleViolation("Name", Name, "Product name cannnot be empty.")
                                    );
            }

            //-----
            if (ShowOnHomePage.Equals(false))
            {
                DisplayOrder = 0;
            }

            //-----
            if (MarkAsNew.Equals(true))
            {
                if (MarkAsNewStartDateTimeUtc.Equals(null) || string.IsNullOrEmpty(MarkAsNewStartDateTimeUtc.ToString()) || string.IsNullOrWhiteSpace(MarkAsNewStartDateTimeUtc.ToString()))
                {
                    validationIssues.Add(
                                    new ecvRuleViolation("MarkAsNewStartDateTimeUtc", MarkAsNewStartDateTimeUtc, "MarkAsNewStartDateTimeUtc cannnot be empty.")
                                    );                    
                }

                //----As "MarkAsNewEndDateTimeUtc" can be empty or null below codes are commented
                //if (MarkAsNewEndDateTimeUtc.Equals(null) || string.IsNullOrEmpty(MarkAsNewEndDateTimeUtc.ToString()) || string.IsNullOrWhiteSpace(MarkAsNewEndDateTimeUtc.ToString()))
                //{
                //    ecvErrorMessage = "MarkAsNewEndDateTimeUtc cannnot be empty.";
                //    return false;
                //}

                //-----Below code not required at this stage
                //if (MarkAsNewStartDateTimeUtc >= MarkAsNewEndDateTimeUtc)
                //{
                //    ecvErrorMessage = "MarkAsNewStartDateTimeUtc must be less than MarkAsNewEndDateTimeUtc.";
                //    return false;
                //}

            }
            else if (MarkAsNew.Equals(false))
            {
                MarkAsNewStartDateTimeUtc = null;
                MarkAsNewEndDateTimeUtc = null;
            }

            //-----
            if (IsGiftCard.Equals(false))
            {
                GiftCardTypeId = 0;
            }
            else if (IsGiftCard.Equals(true))
            {
                if (GiftCardTypeId < 1)
                {

                    validationIssues.Add(
                                    new ecvRuleViolation("GiftCardTypeId", GiftCardTypeId, "Giftcard type selection is invalid!")
                                    );                    
                }
            }

            //-----
            if (IsRental.Equals(false))
            {
                RentalPriceLength = 0;
                RentalPricePeriodId = 0;
            }
            else if (IsRental.Equals(true))
            {
                if (RentalPriceLength < 1)
                {
                    validationIssues.Add(
                                         new ecvRuleViolation("RentalPriceLength", RentalPriceLength, "RentalPriceLength is invalid!")
                                         );
                }

                if (RentalPricePeriodId < 1)
                {
                    validationIssues.Add(
                                         new ecvRuleViolation("RentalPricePeriodId", RentalPricePeriodId, "RentalPricePeriod is invalid!")
                                         );                    
                }
            }

            //-----
            if (AvailableForPreOrder.Equals(false))
            {
                PreOrderAvailabilityStartDateTimeUtc = null;
            }

            //-----
            if (CustomerEntersPrice.Equals(false))
            {
                MinimumCustomerEnteredPrice = 0;
                MaximumCustomerEnteredPrice = 0;
            }
            else if (CustomerEntersPrice.Equals(true))
            {
                if (MinimumCustomerEnteredPrice > MaximumCustomerEnteredPrice || MinimumCustomerEnteredPrice == MaximumCustomerEnteredPrice)
                {
                    validationIssues.Add(
                                         new ecvRuleViolation("CustomerEntersPrice", CustomerEntersPrice, "Customer enters price has invalid range!")
                                         );
                }
            }

            //-----
            if (IsTaxExempt.Equals(true))
            {
                TaxCategoryId = 0;
            }
            else if (IsTaxExempt.Equals(false))
            {
                if (TaxCategoryId < 1)
                {
                    validationIssues.Add(
                                         new ecvRuleViolation("TaxCategoryId", TaxCategoryId, "Tax category is invalid!")
                                         );
                }
            }

            //-----
            if (ManageInventoryMethodId != 1)
            {
                StockQuantity = 0;
                UseMultipleWarehouses = false;
                DisplayStockAvailability = false;
                DisplayStockQuantity = false;
                MinStockQuantity = 0;
                LowStockActivityId = 0;
                NotifyAdminForQuantityBelow = 0;
                ProductAvailabilityRangeId = 0;
            }

            //-----
            if (DisplayStockAvailability.Equals(false))
            {
                DisplayStockQuantity = false;
            }

            //-----
            if (IsShipEnabled.Equals(false))
            {
                IsFreeShipping = false;
                ShipSeparately = false;
                AdditionalShippingCharge = 0;
                DeliveryDateId = 0;
            }

            return validationIssues;

        } // End of -- public List<ecvRuleViolation>
       
    }// End of -- public class BAVRProduct 
}
