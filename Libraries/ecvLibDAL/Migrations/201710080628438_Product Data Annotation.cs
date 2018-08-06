namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Product", "MetaKeywords", c => c.String(maxLength: 400));
            AlterColumn("dbo.Product", "MetaTitle", c => c.String(maxLength: 400));
            AlterColumn("dbo.Product", "Sku", c => c.String(maxLength: 400));
            AlterColumn("dbo.Product", "ManufacturerPartNumber", c => c.String(maxLength: 400));
            AlterColumn("dbo.Product", "Gtin", c => c.String(maxLength: 400));
            AlterColumn("dbo.Product", "AdditionalShippingCharge", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "OldPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "ProductCost", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "MinimumCustomerEnteredPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "MaximumCustomerEnteredPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Length", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Width", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Width", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Length", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "MaximumCustomerEnteredPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "MinimumCustomerEnteredPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "ProductCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "OldPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "AdditionalShippingCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Gtin", c => c.String());
            AlterColumn("dbo.Product", "ManufacturerPartNumber", c => c.String());
            AlterColumn("dbo.Product", "Sku", c => c.String());
            AlterColumn("dbo.Product", "MetaTitle", c => c.String());
            AlterColumn("dbo.Product", "MetaKeywords", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
        }
    }
}
