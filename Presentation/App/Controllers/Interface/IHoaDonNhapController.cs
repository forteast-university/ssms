﻿// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-14-2016
// ***********************************************************************
// <copyright file="IChatLieuController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.Extensions;
using App.Models;

namespace App.Controllers.Interface {
    /// <summary>
    /// Interface IChatLieuController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHoaDonNhapController<T>: IBaseController<T> {

        /// <summary>
        /// Validates the and fillup.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IList&lt;System.String&gt;.</returns>
        IList<string> ValidateAndFillup(T value);
        /// <summary>
        /// Hides the hoa don nhap view.
        /// </summary>
        void HideHoaDonNhapView();
        /// <summary>
        /// Shows the hoa don nhap view.
        /// </summary>
        /// <param name="value">The value.</param>
        void ShowHoaDonNhapView(T value);
        /// <summary>
        /// Saves the hoa don nhap.
        /// </summary>
        /// <param name="value">The value.</param>
        void SaveHoaDonNhap(T value);
        /// <summary>
        /// Sets the hoa don nhap ListView.
        /// </summary>
        /// <param name="value">The value.</param>
        void SetHoaDonNhapListView(Form value);

        /// <summary>
        /// Hides the san pham view.
        /// </summary>
        void HideSanPhamView();
        /// <summary>
        /// Shows the san pham view to create.
        /// </summary>
        /// <param name="ma">The ma.</param>
        void ShowSanPhamViewToCreate(string ma);
        /// <summary>
        /// Checks the ma from san pham.
        /// </summary>
        /// <param name="ma">The ma.</param>
        /// <returns>SanPhamModel.</returns>
        SanPhamModel CheckMaFromSanPham(string ma);

    }
}