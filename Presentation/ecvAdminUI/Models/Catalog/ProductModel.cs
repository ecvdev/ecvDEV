using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ecvAdminUI.Models.Catalog
{
    public partial class ProductModel : ProductDTO
    {
        public ProductModel()
        {
            productCategoryModel = new List<ProductCategoryModel>();
        }

        //////private ICollection<ProductCategoryModel> _productCategories;
        //////private ICollection<ProductManufacturer> _productManufacturers;
        //////private ICollection<ProductPicture> _productPictures;
        //////private ICollection<ProductReview> _productReviews;
        //////private ICollection<ProductTag> _productTags;
        //////private ICollection<ProductAttributeMapping> _productAttributeMappings;
        //////private ICollection<ProductAttributeCombination> _productAttributeCombinations;
        //////private ICollection<TierPrice> _tierPrices;
        //////private ICollection<Discount> _appliedDiscounts;
        //////private ICollection<ProductWarehouseInventory> _productWarehouseInventory;


        /// <summary>
        /// Gets or sets the product type identifier
        /// </summary>        
        [DisplayName("Product type")]
        public override int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
        /// </summary>
        [DisplayName("Parent grouped product")]
        public override int ParentGroupedProductId { get; set; }

        /// <summary>
        /// Gets or sets the parent product name. It's used to identify associated products (only with "grouped" products)
        /// </summary>
        [DisplayName("Associated To Product")]
        public override string AssociatedToProductName { get; set; }

        /// <summary>
        /// Gets or sets the values indicating whether this product is visible in catalog or search results.
        /// It's used when this product is associated to some "grouped" one
        /// This way associated products could be accessed/added/etc only from a grouped product details page
        /// </summary>
        [DisplayName("Visible individually")]
        public override bool VisibleIndividually { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product name cannnot be empty.")]
        public override string Name { get; set; }
        /// <summary>
        /// Gets or sets the short description
        /// </summary>
        [DisplayName("Short description")]
        public override string ShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the full description
        /// </summary>
        [AllowHtml]
        [DisplayName("Full description")]
        public override string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        [DisplayName("Admin comment")]
        public override string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets a value of used product template identifier
        /// </summary>
        [DisplayName("Product template")]
        public override int ProductTemplateId { get; set; }

        /// <summary>
        /// Gets or sets a vendor identifier
        /// </summary>
        [DisplayName("Vendor")]
        public override int VendorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show the product on home page
        /// </summary>
        [DisplayName("Show on home page")]
        public override bool ShowOnHomePage { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        [DisplayName("Meta key words")]
        public override string MetaKeywords { get; set; }
        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        [DisplayName("Meta Description")]
        public override string MetaDescription { get; set; }
        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        [DisplayName("Meta Title")]
        public override string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product allows customer reviews
        /// </summary>
        [DisplayName("Allow customer reviews")]
        public override bool AllowCustomerReviews { get; set; }
        /// <summary>
        /// Gets or sets the rating sum (approved reviews)
        /// </summary>
        [DisplayName("Approved rating sum")]
        public override int ApprovedRatingSum { get; set; }
        /// <summary>
        /// Gets or sets the rating sum (not approved reviews)
        /// </summary>
        [DisplayName("Not approved rating sum")]
        public override int NotApprovedRatingSum { get; set; }
        /// <summary>
        /// Gets or sets the total rating votes (approved reviews)
        /// </summary>
        [DisplayName("Approved total reviews")]
        public override int ApprovedTotalReviews { get; set; }
        /// <summary>
        /// Gets or sets the total rating votes (not approved reviews)
        /// </summary>
        [DisplayName("Not approved total reviews")]
        public override int NotApprovedTotalReviews { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is subject to ACL
        /// </summary>
        [DisplayName("Subject To Acl")]
        public override bool SubjectToAcl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        [DisplayName("Limited to stores")]
        public override bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the SKU
        /// </summary>
        [DisplayName("SKU")]
        public override string Sku { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer part number
        /// </summary>
        [DisplayName("Manufacturer part number")]
        public override string ManufacturerPartNumber { get; set; }
        /// <summary>
        /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// </summary>
        [DisplayName("GTIN(global trade item number)")]
        public override string Gtin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is gift card
        /// </summary>
        [DisplayName("Is gift card")]
        public override bool IsGiftCard { get; set; }
        /// <summary>
        /// Gets or sets the gift card type identifier
        /// </summary>
        [DisplayName("Gift card type")]
        public override int GiftCardTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
        /// </summary>
        [DisplayName("Require other products")]
        public override bool RequireOtherProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is rental
        /// </summary>
        [DisplayName("Is rental")]
        public override  bool IsRental { get; set; }
        /// <summary>
        /// Gets or sets the rental length for some period (price for this period)
        /// </summary>
        [DisplayName("Rental price length")]
        public override  int RentalPriceLength { get; set; }
        /// <summary>
        /// Gets or sets the rental period (price for this period)
        /// </summary>
        [DisplayName("Rental price period")]
        public override  int RentalPricePeriodId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is ship enabled
        /// </summary>
        [DisplayName("Is ship enabled")]
        public override  bool IsShipEnabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is free shipping
        /// </summary>
        [DisplayName("Is free shipping")]
        public override  bool IsFreeShipping { get; set; }
        /// <summary>
        /// Gets or sets a value this product should be shipped separately (each item)
        /// </summary>
        [DisplayName("Ship separately")]
        public override  bool ShipSeparately { get; set; }
        /// <summary>
        /// Gets or sets the additional shipping charge
        /// </summary>
        [DisplayName("Additional shipping charge")]
        public override  decimal AdditionalShippingCharge { get; set; }
        /// <summary>
        /// Gets or sets a delivery date identifier
        /// </summary>
        [DisplayName("Delivery date")]
        public override  int DeliveryDateId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is marked as tax exempt
        /// </summary>
        [DisplayName("Is tax exempt")]
        public override  bool IsTaxExempt { get; set; }
        /// <summary>
        /// Gets or sets the tax category identifier
        /// </summary>
        [DisplayName("Tax category")]
        public override  int TaxCategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how to manage inventory
        /// </summary>
        [DisplayName("Manage inventory method")]
        public override  int ManageInventoryMethodId { get; set; }
        /// <summary>
        /// Gets or sets a product availability range identifier
        /// </summary>
        [DisplayName("Product availability range")]
        public override  int ProductAvailabilityRangeId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether multiple warehouses are used for this product
        /// </summary>
        [DisplayName("Use multiple warehouses")]
        public override  bool UseMultipleWarehouses { get; set; }
        /// <summary>
        /// Gets or sets a warehouse identifier
        /// </summary>
        [DisplayName("Warehouse")]
        public override  int WarehouseId { get; set; }
        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
        [DisplayName("Stock quantity")]
        public override  int StockQuantity { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock availability
        /// </summary>
        [DisplayName("Display stock availability")]
        public override  bool DisplayStockAvailability { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock quantity
        /// </summary>
        [DisplayName("Display stock quantity")]
        public override  bool DisplayStockQuantity { get; set; }
        /// <summary>
        /// Gets or sets the minimum stock quantity
        /// </summary>
        [DisplayName("Min stock quantity")]
        public override  int MinStockQuantity { get; set; }
        /// <summary>
        /// Gets or sets the low stock activity identifier
        /// </summary>
        [DisplayName("Low stock activity")]
        public override  int LowStockActivityId { get; set; }
        /// <summary>
        /// Gets or sets the quantity when admin should be notified
        /// </summary>
        [DisplayName("Notify admin for quantity below")]
        public override  int NotifyAdminForQuantityBelow { get; set; }

        /// <summary>
        /// Gets or sets the order minimum quantity
        /// </summary>
        [DisplayName("Order minimum quantity")]
        public override  int OrderMinimumQuantity { get; set; }
        /// <summary>
        /// Gets or sets the order maximum quantity
        /// </summary>
        [DisplayName("Order maximum quantity")]
        public override  int OrderMaximumQuantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
        /// </summary>
        [DisplayName("Not returnable")]
        public override  bool NotReturnable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable buy (Add to cart) button
        /// </summary>
        [DisplayName("Disable buy button")]
        public override  bool DisableBuyButton { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to disable "Add to wishlist" button
        /// </summary>
        [DisplayName("Disable wishlist button")]
        public override  bool DisableWishlistButton { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this item is available for Pre-Order
        /// </summary>
        [DisplayName("Available for PreOrder")]
        public override  bool AvailableForPreOrder { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the product availability (for pre-order products)
        /// </summary>
        [DisplayName("PreOrder availability start date")]
        public override  DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// </summary>
        [DisplayName("Call for price")]
        public override  bool CallForPrice { get; set; }
        /// <summary>
        /// Gets or sets the price
        /// </summary>
        [DisplayName("Price")]
        public override  decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the old price
        /// </summary>
        [DisplayName("Old price")]
        public override  decimal OldPrice { get; set; }
        /// <summary>
        /// Gets or sets the product cost
        /// </summary>
        [DisplayName("Product cost")]
        public override  decimal ProductCost { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether a customer enters price
        /// </summary>
        [DisplayName("Customer enters price")]
        public override  bool CustomerEntersPrice { get; set; }
        /// <summary>
        /// Gets or sets the minimum price entered by a customer
        /// </summary>
        [DisplayName("Minimum amount")]
        public override  decimal MinimumCustomerEnteredPrice { get; set; }
        /// <summary>
        /// Gets or sets the maximum price entered by a customer
        /// </summary>
        [DisplayName("Maximum amount")]
        public override  decimal MaximumCustomerEnteredPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this product is marked as new
        /// </summary>
        [DisplayName("Mark as new")]
        public override  bool MarkAsNew { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
        /// </summary>
        [DisplayName("Mark as new start date")]
        [ecvDataAnnotation.ecvCompareDates]
        public override  DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
        /// </summary>
        [DisplayName("Mark as new end date")]
        public override  DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this product has tier prices configured
        /// <remarks>The same as if we run this.TierPrices.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load tier prices navigation property
        /// </remarks>
        /// </summary>
        [DisplayName("Has tier prices")]
        public override  bool HasTierPrices { get; set; }

        /// <summary>
        /// Gets or sets the weight
        /// </summary>
        [DisplayName("Weight")]
        public override  decimal Weight { get; set; }
        /// <summary>
        /// Gets or sets the length
        /// </summary>
        [DisplayName("Length")]
        public override  decimal Length { get; set; }
        /// <summary>
        /// Gets or sets the width
        /// </summary>
        [DisplayName("Width")]
        public override  decimal Width { get; set; }
        /// <summary>
        /// Gets or sets the height
        /// </summary>
        [DisplayName("Height")]
        public override  decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the available start date and time
        /// </summary>
        [DisplayName("Available start date")]
        public override  DateTime? AvailableStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the available end date and time
        /// </summary>
        [DisplayName("Available end date")]
        public override  DateTime? AvailableEndDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets a display order.
        /// This value is used when sorting associated products (used with "grouped" products)
        /// This value is used when sorting home page products
        /// </summary>
        [DisplayName("Display order")]
        public override  int DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        [DisplayName("Published")]
        public override  bool Published { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        [DisplayName("Deleted")]
        public override  bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product creation
        /// </summary>
        [DisplayName("Created")]
        public override  DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
        [DisplayName("Updated")]
        public override  DateTime UpdatedOnUtc { get; set; }


        /// <summary>
        /// Gets or sets the collection of ProductCategoryModel
        /// </summary>
        //public override  virtual ICollection<ProductCategoryModel> ProductCategories
        //{
        //    get { return _productCategories ?? (_productCategories = new List<ProductCategoryModel>()); }
        //    protected set { _productCategories = value; }
        //}

        public  IList<ProductCategoryModel> productCategoryModel { get; set; }

    }// End of -- public partial class ProductModel : ecvAdminEntityModel
}