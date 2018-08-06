namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVendorEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        PictureId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        AdminComment = c.String(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(),
                        PageSize = c.Int(nullable: false),
                        AllowCustomersToSelectPageSize = c.Boolean(nullable: false),
                        PageSizeOptions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendor");
        }
    }
}
