using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDAL.ecvEntityConfig;

namespace ecvLibDAL.ecvDataAnnotation.Catalog
{
    public partial class CategoryDataAnnotation : ecvEntityTypeConfiguration<Category>
    {

        public CategoryDataAnnotation()
        {
            this.ToTable("Category");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(400);
            this.Property(c => c.MetaKeywords).HasMaxLength(400);
            this.Property(c => c.MetaTitle).HasMaxLength(400);
            this.Property(c => c.PriceRanges).HasMaxLength(400);
            this.Property(c => c.PageSizeOptions).HasMaxLength(200);
        }

    } // End of -- public partial class CatagoryDataAnnotation
}
