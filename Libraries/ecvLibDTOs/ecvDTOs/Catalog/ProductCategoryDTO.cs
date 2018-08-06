namespace ecvLibDTOs.ecvDTOs.Catalog
{
    public partial class ProductCategoryDTO : ecvDTOentity
    {

        /// <summary>
        /// Gets or sets the product type identifier
        /// </summary>
        public virtual int StoreID { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public virtual int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the category identifier
        /// </summary>
        public virtual int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is featured
        /// </summary>
        public virtual bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// Gets the category
        /// </summary>
        public virtual CategoryDTO CategoryDTO { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        public virtual ProductDTO ProductDTO { get; set; }

    }// End of -- public partial class ProductCategoryDTO : ecvDTOentity
}
