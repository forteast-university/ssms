// ***********************************************************************
// Assembly         : App.Service
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-26-2016
// ***********************************************************************
// <copyright file="ICommonService.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace App.Service {
    /// <summary>
    /// ICommonService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonService<T>{

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T GetById(int id);
        /// <summary>
        /// Gets the paging.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index">The index.</param>
        /// <param name="page">The page as at number page view.</param>
        /// <param name="size">The size as limit row per page.</param>
        /// <param name="sort">The sort as ID DESC, ASC</param>
        /// <param name="total">The total as total row.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetListByPaging(string value, string index, int page, int size, string sort, out int total);
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetList(int id);
        /// <summary>
        /// Gets the top.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetTop(int top);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);
        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Insert(IEnumerable<T> entities);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
        /// <summary>
        /// Edits the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Update(IEnumerable<T> entities);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Delete(IEnumerable<T> entities);
        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Delete(IList<int> entities);
    }
}
