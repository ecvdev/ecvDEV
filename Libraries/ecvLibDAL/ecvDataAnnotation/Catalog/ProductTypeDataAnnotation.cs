using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDAL.ecvEntityConfig;

namespace ecvLibDAL.ecvDataAnnotation.Catalog
{
    public partial class ProductTypeDataAnnotation : ecvEntityTypeConfiguration<ProductType>
    {
        public ProductTypeDataAnnotation()
        {
            this.ToTable("ProductType");
            this.HasKey(p => p.Id);
            this.Property(p => p.Description).HasMaxLength(10);
        }
    }
}
