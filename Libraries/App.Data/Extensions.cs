// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-19-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-19-2016
// ***********************************************************************
// <copyright file="Extensions.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Objects;
using App.Core.Domain;

namespace App.Data
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Get unproxied entity type
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Type.</returns>
        /// <remarks>If your Entity Framework context is proxy-enabled,
        /// the runtime will create a proxy instance of your entities,
        /// i.e. a dynamically generated class which inherits from your entity class
        /// and overrides its virtual properties by inserting specific code useful for example
        /// for tracking changes and lazy loading.</remarks>
        public static Type GetUnproxiedEntityType(this BaseEntity entity)
        {
            var userType = ObjectContext.GetObjectType(entity.GetType());
            return userType;
        }
    }
}
