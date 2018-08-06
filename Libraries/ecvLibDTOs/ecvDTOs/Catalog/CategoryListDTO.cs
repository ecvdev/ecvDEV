using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLibDTOs.ecvDTOs.Catalog
{
    public class CategoryListDTO : ecvDTOentity
    {
        public virtual string Name { get; set; }
        public virtual string CategoryFullName { get; set; }
        public virtual bool Published { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual int ParentCategoryId { get; set; }
        public virtual bool Deleted { get; set; }

    }// End of -- public class CategoryListDTO : ecvDTOentity
}
