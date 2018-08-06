namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsFeaturedProduct = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.ProductCategory", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategory", new[] { "ProductId" });
            DropTable("dbo.ProductCategory");
        }
    }
}
