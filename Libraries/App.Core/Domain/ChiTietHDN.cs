// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="ChiTietHDN.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class ChiTietHDN.
    /// </summary>
    public partial class ChiTietHDN  :BaseEntity
    {

        /// <summary>
        /// Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        public Nullable<int> SoLuong { get; set; }
        /// <summary>
        /// Gets or sets the don gia.
        /// </summary>
        /// <value>The don gia.</value>
        public Nullable<decimal> DonGia { get; set; }
        /// <summary>
        /// Gets or sets the giam gia.
        /// </summary>
        /// <value>The giam gia.</value>
        public string GiamGia { get; set; }
        /// <summary>
        /// Gets or sets the thanh tien.
        /// </summary>
        /// <value>The thanh tien.</value>
        public Nullable<decimal> ThanhTien { get; set; }
        /// <summary>
        /// Gets or sets the so HDN.
        /// </summary>
        /// <value>The so HDN.</value>
        public string SoHDN { get; set; }
        /// <summary>
        /// Gets or sets the ma giay dep.
        /// </summary>
        /// <value>The ma giay dep.</value>
        public string MaGiayDep { get; set; }
        /// <summary>
        /// Gets or sets the san pham identifier.
        /// </summary>
        /// <value>The san pham identifier.</value>
        public Nullable<int> SanPhamID { get; set; }
        /// <summary>
        /// Gets or sets the hoa don nhap identifier.
        /// </summary>
        /// <value>The hoa don nhap identifier.</value>
        public Nullable<int> HoaDonNhapID { get; set; }

        /// <summary>
        /// Gets or sets the hoa don nhap.
        /// </summary>
        /// <value>The hoa don nhap.</value>
        public virtual HoaDonNhap HoaDonNhap { get; set; }
        /// <summary>
        /// Gets or sets the san pham.
        /// </summary>
        /// <value>The san pham.</value>
        public virtual SanPham SanPham { get; set; }
    }
}
