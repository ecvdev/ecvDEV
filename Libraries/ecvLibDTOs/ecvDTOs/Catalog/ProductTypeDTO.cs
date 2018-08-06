using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLibDTOs.ecvDTOs.Catalog
{
    public partial class ProductTypeDTO : ecvDTOentity
    {

        /// <summary>
        /// Gets or sets the product type for storeId
        /// </summary>
        public virtual int StoreID { get; set; }

        /// <summary>
        /// Gets or sets the product type Description
        /// </summary>
        public virtual string Description { get; set; }

    }// End of -- public partial class ProductTypeDTO : ecvDTOentity
}
