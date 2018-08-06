namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVendorDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendor", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Vendor", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Vendor", "Email", c => c.String(maxLength: 400));
            AlterColumn("dbo.Vendor", "MetaKeywords", c => c.String(maxLength: 400));
            AlterColumn("dbo.Vendor", "MetaTitle", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendor", "MetaTitle", c => c.String());
            AlterColumn("dbo.Vendor", "MetaKeywords", c => c.String());
            AlterColumn("dbo.Vendor", "Email", c => c.String());
            AlterColumn("dbo.Vendor", "Name", c => c.String());
            AlterColumn("dbo.Vendor", "Code", c => c.String());
        }
    }
}
