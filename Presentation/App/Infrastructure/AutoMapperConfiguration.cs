// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="AutoMapperConfiguration.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary>
// I have resovled some conflict between AutoMapper 4.1 vs AutoMapper 5.2
// </summary>
// ***********************************************************************
using App.Core.Domain;
using AutoMapper;
using App.Models;

namespace App.Infrastructure {
    /// <summary>
    /// Class AutoMapperConfiguration.
    /// </summary>
    public class AutoMapperConfiguration {
        /// <summary>
        /// The _mapper configuration. Only use for AutoMapper 5.2
        /// </summary>
        //private static MapperConfiguration mapperConfiguration;
        /// <summary>
        /// The _mapper. Only use for AutoMapper 5.2
        /// </summary>
        //private static IMapper mapper;

        /// <summary>
        /// Initializes this instance.
        /// Mapper.Initialize(cfg => {
        ///        cfg.CreateMap<{0}Model, {0}>();
        ///        cfg.CreateMap<{0}, {0}Model>();
        ///    });
        /// </summary>
        public static void Init() {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<ChatLieuModel, ChatLieu>();
                cfg.CreateMap<ChatLieu, ChatLieuModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<ChiTietHdbModel, ChiTietHDB>();
                cfg.CreateMap<ChiTietHDB, ChiTietHdbModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<ChiTietHdnModel, ChiTietHDN>();
                cfg.CreateMap<ChiTietHDN, ChiTietHdnModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<CongViecModel, CongViec>();
                cfg.CreateMap<CongViec, CongViecModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<DoiTuongModel, DoiTuong>();
                cfg.CreateMap<DoiTuong, DoiTuongModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<HoaDonBanModel, HoaDonBan>();
                cfg.CreateMap<HoaDonBan, HoaDonBanModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<HoaDonNhapModel, HoaDonNhap>();
                cfg.CreateMap<HoaDonNhap, HoaDonNhapModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<KhachHangModel, KhachHang>();
                cfg.CreateMap<KhachHang, KhachHangModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<KichCoModel, KichCo>();
                cfg.CreateMap<KichCo, KichCoModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<MauModel, Mau>();
                cfg.CreateMap<Mau, MauModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<MuaModel, Mua>();
                cfg.CreateMap<Mua, MuaModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<NhaCungCapModel, NhaCungCap>();
                cfg.CreateMap<NhaCungCap, NhaCungCapModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<NhanVienModel, NhanVien>();
                cfg.CreateMap<NhanVien, NhanVienModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<NuocSanXuatModel, NuocSanXuat>();
                cfg.CreateMap<NuocSanXuat, NuocSanXuatModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<SanPhamModel, SanPham>();
                cfg.CreateMap<SanPham, SanPhamModel>();
            });

            Mapper.Initialize(cfg => {
                cfg.CreateMap<TheLoaiModel, TheLoai>();
                cfg.CreateMap<TheLoai, TheLoaiModel>();
            });


            //Only use for AutoMapper 5.2
            //mapperConfiguration = new MapperConfiguration(c => {

            //    #region ProductApplicationModel, ProductApplication
            //    c.CreateMap<ChatLieuModel, ChatLieu>()
            //        //.ForMember(a => a.ID, b => b.Ignore())
            //        ;
            //    c.CreateMap<ChatLieu, ChatLieuModel>()
            //        //.ForMember(a => a.ID, b => b.Ignore())
            //        ;
            //    #endregion
            //});
            //mapper = mapperConfiguration.CreateMapper();
        }

        ///// <summary>
        ///// Mapper
        ///// </summary>
        ///// <value>The mapper. Only use for AutoMapper 5.2</value>
        //public static IMapper Mapper {
        //    get {
        //        return mapper;
        //    }
        //}
        ///// <summary>
        ///// Mapper configuration
        ///// Only use for AutoMapper 5.2
        ///// </summary>
        ///// <value>The mapper configuration.</value>
        //public static MapperConfiguration MapperConfiguration {
        //    get {
        //        return mapperConfiguration;
        //    }
        //}
    }
}