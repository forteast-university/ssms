// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="AppEntityTypeConfiguration.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Mapping
{
    /// <summary>
    /// Class AppEntityTypeConfiguration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppEntityTypeConfiguration{T}"/> class.
        /// </summary>
        protected AppEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// we can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}