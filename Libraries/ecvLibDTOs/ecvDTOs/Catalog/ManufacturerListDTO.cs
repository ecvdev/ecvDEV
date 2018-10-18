namespace ecvLibDTOs.ecvDTOs.Catalog
{
    public partial class ManufacturerListDTO : ecvDTOentity
    {
        public virtual string Name { get; set; }
        public virtual bool Published { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual bool Deleted { get; set; }

    }// End of -- public partial class ManufacturerDTO : ecvDTOentity
}
