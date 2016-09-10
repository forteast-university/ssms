// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="KhachHang.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
namespace App.Core.Domain {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class KhachHang.
    /// </summary>
    public partial class KhachHang: BaseEntity {
        /// <summary>
        /// Initializes a new instance of the <see cref="KhachHang"/> class.
        /// </summary>
        public KhachHang() {
            //this.HoaDonBan = new HashSet<HoaDonBan>();
        }


        /// <summary>
        /// Gets or sets the ma khach.
        /// </summary>
        /// <value>The ma khach.</value>
        [DisplayName("Mã khách")]
        public string MaKhach { get; set; }
        /// <summary>
        /// Gets or sets the ten khach.
        /// </summary>
        /// <value>The ten khach.</value>
        [DisplayName("Tên khách")]
        public string TenKhach { get; set; }
        /// <summary>
        /// Gets or sets the dia chi.
        /// </summary>
        /// <value>The dia chi.</value>
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        /// <summary>
        /// Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        [DisplayName("Điện thoại")]
        public string DienThoai { get; set; }


    }
}
