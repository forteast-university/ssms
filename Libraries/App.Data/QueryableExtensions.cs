// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="QueryableExtensions.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace App.Data 
{
    /// <summary>
    /// Queryable extensions
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Include
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="queryable">Queryable</param>
        /// <param name="includeProperties">A list of properties to include</param>
        /// <returns>New queryable</returns>
        /// <exception cref="System.ArgumentNullException">queryable</exception>
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> queryable,params Expression<Func<T, object>>[] includeProperties)
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");

            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.IncludeProperties(includeProperty));
        }

    }
}