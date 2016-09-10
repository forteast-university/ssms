// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="ProductModel.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary>
// -------------------------
// ChatLieu
// ChiTietHDB
// ChiTietHDN
// CongViec
// DoiTuong
// HoaDonBan
// HoaDonNhap
// KhachHang
// KichCo
// Mau
// Mua
// NhaCungCap
// NhanVien
// NuocSanXuat
// SanPham
// TheLoai
// -------------------------
// ChatLieu,ChiTietHDB,ChiTietHDN,CongViec,DoiTuong,HoaDonBan,HoaDonNhap,KhachHang,KichCo,Mau,Mua,NhaCungCap,NhanVien,NuocSanXuat,SanPham,TheLoai
//</summary>
// ***********************************************************************

using System.ComponentModel;
using App.Core.Domain;
using App.Extensions;

namespace App.Models{
    /// <summary>
    /// Do the right thing :D 
    /// Add your model to here,
    /// Should not inherit Domain Class if you don't know why i do that!
    /// Class ProductModel.
    /// </summary>
    public class ChatLieuModel : ChatLieu { }
    public class ChiTietHdbModel : ChiTietHDB { }
    public class ChiTietHdnModel : ChiTietHDN { }
    public class CongViecModel : CongViec { }
    public class DoiTuongModel : DoiTuong { }
    public class HoaDonBanModel : HoaDonBan { }
    public class HoaDonNhapModel : HoaDonNhap { }
    public class KhachHangModel : KhachHang { }
    public class KichCoModel : KichCo { }
    public class MauModel : Mau { }
    public class MuaModel : Mua { }
    public class NhaCungCapModel : NhaCungCap { }

    public class NhanVienModel : NhanVien
    {
        [DisplayName("Ngày sinh")]
        public virtual string NgaySinhModel {
            get
            {
                return NgaySinh.ToDateString();
            }
        }
    }
    public class NuocSanXuatModel : NuocSanXuat { }
    public class SanPhamModel : SanPham { }
    public class TheLoaiModel : TheLoai { }

}