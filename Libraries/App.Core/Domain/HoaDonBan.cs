// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="HoaDonBan.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Domain
{
    /// <summary>
    ///     Class HoaDonBan.
    /// </summary>
    public class HoaDonBan : BaseEntity
    {

        public HoaDonBan()
        {
           ChiTietHDB = new List<ChiTietHDB>();
            NgayBan = DateTime.Now;
        }

        [NotMapped]
        public List<ChiTietHDB> ChiTietHDB { get; set; }

        /// <summary>
        ///     Gets or sets the so HDB.
        /// </summary>
        /// <value>The so HDB.</value>
        [DisplayName("Mã HDB")]
        public string SoHDB { get; set; }

        /// <summary>
        ///     Gets or sets the ngay ban.
        /// </summary>
        /// <value>The ngay ban.</value>
        [DisplayName("Ngày bán")]
        public DateTime NgayBan { get; set; }

        /// <summary>
        ///     Gets or sets the tong tien.
        /// </summary>
        /// <value>The tong tien.</value>
        [DisplayName("Tổng tiền")]
        public decimal TongTien { get; set; }

        /// <summary>
        ///     Gets or sets the ma nv.
        /// </summary>
        /// <value>The ma nv.</value>
        [DisplayName("Mã nhân viên")]
        public string MaNV { get; set; }

        /// <summary>
        ///     Gets or sets the ma khach.
        /// </summary>
        /// <value>The ma khach.</value>
        [DisplayName("Mã khách")]
        public string MaKhach { get; set; }

        /// <summary>
        ///     Gets or sets the khach hang identifier.
        /// </summary>
        /// <value>The khach hang identifier.</value>
        public int KhachHangID { get; set; }

        /// <summary>
        ///     Gets or sets the nhan vien identifier.
        /// </summary>
        /// <value>The nhan vien identifier.</value>
        public int NhanVienID { get; set; }

        // public virtual ICollection<ChiTietHDB> ChiTietHDB { get; set; }
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