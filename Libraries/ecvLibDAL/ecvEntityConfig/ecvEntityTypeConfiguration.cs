﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLibDAL.ecvEntityConfig
{
    public abstract class ecvEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected ecvEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }

    }// End of -- public abstract class ecvEntityTypeConfiguration<T>
}
