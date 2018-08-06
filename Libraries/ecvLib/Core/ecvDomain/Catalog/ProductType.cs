using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLib.Core.ecvDomain.Catalog
{
    public partial class ProductType : ecvBaseEntity
    {
        public int StoreId { get; set; }

        public string Description { get; set; }
    }
}
