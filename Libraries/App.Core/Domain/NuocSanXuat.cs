// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="NuocSanXuat.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;

namespace App.Core.Domain
{
    /// <summary>
    ///     Class NuocSanXuat.
    /// </summary>
    public class NuocSanXuat : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ma nuoc sx.
        /// </summary>
        /// <value>The ma nuoc sx.</value>
        [DisplayName("Mã nước sản xuất")]
        public string MaNuocSX { get; set; }

        /// <summary>
        ///     Gets or sets the ten nuoc sx.
        /// </summary>
        /// <value>The ten nuoc sx.</value>
        [DisplayName("Nước sản xuất")]
        public string TenNuocSX { get; set; }
    }
}