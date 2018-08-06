using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDAL.ecvEntityConfig;

namespace ecvLibDAL.ecvDataAnnotation.Catalog
{
    public partial class ProductCategoryDataAnnotation : ecvEntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryDataAnnotation()
        {
            this.ToTable("ProductCategory");
            this.HasKey(pc => pc.Id);

            this.HasRequired(pc => pc.Category)
                .WithMany()
                .HasForeignKey(pc => pc.CategoryId);


            this.HasRequired(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
        }
    }
}
