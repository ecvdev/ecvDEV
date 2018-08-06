namespace ecvLibDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Category", "MetaKeywords", c => c.String(maxLength: 400));
            AlterColumn("dbo.Category", "MetaTitle", c => c.String(maxLength: 400));
            AlterColumn("dbo.Category", "PageSizeOptions", c => c.String(maxLength: 200));
            AlterColumn("dbo.Category", "PriceRanges", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "PriceRanges", c => c.String());
            AlterColumn("dbo.Category", "PageSizeOptions", c => c.String());
            AlterColumn("dbo.Category", "MetaTitle", c => c.String());
            AlterColumn("dbo.Category", "MetaKeywords", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String());
        }
    }
}
