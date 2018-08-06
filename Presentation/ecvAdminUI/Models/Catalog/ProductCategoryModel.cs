using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecvAdminUI.Models.Catalog
{
    public partial class ProductCategoryModel : ProductCategoryDTO
    {


        /// <summary>
        /// Gets the category
        /// </summary>
        public virtual CategoryModel Category { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        public virtual ProductModel Product { get; set; }
    }
}