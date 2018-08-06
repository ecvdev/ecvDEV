using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ecvLibDTOs.ecvDTOs.Catalog
{
    public partial class ManufacturerDTO : ecvDTOentity
    {        
        public virtual string Name { get; set; }       

        public virtual string Description { get; set; }

        public virtual int ManufacturerTemplateId { get; set; }
        public virtual IList<ListItem> AvailableManufacturerTemplates { get; set; }

        
        public virtual string MetaKeywords { get; set; }

        
        public virtual string MetaDescription { get; set; }

        
        public virtual string MetaTitle { get; set; }

        
        public virtual string SeName { get; set; }

        public virtual int PictureId { get; set; }

        public virtual int PageSize { get; set; }

        public virtual bool AllowCustomersToSelectPageSize { get; set; }

        public virtual string PageSizeOptions { get; set; }

        
        public virtual string PriceRanges { get; set; }

        public virtual bool Published { get; set; }

        public virtual bool Deleted { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual DateTime CreatedOnUtc { get; set; }

        public virtual DateTime UpdatedOnUtc { get; set; }

        ////ACL (customer roles)
        //[UIHint("MultiSelect")]
        //public virtual IList<int> SelectedCustomerRoleIds { get; set; }
        //public virtual IList<SelectListItem> AvailableCustomerRoles { get; set; }


        ////store mapping
        //[UIHint("MultiSelect")]
        //public virtual IList<int> SelectedStoreIds { get; set; }
        //public virtual IList<SelectListItem> AvailableStores { get; set; }


        ////discounts
        //[UIHint("MultiSelect")]
        //public virtual IList<int> SelectedDiscountIds { get; set; }
        //public virtual IList<SelectListItem> AvailableDiscounts { get; set; }


    }// End of -- public partial class ManufacturerDTO : ecvDTOentity
}
