using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDAL.ecvEntityConfig;

namespace ecvLibDAL.ecvDataAnnotation.Catalog
{
    public partial class ProductDataAnnotation : ecvEntityTypeConfiguration<Product>
    {

        public ProductDataAnnotation()
        {
            this.ToTable("Product");
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).IsRequired().HasMaxLength(400);
            this.Property(p => p.MetaKeywords).HasMaxLength(400);
            this.Property(p => p.MetaTitle).HasMaxLength(400);
            this.Property(p => p.Sku).HasMaxLength(400);
            this.Property(p => p.ManufacturerPartNumber).HasMaxLength(400);
            this.Property(p => p.Gtin).HasMaxLength(400);
            this.Property(p => p.AdditionalShippingCharge).HasPrecision(18, 4);
            this.Property(p => p.Price).HasPrecision(18, 4);
            this.Property(p => p.OldPrice).HasPrecision(18, 4);
            this.Property(p => p.ProductCost).HasPrecision(18, 4);
            this.Property(p => p.MinimumCustomerEnteredPrice).HasPrecision(18, 4);
            this.Property(p => p.MaximumCustomerEnteredPrice).HasPrecision(18, 4);
            this.Property(p => p.Weight).HasPrecision(18, 4);
            this.Property(p => p.Length).HasPrecision(18, 4);
            this.Property(p => p.Width).HasPrecision(18, 4);
            this.Property(p => p.Height).HasPrecision(18, 4);


            //this.HasMany(p => p.ProductTags)
            //    .WithMany(pt => pt.Products)
            //    .Map(m => m.ToTable("Product_ProductTag_Mapping"));
        }

    }// End of -- public partial class ProductDataAnnotation
}
