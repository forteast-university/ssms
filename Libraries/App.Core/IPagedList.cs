// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-19-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-19-2016
// ***********************************************************************
// <copyright file="IPagedList.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace ADA.Core
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// Gets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        int PageIndex { get; }
        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        int PageSize { get; }
        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <value>The total count.</value>
        int TotalCount { get; }
        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        int TotalPages { get; }
        /// <summary>
        /// Gets a value indicating whether this instance has previous page.
        /// </summary>
        /// <value><c>true</c> if this instance has previous page; otherwise, <c>false</c>.</value>
        bool HasPreviousPage { get; }
        /// <summary>
        /// Gets a value indicating whether this instance has next page.
        /// </summary>
        /// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
        bool HasNextPage { get; }
    }
}
