using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ecvAdminUI.Models.Catalog
{
    public partial class ManufacturerModel : ManufacturerDTO
    {

        public ManufacturerModel()
        {
            if (PageSize < 1)
            {
                PageSize = 5; ; // set default page size options
            }
            if (string.IsNullOrEmpty(PageSizeOptions) || string.IsNullOrWhiteSpace(PageSizeOptions))
            {
                PageSizeOptions = "10,5,20"; // set default page size options
            }
        }

        [AllowHtml]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Manufacturer name cannnot be empty.")]
        public override string Name { get; set; }

        [AllowHtml]
        public override string Description { get; set; }


        [AllowHtml]
        public override string MetaKeywords { get; set; }

        [AllowHtml]
        public override string MetaDescription { get; set; }

        [AllowHtml]
        public override string MetaTitle { get; set; }

        [AllowHtml]
        public override string SeName { get; set; }

        [UIHint("Picture")]
        public override int PictureId { get; set; }

        public override int PageSize { get; set; }

        public override bool AllowCustomersToSelectPageSize { get; set; }

        public override string PageSizeOptions { get; set; }

        [AllowHtml]
        public override string PriceRanges { get; set; }

        public override bool Published { get; set; }

        public override bool Deleted { get; set; }

        public override int DisplayOrder { get; set; }

        public override DateTime CreatedOnUtc { get; set; }

        public override DateTime UpdatedOnUtc { get; set; }

        ////ACL (customer roles)
        //[UIHint("MultiSelect")]
        //public IList<int> SelectedCustomerRoleIds { get; set; }
        //public IList<SelectListItem> AvailableCustomerRoles { get; set; }


        ////store mapping
        //[UIHint("MultiSelect")]
        //public IList<int> SelectedStoreIds { get; set; }
        //public IList<SelectListItem> AvailableStores { get; set; }


        ////discounts
        //[UIHint("MultiSelect")]
        //public IList<int> SelectedDiscountIds { get; set; }
        //public IList<SelectListItem> AvailableDiscounts { get; set; }

    }// End of -- public partial class ManufacturerModel
}