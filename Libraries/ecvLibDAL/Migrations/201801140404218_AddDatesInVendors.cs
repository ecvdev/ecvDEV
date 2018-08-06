namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatesInVendors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendor", "CreatedOnUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendor", "UpdatedOnUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendor", "UpdatedOnUtc");
            DropColumn("dbo.Vendor", "CreatedOnUtc");
        }
    }
}
