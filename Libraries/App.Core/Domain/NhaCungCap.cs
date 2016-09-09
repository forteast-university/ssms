// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="NhaCungCap.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class NhaCungCap.
    /// </summary>
    public partial class NhaCungCap : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NhaCungCap"/> class.
        /// </summary>
        public NhaCungCap()
        {
            //this.HoaDonNhap = new HashSet<HoaDonNhap>();
        }


        /// <summary>
        /// Gets or sets the ma NCC.
        /// </summary>
        /// <value>The ma NCC.</value>
        public string MaNCC { get; set; }
        /// <summary>
        /// Gets or sets the ten NCC.
        /// </summary>
        /// <value>The ten NCC.</value>
        public string TenNCC { get; set; }
        /// <summary>
        /// Gets or sets the dia chi.
        /// </summary>
        /// <value>The dia chi.</value>
        public string DiaChi { get; set; }
        /// <summary>
        /// Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        public string DienThoai { get; set; }
    
        // public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }
    }
}
