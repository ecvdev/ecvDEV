namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufacturerDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manufacturer", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Manufacturer", "MetaKeywords", c => c.String(maxLength: 400));
            AlterColumn("dbo.Manufacturer", "MetaTitle", c => c.String(maxLength: 400));
            AlterColumn("dbo.Manufacturer", "PageSizeOptions", c => c.String(maxLength: 200));
            AlterColumn("dbo.Manufacturer", "PriceRanges", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturer", "PriceRanges", c => c.String());
            AlterColumn("dbo.Manufacturer", "PageSizeOptions", c => c.String());
            AlterColumn("dbo.Manufacturer", "MetaTitle", c => c.String());
            AlterColumn("dbo.Manufacturer", "MetaKeywords", c => c.String());
            AlterColumn("dbo.Manufacturer", "Name", c => c.String());
        }
    }
}
