using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecvAdminUI.Models.Catalog
{
    public partial class CategoryModel : CategoryDTO
    {
        public CategoryModel()
        {
            if (PageSize < 1 )
            {
                PageSize = 5;
            }
        }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.ttt}", ApplyFormatInEditMode = true)]
        [Required]
        public override DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.ttt}", ApplyFormatInEditMode = true)]
        [Required]
        public override DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [AllowHtmlAttribute]
        public override string Description { get; set; }

    }
}