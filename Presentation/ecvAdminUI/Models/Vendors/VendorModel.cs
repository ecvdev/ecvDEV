using ecvLibDTOs.ecvDTOs.Vendor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecvAdminUI.Models.Vendors
{
    public partial class VendorModel : VendorDTO
    {

        public VendorModel()
        {
            if(PageSize < 1)
            {
                PageSize = 5; ; // set default page size options
            }
            if (string.IsNullOrEmpty(PageSizeOptions) || string.IsNullOrWhiteSpace(PageSizeOptions))
            {
                PageSizeOptions = "10,5,20"; // set default page size options
            }            
        }
       

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [AllowHtml]
        public override string Description { get; set; }


        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        [AllowHtml]
        public override string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        [AllowHtml]
        public override string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        [AllowHtml]
        public override string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product creation
        /// </summary>
        [DisplayName("Created")]
        public override DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
        [DisplayName("Updated")]
        public override DateTime UpdatedOnUtc { get; set; }

    }// End of -- public partial class VendorModel
}