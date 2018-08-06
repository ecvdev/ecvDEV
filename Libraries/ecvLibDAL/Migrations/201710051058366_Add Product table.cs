namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProducttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                        ParentGroupedProductId = c.Int(nullable: false),
                        VisibleIndividually = c.Boolean(nullable: false),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        FullDescription = c.String(),
                        AdminComment = c.String(),
                        ProductTemplateId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(),
                        AllowCustomerReviews = c.Boolean(nullable: false),
                        ApprovedRatingSum = c.Int(nullable: false),
                        NotApprovedRatingSum = c.Int(nullable: false),
                        ApprovedTotalReviews = c.Int(nullable: false),
                        NotApprovedTotalReviews = c.Int(nullable: false),
                        SubjectToAcl = c.Boolean(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        Sku = c.String(),
                        ManufacturerPartNumber = c.String(),
                        Gtin = c.String(),
                        IsGiftCard = c.Boolean(nullable: false),
                        GiftCardTypeId = c.Int(nullable: false),
                        RequireOtherProducts = c.Boolean(nullable: false),
                        IsRental = c.Boolean(nullable: false),
                        RentalPriceLength = c.Int(nullable: false),
                        RentalPricePeriodId = c.Int(nullable: false),
                        IsShipEnabled = c.Boolean(nullable: false),
                        IsFreeShipping = c.Boolean(nullable: false),
                        ShipSeparately = c.Boolean(nullable: false),
                        AdditionalShippingCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDateId = c.Int(nullable: false),
                        IsTaxExempt = c.Boolean(nullable: false),
                        TaxCategoryId = c.Int(nullable: false),
                        ManageInventoryMethodId = c.Int(nullable: false),
                        ProductAvailabilityRangeId = c.Int(nullable: false),
                        UseMultipleWarehouses = c.Boolean(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        StockQuantity = c.Int(nullable: false),
                        DisplayStockAvailability = c.Boolean(nullable: false),
                        DisplayStockQuantity = c.Boolean(nullable: false),
                        MinStockQuantity = c.Int(nullable: false),
                        LowStockActivityId = c.Int(nullable: false),
                        NotifyAdminForQuantityBelow = c.Int(nullable: false),
                        OrderMinimumQuantity = c.Int(nullable: false),
                        OrderMaximumQuantity = c.Int(nullable: false),
                        NotReturnable = c.Boolean(nullable: false),
                        DisableBuyButton = c.Boolean(nullable: false),
                        DisableWishlistButton = c.Boolean(nullable: false),
                        AvailableForPreOrder = c.Boolean(nullable: false),
                        PreOrderAvailabilityStartDateTimeUtc = c.DateTime(),
                        CallForPrice = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerEntersPrice = c.Boolean(nullable: false),
                        MinimumCustomerEnteredPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumCustomerEnteredPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarkAsNew = c.Boolean(nullable: false),
                        MarkAsNewStartDateTimeUtc = c.DateTime(),
                        MarkAsNewEndDateTimeUtc = c.DateTime(),
                        HasTierPrices = c.Boolean(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableStartDateTimeUtc = c.DateTime(),
                        AvailableEndDateTimeUtc = c.DateTime(),
                        DisplayOrder = c.Int(nullable: false),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
        }
    }
}
