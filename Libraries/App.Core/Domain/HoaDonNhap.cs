// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="HoaDonNhap.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
namespace App.Core.Domain {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class HoaDonNhap.
    /// </summary>
    public partial class HoaDonNhap: BaseEntity {
        /// <summary>
        /// Initializes a new instance of the <see cref="HoaDonNhap"/> class.
        /// </summary>
        public HoaDonNhap() {
            //this.ChiTietHDN = new HashSet<ChiTietHDN>();
        }


        /// <summary>
        /// Gets or sets the so HDN.
        /// </summary>
        /// <value>The so HDN.</value>
        [DisplayName("Số HDN")]
        public string SoHDN { get; set; }
        /// <summary>
        /// Gets or sets the ngay nhap.
        /// </summary>
        /// <value>The ngay nhap.</value>
        [DisplayName("Ngày nhập")]
        public Nullable<System.DateTime> NgayNhap { get; set; }
        /// <summary>
        /// Gets or sets the tong tien.
        /// </summary>
        /// <value>The tong tien.</value>
        [DisplayName("Tổng tiền")]
        public Nullable<decimal> TongTien { get; set; }
        /// <summary>
        /// Gets or sets the ma nv.
        /// </summary>
        /// <value>The ma nv.</value>
        [DisplayName("Mã nhân viên")]
        public string MaNV { get; set; }
        /// <summary>
        /// Gets or sets the ma NCC.
        /// </summary>
        /// <value>The ma NCC.</value>
        [DisplayName("Mã NCC")]
        public string MaNCC { get; set; }
        /// <summary>
        /// Gets or sets the nhan vien identifier.
        /// </summary>
        /// <value>The nhan vien identifier.</value>
        public Nullable<int> NhanVienID { get; set; }
        /// <summary>
        /// Gets or sets the nha cung cap identifier.
        /// </summary>
        /// <value>The nha cung cap identifier.</value>
        public Nullable<int> NhaCungCapID { get; set; }

        // public virtual ICollection<ChiTietHDN> ChiTietHDN { get; set; }
        /// <summary>
        /// Gets or sets the nha cung cap.
        /// </summary>
        /// <value>The nha cung cap.</value>
        public virtual NhaCungCap NhaCungCap { get; set; }
        /// <summary>
        /// Gets or sets the nhan vien.
        /// </summary>
        /// <value>The nhan vien.</value>
        public virtual NhanVien NhanVien { get; set; }
    }
}
