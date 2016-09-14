// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 08-28-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-28-2016
// ***********************************************************************
// <copyright file="DependencyRegistrar.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using App.Controllers;
using App.Controllers.Interface;
using App.Core.Caching;
using App.Core.Configuration;
using App.Core.Infrastructure;
using App.Core.Infrastructure.DependencyManagement;
using App.Models;
using App.Views;
using Autofac;

namespace App.Infrastructure {
    /// <summary>
    /// Class DependencyRegistrar.
    /// </summary>
    public class DependencyRegistrar: IDependencyRegistrar {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, ServerConfig config) {
            builder.RegisterType<ChatLieuController>().As<IBaseController<ChatLieuModel>>().SingleInstance();
            builder.RegisterType<CongViecController>().As<ICongViecController<CongViecModel>>().SingleInstance();
            builder.RegisterType<KhachHangController>().As<IBaseController<KhachHangModel>>().SingleInstance();
            builder.RegisterType<KichCoController>().As<IBaseController<KichCoModel>>().SingleInstance();
            builder.RegisterType<MauController>().As<IBaseController<MauModel>>().SingleInstance();
            builder.RegisterType<MuaController>().As<IBaseController<MuaModel>>().SingleInstance();
            builder.RegisterType<NhaCungCapController>().As<IBaseController<NhaCungCapModel>>().SingleInstance();
            builder.RegisterType<NuocSanXuatController>().As<IBaseController<NuocSanXuatModel>>().SingleInstance();
            builder.RegisterType<TheLoaiController>().As<IBaseController<TheLoaiModel>>().SingleInstance();
            builder.RegisterType<DoiTuongController>().As<IBaseController<DoiTuongModel>>().SingleInstance();
            builder.RegisterType<NhanVienController>().As<INhanVienController<NhanVienModel>>().SingleInstance();
            builder.RegisterType<SanPhamController>().As<ISanPhamController<SanPhamModel>>().SingleInstance();
            builder.RegisterType<HoaDonNhapController>().As<IHoaDonNhapController<HoaDonNhapModel>>().SingleInstance();
            builder.RegisterType<HoaDonBanController>().As<IHoaDonBanController<HoaDonBanModel>>().SingleInstance();
            builder.RegisterType<AppMediator>();
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order {
            get { return 2; }
        }
    }
}