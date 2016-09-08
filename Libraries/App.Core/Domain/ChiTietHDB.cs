// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="ChiTietHDB.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class ChiTietHDB.
    /// </summary>
    public partial class ChiTietHDB: BaseEntity
    {
        //public int ID { get; set; }
        /// <summary>
        /// Gets or sets the ma giay dep.
        /// </summary>
        /// <value>The ma giay dep.</value>
        public string MaGiayDep { get; set; }
        /// <summary>
        /// Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        public Nullable<int> SoLuong { get; set; }
        /// <summary>
        /// Gets or sets the giam gia.
        /// </summary>
        /// <value>The giam gia.</value>
        public string GiamGia { get; set; }
        /// <summary>
        /// Gets or sets the thanh tien.
        /// </summary>
        /// <value>The thanh tien.</value>
        public string ThanhTien { get; set; }
        /// <summary>
        /// Gets or sets the so HDB.
        /// </summary>
        /// <value>The so HDB.</value>
        public string SoHDB { get; set; }

        /// <summary>
        /// Gets or sets the hoa don ban.
        /// </summary>
        /// <value>The hoa don ban.</value>
        public virtual HoaDonBan HoaDonBan { get; set; }
        /// <summary>
        /// Gets or sets the san pham.
        /// </summary>
        /// <value>The san pham.</value>
        public virtual SanPham SanPham { get; set; }
    }
}
