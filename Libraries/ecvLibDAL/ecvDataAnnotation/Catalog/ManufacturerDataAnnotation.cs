using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDAL.ecvEntityConfig;

namespace ecvLibDAL.ecvDataAnnotation.Catalog
{
    public partial class ManufacturerDataAnnotation : ecvEntityTypeConfiguration<Manufacturer>
    {

        public ManufacturerDataAnnotation()
        {
            this.ToTable("Manufacturer");
            this.HasKey(m => m.Id);
            this.Property(m => m.Name).IsRequired().HasMaxLength(400);
            this.Property(m => m.MetaKeywords).HasMaxLength(400);
            this.Property(m => m.MetaTitle).HasMaxLength(400);
            this.Property(m => m.PriceRanges).HasMaxLength(400);
            this.Property(m => m.PageSizeOptions).HasMaxLength(200);
        }

    }// End of -- public partial class ManufacturerDataAnnotation
}
