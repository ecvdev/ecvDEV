using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ecvLibDTOs.ecvDTOs.Catalog
{
    public partial class ProductListDTO : ecvDTOentity
    {
        /// <summary>
        /// Gets or sets the product type identifier
        /// </summary>
        public virtual int StoreID { get; set; }

        /// <summary>
        /// Gets or sets the product type identifier
        /// </summary>
        public virtual int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public virtual string Name { get; set; }


        /// <summary>
        /// Gets or sets the SKU
        /// </summary>
        public virtual string Sku { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
        public virtual int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public virtual bool Published { get; set; }


        public virtual IList<ProductCategoryDTO> productCategoryDTO { get; set; }

        //public virtual PageSizeList = new SelectList(new int[]{ 10, 20, 100 }) 

        //public virtual SelectList PageSizeList { get; set; }
        public virtual IList<ListItem> PageSizeList { get; set; }


    }// End of -- public partial class ProductListDTO : ecvDTOentity
}
