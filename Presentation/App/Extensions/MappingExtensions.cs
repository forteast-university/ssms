// ***********************************************************************
// Assembly         : ServerMapper
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-08-2016
// ***********************************************************************
// <copyright file="MappingExtensions.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Domain;
using App.Infrastructure;
using App.Models;

namespace App.Extensions{
    /// <summary>
    /// Class MappingExtensions.
    /// </summary>
    public static class MappingExtensions{
        /// <summary>
        /// Maps to.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TDestination">The type of the t destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>TDestination.</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source){
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps to.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TDestination">The type of the t destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>TDestination.</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination){
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        /// <summary>
        /// To the encode link.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="superset">The superset.</param>
        /// <returns>System.String.</returns>
        public static string ToEncodeLink<T>(this T superset){
            var m = superset as string;
            if (m == null)
                return "";
            if (m.Trim() == "")
                return "";

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(m);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// To the decode link.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="superset">The superset.</param>
        /// <returns>System.String.</returns>
        public static string ToDecodeLink<T>(this T superset){
            var m = superset as string;
            if (m == null)
                return "";
            if (m.Trim() == "")
                return "";

            byte[] base64EncodedBytes = Convert.FromBase64String(m);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Serializes the specified superset.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="superset">The superset.</param>
        /// <returns>System.String.</returns>
        public static string Serialize<T>(this IEnumerable<T> superset){
            //if (Singleton<JavaScriptSerializer>.Instance == null){
            //    Singleton<JavaScriptSerializer>.Instance = new JavaScriptSerializer {MaxJsonLength = Int32.MaxValue};
            //}
            //var k = Singleton<JavaScriptSerializer>.Instance;
            ////var result = new ContentResult {
            ////    Content = serializer.Serialize(resultData),
            ////    ContentType = "application/json"
            ////};
            //return k.Serialize(superset);
            return "";
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ChatLieuModel.</returns>
        public static ChatLieuModel ToModel(this ChatLieu entity){
            return entity.MapTo<ChatLieu, ChatLieuModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ChatLieu.</returns>
        public static ChatLieu ToEntity(this ChatLieuModel model){
            return model.MapTo<ChatLieuModel, ChatLieu>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>ChatLieu.</returns>
        public static ChatLieu ToEntity(this ChatLieuModel model, ChatLieu destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ChiTietHdbModel.</returns>
        public static ChiTietHdbModel ToModel(this ChiTietHDB entity){
            return entity.MapTo<ChiTietHDB, ChiTietHdbModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ChiTietHDB.</returns>
        public static ChiTietHDB ToEntity(this ChiTietHdbModel model){
            return model.MapTo<ChiTietHdbModel, ChiTietHDB>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>ChiTietHDB.</returns>
        public static ChiTietHDB ToEntity(this ChiTietHdbModel model, ChiTietHDB destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ChiTietHdnModel.</returns>
        public static ChiTietHdnModel ToModel(this ChiTietHDN entity){
            return entity.MapTo<ChiTietHDN, ChiTietHdnModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ChiTietHDN.</returns>
        public static ChiTietHDN ToEntity(this ChiTietHdnModel model){
            return model.MapTo<ChiTietHdnModel, ChiTietHDN>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>ChiTietHDN.</returns>
        public static ChiTietHDN ToEntity(this ChiTietHdnModel model, ChiTietHDN destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CongViecModel.</returns>
        public static CongViecModel ToModel(this CongViec entity){
            return entity.MapTo<CongViec, CongViecModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>CongViec.</returns>
        public static CongViec ToEntity(this CongViecModel model){
            return model.MapTo<CongViecModel, CongViec>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>CongViec.</returns>
        public static CongViec ToEntity(this CongViecModel model, CongViec destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>DoiTuongModel.</returns>
        public static DoiTuongModel ToModel(this DoiTuong entity){
            return entity.MapTo<DoiTuong, DoiTuongModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>DoiTuong.</returns>
        public static DoiTuong ToEntity(this DoiTuongModel model){
            return model.MapTo<DoiTuongModel, DoiTuong>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>DoiTuong.</returns>
        public static DoiTuong ToEntity(this DoiTuongModel model, DoiTuong destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>HoaDonBanModel.</returns>
        public static HoaDonBanModel ToModel(this HoaDonBan entity){
            return entity.MapTo<HoaDonBan, HoaDonBanModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>HoaDonBan.</returns>
        public static HoaDonBan ToEntity(this HoaDonBanModel model){
            return model.MapTo<HoaDonBanModel, HoaDonBan>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>HoaDonBan.</returns>
        public static HoaDonBan ToEntity(this HoaDonBanModel model, HoaDonBan destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>HoaDonNhapModel.</returns>
        public static HoaDonNhapModel ToModel(this HoaDonNhap entity){
            return entity.MapTo<HoaDonNhap, HoaDonNhapModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>HoaDonNhap.</returns>
        public static HoaDonNhap ToEntity(this HoaDonNhapModel model){
            return model.MapTo<HoaDonNhapModel, HoaDonNhap>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>HoaDonNhap.</returns>
        public static HoaDonNhap ToEntity(this HoaDonNhapModel model, HoaDonNhap destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>KhachHangModel.</returns>
        public static KhachHangModel ToModel(this KhachHang entity){
            return entity.MapTo<KhachHang, KhachHangModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>KhachHang.</returns>
        public static KhachHang ToEntity(this KhachHangModel model){
            return model.MapTo<KhachHangModel, KhachHang>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>KhachHang.</returns>
        public static KhachHang ToEntity(this KhachHangModel model, KhachHang destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>KichCoModel.</returns>
        public static KichCoModel ToModel(this KichCo entity){
            return entity.MapTo<KichCo, KichCoModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>KichCo.</returns>
        public static KichCo ToEntity(this KichCoModel model){
            return model.MapTo<KichCoModel, KichCo>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>KichCo.</returns>
        public static KichCo ToEntity(this KichCoModel model, KichCo destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>MauModel.</returns>
        public static MauModel ToModel(this Mau entity){
            return entity.MapTo<Mau, MauModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Mau.</returns>
        public static Mau ToEntity(this MauModel model){
            return model.MapTo<MauModel, Mau>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>Mau.</returns>
        public static Mau ToEntity(this MauModel model, Mau destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>MuaModel.</returns>
        public static MuaModel ToModel(this Mua entity){
            return entity.MapTo<Mua, MuaModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Mua.</returns>
        public static Mua ToEntity(this MuaModel model){
            return model.MapTo<MuaModel, Mua>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>Mua.</returns>
        public static Mua ToEntity(this MuaModel model, Mua destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>NhaCungCapModel.</returns>
        public static NhaCungCapModel ToModel(this NhaCungCap entity){
            return entity.MapTo<NhaCungCap, NhaCungCapModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>NhaCungCap.</returns>
        public static NhaCungCap ToEntity(this NhaCungCapModel model){
            return model.MapTo<NhaCungCapModel, NhaCungCap>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>NhaCungCap.</returns>
        public static NhaCungCap ToEntity(this NhaCungCapModel model, NhaCungCap destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>NhanVienModel.</returns>
        public static NhanVienModel ToModel(this NhanVien entity){
            return entity.MapTo<NhanVien, NhanVienModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>NhanVien.</returns>
        public static NhanVien ToEntity(this NhanVienModel model){
            return model.MapTo<NhanVienModel, NhanVien>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>NhanVien.</returns>
        public static NhanVien ToEntity(this NhanVienModel model, NhanVien destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>NuocSanXuatModel.</returns>
        public static NuocSanXuatModel ToModel(this NuocSanXuat entity){
            return entity.MapTo<NuocSanXuat, NuocSanXuatModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>NuocSanXuat.</returns>
        public static NuocSanXuat ToEntity(this NuocSanXuatModel model){
            return model.MapTo<NuocSanXuatModel, NuocSanXuat>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>NuocSanXuat.</returns>
        public static NuocSanXuat ToEntity(this NuocSanXuatModel model, NuocSanXuat destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SanPhamModel.</returns>
        public static SanPhamModel ToModel(this SanPham entity){
            return entity.MapTo<SanPham, SanPhamModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>SanPham.</returns>
        public static SanPham ToEntity(this SanPhamModel model){
            return model.MapTo<SanPhamModel, SanPham>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>SanPham.</returns>
        public static SanPham ToEntity(this SanPhamModel model, SanPham destination){
            return model.MapTo(destination);
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TheLoaiModel.</returns>
        public static TheLoaiModel ToModel(this TheLoai entity){
            return entity.MapTo<TheLoai, TheLoaiModel>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TheLoai.</returns>
        public static TheLoai ToEntity(this TheLoaiModel model){
            return model.MapTo<TheLoaiModel, TheLoai>();
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>TheLoai.</returns>
        public static TheLoai ToEntity(this TheLoaiModel model, TheLoai destination){
            return model.MapTo(destination);
        }

        #region For clone

        #region {0}

        //public static {0}Model ToModel(this {0} entity) { return entity.MapTo<{0}, {0}Model>(); }
        //public static {0} ToEntity(this {0}Model model) { return model.MapTo<{0}Model, {0}>(); }
        //public static {0} ToEntity(this {0}Model model, {0} destination) { return model.MapTo(destination); }

        #endregion

        #endregion
    }
}