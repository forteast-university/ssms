// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="HoaDonBan.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace App.Core.Domain{
    /// <summary>
    ///     Class HoaDonBan.
    /// </summary>
    public class HoaDonBan : BaseEntity{
        //public int ID { get; set; }
        /// <summary>
        ///     Gets or sets the so HDB.
        /// </summary>
        /// <value>The so HDB.</value>
        public string SoHDB { get; set; }

        /// <summary>
        ///     Gets or sets the ma nv.
        /// </summary>
        /// <value>The ma nv.</value>
        public string MaNV { get; set; }

        /// <summary>
        ///     Gets or sets the ngay ban.
        /// </summary>
        /// <value>The ngay ban.</value>
        public DateTime? NgayBan { get; set; }

        /// <summary>
        ///     Gets or sets the ma khach.
        /// </summary>
        /// <value>The ma khach.</value>
        public string MaKhach { get; set; }

        /// <summary>
        ///     Gets or sets the tong tien.
        /// </summary>
        /// <value>The tong tien.</value>
        public decimal? TongTien { get; set; }

        /// <summary>
        ///     Gets or sets the khach hang.
        /// </summary>
        /// <value>The khach hang.</value>
        public virtual KhachHang KhachHang { get; set; }

        /// <summary>
        ///     Gets or sets the nhan vien.
        /// </summary>
        /// <value>The nhan vien.</value>
        public virtual NhanVien NhanVien { get; set; }
    }
}