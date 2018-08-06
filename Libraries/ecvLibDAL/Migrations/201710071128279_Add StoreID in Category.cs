namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreIDinCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "StoreID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "StoreID");
        }
    }
}
