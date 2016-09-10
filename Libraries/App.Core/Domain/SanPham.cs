// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="SanPham.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Domain {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class SanPham.
    /// </summary>
    public partial class SanPham: BaseEntity {
        /// <summary>
        /// Initializes a new instance of the <see cref="SanPham"/> class.
        /// </summary>
        public SanPham() {
            //this.ChiTietHDB = new HashSet<ChiTietHDB>();
            //this.ChiTietHDN = new HashSet<ChiTietHDN>();
        }


        /// <summary>
        /// Gets or sets the ma giay dep.
        /// </summary>
        /// <value>The ma giay dep.</value>
        [DisplayName("Mã sản phẩm")]
        public string MaGiayDep { get; set; }
        /// <summary>
        /// Gets or sets the ten giay dep.
        /// </summary>
        /// <value>The ten giay dep.</value>
        [DisplayName("Tên sản phẩm")]
        public string TenGiayDep { get; set; }
        /// <summary>
        /// Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        [DisplayName("Số lượng")]
        public Nullable<int> SoLuong { get; set; }
        /// <summary>
        /// Gets or sets the anh.
        /// </summary>
        /// <value>The anh.</value>
        [DisplayName("Link ảnh")]
        public string Anh { get; set; }
        /// <summary>
        /// Gets or sets the don gia nhap.
        /// </summary>
        /// <value>The don gia nhap.</value>
        [DisplayName("Đơn giá nhập")]
        public Nullable<decimal> DonGiaNhap { get; set; }
        /// <summary>
        /// Gets or sets the don gia ban.
        /// </summary>
        /// <value>The don gia ban.</value>
        [DisplayName("Đơn giá bán")]
        public Nullable<decimal> DonGiaBan { get; set; }
        /// <summary>
        /// Gets or sets the ma loai.
        /// </summary>
        /// <value>The ma loai.</value>
        [DisplayName("Mã loại")]
        public string MaLoai { get; set; }
        /// <summary>
        /// Gets or sets the ma co.
        /// </summary>
        /// <value>The ma co.</value>
        [DisplayName("Mã cỡ")]
        public string MaCo { get; set; }
        /// <summary>
        /// Gets or sets the ma chat lieu.
        /// </summary>
        /// <value>The ma chat lieu.</value>
        [DisplayName("Mã chất liệu")]
        public string MaChatLieu { get; set; }
        /// <summary>
        /// Gets or sets the ma mau.
        /// </summary>
        /// <value>The ma mau.</value>
        [DisplayName("Mã màu")]
        public string MaMau { get; set; }
        /// <summary>
        /// Gets or sets the ma doi tuong.
        /// </summary>
        /// <value>The ma doi tuong.</value>
        [DisplayName("Mã đối tượng")]
        public string MaDoiTuong { get; set; }
        /// <summary>
        /// Gets or sets the ma mua.
        /// </summary>
        /// <value>The ma mua.</value>
        [DisplayName("Mã mùa")]
        public string MaMua { get; set; }
        /// <summary>
        /// Gets or sets the ma nuoc sx.
        /// </summary>
        /// <value>The ma nuoc sx.</value>
        [DisplayName("Nước sản xuất")]
        public string MaNuocSX { get; set; }
        /// <summary>
        /// Gets or sets the loai identifier.
        /// </summary>
        /// <value>The loai identifier.</value>
        public Nullable<int> TheLoaiID { get; set; }
        /// <summary>
        /// Gets or sets the kinh co identifier.
        /// </summary>
        /// <value>The kinh co identifier.</value>
        public Nullable<int> KichCoID { get; set; }
        /// <summary>
        /// Gets or sets the chat lieu identifier.
        /// </summary>
        /// <value>The chat lieu identifier.</value>
        public Nullable<int> ChatLieuID { get; set; }
        /// <summary>
        /// Gets or sets the mau identifier.
        /// </summary>
        /// <value>The mau identifier.</value>
        public Nullable<int> MauID { get; set; }
        /// <summary>
        /// Gets or sets the doi tuong identifier.
        /// </summary>
        /// <value>The doi tuong identifier.</value>
        public Nullable<int> DoiTuongID { get; set; }
        /// <summary>
        /// Gets or sets the mua identifier.
        /// </summary>
        /// <value>The mua identifier.</value>
        public Nullable<int> MuaID { get; set; }
        /// <summary>
        /// Gets or sets the nuoc san xuat identifier.
        /// </summary>
        /// <value>The nuoc san xuat identifier.</value>
        public Nullable<int> NuocSanXuatID { get; set; }


        /// <summary>
        /// Gets or sets the chat lieu.
        /// </summary>
        /// <value>The chat lieu.</value>

        [ForeignKey("ChatLieuID")]
        public virtual ChatLieu ChatLieu { get; set; }
        /// <summary>
        /// Gets or sets the doi tuong.
        /// </summary>
        /// <value>The doi tuong.</value>
        [ForeignKey("DoiTuongID")]
        public virtual DoiTuong DoiTuong { get; set; }
        /// <summary>
        /// Gets or sets the kich co.
        /// </summary>
        /// <value>The kich co.</value>
        [ForeignKey("KichCoID")]
        public virtual KichCo KichCo { get; set; }
        /// <summary>
        /// Gets or sets the mau.
        /// </summary>
        /// <value>The mau.</value>
        [ForeignKey("MauID")]
        public virtual Mau Mau { get; set; }
        /// <summary>
        /// Gets or sets the mua.
        /// </summary>
        /// <value>The mua.</value>
        [ForeignKey("MuaID")]
        public virtual Mua Mua { get; set; }
        /// <summary>
        /// Gets or sets the nuoc san xuat.
        /// </summary>
        /// <value>The nuoc san xuat.</value>
        [ForeignKey("NuocSanXuatID")]
        public virtual NuocSanXuat NuocSanXuat { get; set; }
        /// <summary>
        /// Gets or sets the loai.
        /// </summary>
        /// <value>The loai.</value>
        [ForeignKey("TheLoaiID")]
        public virtual TheLoai TheLoai { get; set; }


    }
}
