// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="HoaDonNhap.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace App.Core.Domain{
    /// <summary>
    ///     Class HoaDonNhap.
    /// </summary>
    public class HoaDonNhap : BaseEntity{
        //public int ID { get; set; }
        /// <summary>
        ///     Gets or sets the so HDN.
        /// </summary>
        /// <value>The so HDN.</value>
        public string SoHDN { get; set; }

        /// <summary>
        ///     Gets or sets the ma nv.
        /// </summary>
        /// <value>The ma nv.</value>
        public string MaNV { get; set; }

        /// <summary>
        ///     Gets or sets the ngay nhap.
        /// </summary>
        /// <value>The ngay nhap.</value>
        public DateTime? NgayNhap { get; set; }

        /// <summary>
        ///     Gets or sets the ma NCC.
        /// </summary>
        /// <value>The ma NCC.</value>
        public string MaNCC { get; set; }

        /// <summary>
        ///     Gets or sets the tong tien.
        /// </summary>
        /// <value>The tong tien.</value>
        public decimal? TongTien { get; set; }

        /// <summary>
        ///     Gets or sets the nha cung cap.
        /// </summary>
        /// <value>The nha cung cap.</value>
        public virtual NhaCungCap NhaCungCap { get; set; }

        /// <summary>
        ///     Gets or sets the nhan vien.
        /// </summary>
        /// <value>The nhan vien.</value>
        public virtual NhanVien NhanVien { get; set; }
    }
}