// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-08-2016
// ***********************************************************************
// <copyright file="IChatLieuController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Controllers.Interface{
    /// <summary>
    /// Interface IChatLieuController
    /// </summary>
    public interface IBaseController<T> {
        /// <summary>
        /// Views this instance.
        /// </summary>
        void View();
        void ReviewGrid();
        /// <summary>
        /// Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        void Insert(T value);
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        void Update(T value);
        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        void Delete(int value);
        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        void Delete(T value);
        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        void Delete(string value);
    }
}