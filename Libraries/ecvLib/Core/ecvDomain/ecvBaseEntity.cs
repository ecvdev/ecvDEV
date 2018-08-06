using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLib.Core.ecvDomain
{
    public abstract partial class ecvBaseEntity
    {

        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ecvBaseEntity);
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }


    }// End of -- public abstract partial class BaseEntity

}
