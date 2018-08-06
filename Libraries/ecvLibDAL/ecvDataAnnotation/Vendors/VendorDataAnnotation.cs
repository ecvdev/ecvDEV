using ecvLib.Core.ecvDomain.Vendors;
using ecvLibDAL.ecvEntityConfig;

namespace ecvLibDAL.ecvDataAnnotation.Vendors
{
    public partial class VendorDataAnnotation : ecvEntityTypeConfiguration<Vendor>
    {
        public VendorDataAnnotation()
        {
            this.ToTable("Vendor");
            this.HasKey(v => v.Id);
            this.Property(v => v.Code).IsRequired().HasMaxLength(10);
            this.Property(v => v.Name).IsRequired().HasMaxLength(400);
            this.Property(v => v.Email).HasMaxLength(400);
            this.Property(v => v.MetaKeywords).HasMaxLength(400);
            this.Property(v => v.MetaTitle).HasMaxLength(400);
        }
        

    }// End of -- public partial class VendorDataAnnotation 
}
