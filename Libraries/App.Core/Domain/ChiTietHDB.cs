// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="ChiTietHDB.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
namespace App.Core.Domain {
    /// <summary>
    ///     Class ChiTietHDB.
    /// </summary>
    public class ChiTietHDB: BaseEntity {
        /// <summary>
        ///     Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        public int SoLuong { get; set; }

        /// <summary>
        ///     Gets or sets the giam gia.
        /// </summary>
        /// <value>The giam gia.</value>
        [DisplayName("Giảm giá")]
        public decimal GiamGia { get; set; }

        /// <summary>
        ///     Gets or sets the thanh tien.
        /// </summary>
        /// <value>The thanh tien.</value>
        [DisplayName("Thành tiền")]
        public decimal ThanhTien { get; set; }

        /// <summary>
        ///     Gets or sets the ma giay dep.
        /// </summary>
        /// <value>The ma giay dep.</value>
        [DisplayName("Mã giầy dép")]
        public string MaGiayDep { get; set; }

        /// <summary>
        ///     Gets or sets the so HDB.
        /// </summary>
        /// <value>The so HDB.</value>
        [DisplayName("Số hóa đơn bán")]
        public string SoHDB { get; set; }

        /// <summary>
        ///     Gets or sets the san pham identifier.
        /// </summary>
        /// <value>The san pham identifier.</value>
        public int SanPhamID { get; set; }

        /// <summary>
        ///     Gets or sets the hoa don ban identifier.
        /// </summary>
        /// <value>The hoa don ban identifier.</value>
        public int HoaDonBanID { get; set; }

        /// <summary>
        ///     Gets or sets the hoa don ban.
        /// </summary>
        /// <value>The hoa don ban.</value>
        public virtual HoaDonBan HoaDonBan { get; set; }

        /// <summary>
        ///     Gets or sets the san pham.
        /// </summary>
        /// <value>The san pham.</value>
        public virtual SanPham SanPham { get; set; }
    }
}