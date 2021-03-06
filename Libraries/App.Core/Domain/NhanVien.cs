// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="NhanVien.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
namespace App.Core.Domain {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class NhanVien.
    /// </summary>
    public partial class NhanVien: BaseEntity {
        /// <summary>
        /// Initializes a new instance of the <see cref="NhanVien"/> class.
        /// </summary>
        public NhanVien() {
            //this.HoaDonBan = new HashSet<HoaDonBan>();
            //this.HoaDonNhap = new HashSet<HoaDonNhap>();
        }


        /// <summary>
        /// Gets or sets the ma nhan vien.
        /// </summary>
        /// <value>The ma nhan vien.</value>
        [DisplayName("Mã nhân viên")]
        public string MaNhanVien { get; set; }
        /// <summary>
        /// Gets or sets the ten nhan vien.
        /// </summary>
        /// <value>The ten nhan vien.</value>
        [DisplayName("Tên nhân viên")]
        public string TenNhanVien { get; set; }
        /// <summary>
        /// Gets or sets the gioi tinh.
        /// </summary>
        /// <value>The gioi tinh.</value>
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }
        /// <summary>
        /// Gets or sets the ngay sinh.
        /// </summary>
        /// <value>The ngay sinh.</value>
        [DisplayName("Ngày sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        /// <summary>
        /// Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        [DisplayName("Điện thoại")]
        public string DienThoai { get; set; }
        /// <summary>
        /// Gets or sets the dia chi.
        /// </summary>
        /// <value>The dia chi.</value>
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        /// <summary>
        /// Gets or sets the mat khau.
        /// </summary>
        /// <value>The mat khau.</value>
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }
        /// <summary>
        /// Gets or sets the ma cv.
        /// </summary>
        /// <value>The ma cv.</value>
        [DisplayName("Mã công việc")]
        public string MaCV { get; set; }
        /// <summary>
        /// Gets or sets the cong viec identifier.
        /// </summary>
        /// <value>The cong viec identifier.</value>
        public Nullable<int> CongViecID { get; set; }

        /// <summary>
        /// Gets or sets the cong viec.
        /// </summary>
        /// <value>The cong viec.</value>
        public virtual CongViec CongViec { get; set; }

    }
}
