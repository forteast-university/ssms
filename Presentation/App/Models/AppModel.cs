// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-14-2016
// ***********************************************************************
// <copyright file="ProductModel.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary>
//ChatLieu
//ChiTietHDB
//ChiTietHDN
//CongViec
//DoiTuong
//HoaDonBan
//HoaDonNhap
//KhachHang
//KichCo
//Mau
//Mua
//NhaCungCap
//NhanVien
//NuocSanXuat
//SanPham
//TheLoai
//-------------------------
//ChatLieu,ChiTietHDB,ChiTietHDN,CongViec,DoiTuong,HoaDonBan,HoaDonNhap,KhachHang,KichCo,Mau,Mua,NhaCungCap,NhanVien,NuocSanXuat,SanPham,TheLoai</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using App.Core.Domain;
using App.Extensions;

namespace App.Models{

    /// <summary>
    /// Class BaoCaoModel.
    /// </summary>
    public class BaoCaoModel
    {
        public BaoCaoModel()
        {
        }
    }
    public class DropdownList:BaseEntity {
        public DropdownList() {
        }
        [DisplayName("Giá trị")]
        public string Value { get; set; }

    }

    /// <summary>
    /// Do the right thing :D
    /// Add your model to here,
    /// Should not inherit Domain Class if you don't know why i do that!
    /// </summary>
    public class ChatLieuModel : ChatLieu { }

    /// <summary>
    /// Class ChiTietHdbModel.
    /// </summary>
    public class ChiTietHdbModel : ChiTietHDB
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChiTietHdbModel"/> class.
        /// </summary>
        public ChiTietHdbModel() {
            IDModel = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Gets or sets the identifier model.
        /// </summary>
        /// <value>The identifier model.</value>
        [DisplayName("GUID")]
        public string IDModel { get; set; }
    }

    /// <summary>
    /// Class ChiTietHdnModel.
    /// </summary>
    public class ChiTietHdnModel : ChiTietHDN{
        /// <summary>
        /// Initializes a new instance of the <see cref="ChiTietHdnModel"/> class.
        /// </summary>
        public ChiTietHdnModel(){
            IDModel = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Gets or sets the identifier model.
        /// </summary>
        /// <value>The identifier model.</value>
        [DisplayName("GUID")]
        public string IDModel { get; set; }
    }
    /// <summary>
    /// Class CongViecModel.
    /// </summary>
    public class CongViecModel : CongViec { }
    /// <summary>
    /// Class DoiTuongModel.
    /// </summary>
    public class DoiTuongModel : DoiTuong { }

    /// <summary>
    /// Class HoaDonBanModel.
    /// </summary>
    public class HoaDonBanModel : HoaDonBan
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="HoaDonBanModel"/> class.
        /// </summary>
        public HoaDonBanModel() {
            ChiTietHDBModel = new List<ChiTietHdbModel>();

        }
        /// <summary>
        /// Gets or sets the chi tiet HDB model.
        /// </summary>
        /// <value>The chi tiet HDB model.</value>
        public List<ChiTietHdbModel> ChiTietHDBModel { get; set; }
    }

    /// <summary>
    /// Class HoaDonNhapModel.
    /// </summary>
    public class HoaDonNhapModel : HoaDonNhap{
        /// <summary>
        /// Initializes a new instance of the <see cref="HoaDonNhapModel"/> class.
        /// </summary>
        public HoaDonNhapModel(){
            ChiTietHDNModel = new List<ChiTietHdnModel>();

        }
        /// <summary>
        /// Gets or sets the chi tiet HDN model.
        /// </summary>
        /// <value>The chi tiet HDN model.</value>
        public List<ChiTietHdnModel> ChiTietHDNModel { get; set; }


    }
    /// <summary>
    /// Class KhachHangModel.
    /// </summary>
    public class KhachHangModel : KhachHang { }
    /// <summary>
    /// Class KichCoModel.
    /// </summary>
    public class KichCoModel : KichCo { }
    /// <summary>
    /// Class MauModel.
    /// </summary>
    public class MauModel : Mau { }
    /// <summary>
    /// Class MuaModel.
    /// </summary>
    public class MuaModel : Mua { }
    /// <summary>
    /// Class NhaCungCapModel.
    /// </summary>
    public class NhaCungCapModel : NhaCungCap { }

    /// <summary>
    /// Class QuyModel.
    /// </summary>
    public class QuyModel
    {
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public DateTime EndTime { get; set; }
    }

    /// <summary>
    /// Class NhanVienModel.
    /// </summary>
    public class NhanVienModel : NhanVien
    {
        /// <summary>
        /// Gets the ngay sinh model.
        /// </summary>
        /// <value>The ngay sinh model.</value>
        [DisplayName("Ngày sinh")]
        public virtual string NgaySinhModel {
            get
            {
                return NgaySinh.ToDateString();
            }
        }
    }
    /// <summary>
    /// Class NuocSanXuatModel.
    /// </summary>
    public class NuocSanXuatModel : NuocSanXuat { }

    /// <summary>
    /// Class SanPhamModel.
    /// </summary>
    public class SanPhamModel : SanPham
    {
        
    }
    /// <summary>
    /// Class TheLoaiModel.
    /// </summary>
    public class TheLoaiModel : TheLoai { }

}