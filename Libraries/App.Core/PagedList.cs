// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="PagedList.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Core
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T> 
    {
        /// <summary>
        /// Ctor (paging in performed inside)
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            Init(source, pageIndex, pageSize);
        }

        /// <summary>
        /// Ctor (already paged soure is passed)
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            Init(source, pageIndex, pageSize, totalCount);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        /// <exception cref="System.ArgumentNullException">source</exception>
        /// <exception cref="System.ArgumentException">pageSize must be greater than zero</exception>
        private void Init(IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (pageSize <= 0)
                throw new ArgumentException("pageSize must be greater than zero");

            TotalCount = totalCount ?? source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            source = totalCount == null ? source.Skip(pageIndex * pageSize).Take(pageSize) : source;
            AddRange(source);
        }

        /// <summary>
        /// Gets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex { get; private set; }
        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; private set; }
        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <value>The total count.</value>
        public int TotalCount { get; private set; }
        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has previous page.
        /// </summary>
        /// <value><c>true</c> if this instance has previous page; otherwise, <c>false</c>.</value>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        /// <summary>
        /// Gets a value indicating whether this instance has next page.
        /// </summary>
        /// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
