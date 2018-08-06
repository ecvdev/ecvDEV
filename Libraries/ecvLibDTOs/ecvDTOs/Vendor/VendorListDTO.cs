using System;

namespace ecvLibDTOs.ecvDTOs.Vendor
{
    public partial class VendorListDTO : ecvDTOentity
    {
        /// <summary>
        /// Gets the StoreID
        /// </summary>
        public virtual Int32 StoreID { get; set; }

        /// <summary>
        /// Gets the Code
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets the name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets the email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets value indicating whether the entity is active
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public virtual bool Deleted { get; set; }

    }// End of -- public partial class VendorListDTO : ecvDTOentity
}
