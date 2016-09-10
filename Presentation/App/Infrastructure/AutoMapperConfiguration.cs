// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-08-2016
// ***********************************************************************
// <copyright file="AutoMapperConfiguration.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary>I have resovled some conflict between AutoMapper 4.1 vs AutoMapper 5.2</summary>
// ***********************************************************************

using App.Core.Domain;
using App.Models;
using AutoMapper;
using AutoMapper.Mappers;

namespace App.Infrastructure{
    /// <summary>
    /// Class AutoMapperConfiguration.
    /// </summary>
    public class AutoMapperConfiguration{
        /// <summary>
        /// The _mapper configuration. Only use for AutoMapper 5.2
        /// </summary>
        private static ConfigurationStore mapperConfiguration;

        /// <summary>
        /// The _mapper. Only use for AutoMapper 5.2
        /// </summary>
        private static IMappingEngine mapper;

        ///// <summary>
        ///// Mapper
        ///// </summary>
        ///// <value>The mapper. Only use for AutoMapper 5.2</value>
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <value>The mapper.</value>
        public static IMappingEngine Mapper{
            get { return mapper; }
        }

        ///// <summary>
        ///// Mapper configuration
        ///// Only use for AutoMapper 5.2
        ///// </summary>
        ///// <value>The mapper configuration.</value>
        /// <summary>
        /// Gets the mapper configuration.
        /// </summary>
        /// <value>The mapper configuration.</value>
        public static ConfigurationStore MapperConfiguration{
            get { return mapperConfiguration; }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Init(){
            mapperConfiguration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);

            //AutoMapper.Mapper.Initialize(cfg => {
            mapperConfiguration.CreateMap<ChatLieuModel, ChatLieu>();
            mapperConfiguration.CreateMap<ChatLieu, ChatLieuModel>();

            mapperConfiguration.CreateMap<ChiTietHdbModel, ChiTietHDB>();
            mapperConfiguration.CreateMap<ChiTietHDB, ChiTietHdbModel>();

            mapperConfiguration.CreateMap<ChiTietHdnModel, ChiTietHDN>();
            mapperConfiguration.CreateMap<ChiTietHDN, ChiTietHdnModel>();

            mapperConfiguration.CreateMap<CongViecModel, CongViec>();
            mapperConfiguration.CreateMap<CongViec, CongViecModel>();

            mapperConfiguration.CreateMap<DoiTuongModel, DoiTuong>();
            mapperConfiguration.CreateMap<DoiTuong, DoiTuongModel>();

            mapperConfiguration.CreateMap<HoaDonBanModel, HoaDonBan>();
            mapperConfiguration.CreateMap<HoaDonBan, HoaDonBanModel>();

            mapperConfiguration.CreateMap<HoaDonNhapModel, HoaDonNhap>();
            mapperConfiguration.CreateMap<HoaDonNhap, HoaDonNhapModel>();

            mapperConfiguration.CreateMap<KhachHangModel, KhachHang>();
            mapperConfiguration.CreateMap<KhachHang, KhachHangModel>();

            mapperConfiguration.CreateMap<KichCoModel, KichCo>();
            mapperConfiguration.CreateMap<KichCo, KichCoModel>();

            mapperConfiguration.CreateMap<MauModel, Mau>();
            mapperConfiguration.CreateMap<Mau, MauModel>();

            mapperConfiguration.CreateMap<MuaModel, Mua>();
            mapperConfiguration.CreateMap<Mua, MuaModel>();

            mapperConfiguration.CreateMap<NhaCungCapModel, NhaCungCap>();
            mapperConfiguration.CreateMap<NhaCungCap, NhaCungCapModel>();

            mapperConfiguration.CreateMap<NhanVienModel, NhanVien>();
            mapperConfiguration.CreateMap<NhanVien, NhanVienModel>();

            mapperConfiguration.CreateMap<NuocSanXuatModel, NuocSanXuat>();
            mapperConfiguration.CreateMap<NuocSanXuat, NuocSanXuatModel>();

            mapperConfiguration.CreateMap<SanPhamModel, SanPham>()
                .ForMember(a => a.KichCo, b => b.Ignore())
                .ForMember(a => a.Mau, b => b.Ignore())
                .ForMember(a => a.DoiTuong, b => b.Ignore())
                .ForMember(a => a.ChatLieu, b => b.Ignore())
                .ForMember(a => a.Mua, b => b.Ignore())
                .ForMember(a => a.NuocSanXuat, b => b.Ignore())
                .ForMember(a => a.TheLoai, b => b.Ignore())
                ;
            mapperConfiguration.CreateMap<SanPham, SanPhamModel>()
                //.ForMember(a => a.Test, b => b.Ignore())
                ;

            mapperConfiguration.CreateMap<TheLoaiModel, TheLoai>();
            mapperConfiguration.CreateMap<TheLoai, TheLoaiModel>();
            //});
               
            mapper = new MappingEngine(mapperConfiguration);

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
    }
}