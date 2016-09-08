// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="SanPham.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class SanPham.
    /// </summary>
    public partial class SanPham  :BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SanPham"/> class.
        /// </summary>
        public SanPham()
        {
            //this.ChiTietHDB = new HashSet<ChiTietHDB>();
            //this.ChiTietHDN = new HashSet<ChiTietHDN>();
        }
    
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the ma giay dep.
        /// </summary>
        /// <value>The ma giay dep.</value>
        public string MaGiayDep { get; set; }
        /// <summary>
        /// Gets or sets the ten giay dep.
        /// </summary>
        /// <value>The ten giay dep.</value>
        public string TenGiayDep { get; set; }
        /// <summary>
        /// Gets or sets the ma loai.
        /// </summary>
        /// <value>The ma loai.</value>
        public string MaLoai { get; set; }
        /// <summary>
        /// Gets or sets the ma co.
        /// </summary>
        /// <value>The ma co.</value>
        public string MaCo { get; set; }
        /// <summary>
        /// Gets or sets the ma chat lieu.
        /// </summary>
        /// <value>The ma chat lieu.</value>
        public string MaChatLieu { get; set; }
        /// <summary>
        /// Gets or sets the ma mau.
        /// </summary>
        /// <value>The ma mau.</value>
        public string MaMau { get; set; }
        /// <summary>
        /// Gets or sets the ma doi tuong.
        /// </summary>
        /// <value>The ma doi tuong.</value>
        public string MaDoiTuong { get; set; }
        /// <summary>
        /// Gets or sets the ma mua.
        /// </summary>
        /// <value>The ma mua.</value>
        public string MaMua { get; set; }
        /// <summary>
        /// Gets or sets the ma nuoc sx.
        /// </summary>
        /// <value>The ma nuoc sx.</value>
        public string MaNuocSX { get; set; }
        /// <summary>
        /// Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        public Nullable<int> SoLuong { get; set; }
        /// <summary>
        /// Gets or sets the anh.
        /// </summary>
        /// <value>The anh.</value>
        public string Anh { get; set; }
        /// <summary>
        /// Gets or sets the don gia nhap.
        /// </summary>
        /// <value>The don gia nhap.</value>
        public Nullable<decimal> DonGiaNhap { get; set; }
        /// <summary>
        /// Gets or sets the don gia ban.
        /// </summary>
        /// <value>The don gia ban.</value>
        public Nullable<decimal> DonGiaBan { get; set; }

        /// <summary>
        /// Gets or sets the chat lieu.
        /// </summary>
        /// <value>The chat lieu.</value>
        public virtual ChatLieu ChatLieu { get; set; }
        
        //public virtual ICollection<ChiTietHDB> ChiTietHDB { get; set; }
        //public virtual ICollection<ChiTietHDN> ChiTietHDN { get; set; }

        /// <summary>
        /// Gets or sets the doi tuong.
        /// </summary>
        /// <value>The doi tuong.</value>
        public virtual DoiTuong DoiTuong { get; set; }
        /// <summary>
        /// Gets or sets the kich co.
        /// </summary>
        /// <value>The kich co.</value>
        public virtual KichCo KichCo { get; set; }
        /// <summary>
        /// Gets or sets the mau.
        /// </summary>
        /// <value>The mau.</value>
        public virtual Mau Mau { get; set; }
        /// <summary>
        /// Gets or sets the mua.
        /// </summary>
        /// <value>The mua.</value>
        public virtual Mua Mua { get; set; }
        /// <summary>
        /// Gets or sets the nuoc san xuat.
        /// </summary>
        /// <value>The nuoc san xuat.</value>
        public virtual NuocSanXuat NuocSanXuat { get; set; }
        /// <summary>
        /// Gets or sets the loai.
        /// </summary>
        /// <value>The loai.</value>
        public virtual TheLoai TheLoai { get; set; }
    }
}
