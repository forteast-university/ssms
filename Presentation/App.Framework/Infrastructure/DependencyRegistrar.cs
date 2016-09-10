// ***********************************************************************
// Assembly         : App.Framework
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="DependencyRegistrar.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using App.Core.Caching;
using App.Core.Configuration;
using App.Core.Data;
using App.Core.Infrastructure;
using App.Core.Infrastructure.DependencyManagement;
using App.Data;
using App.Service.Business;
using Autofac;

namespace App.Framework.Infrastructure{
    /// <summary>
    ///     Class DependencyRegistrar.
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar{
        /// <summary>
        ///     Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, ServerConfig config){
            var dataSettingsManager = new DataSettingsManager();
            DataSettings dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.CacheSettings).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>()))
                .As<BaseDataProviderManager>()
                .InstancePerDependency();

            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider())
                .As<IDataProvider>()
                .InstancePerDependency();

            if (dataProviderSettings != null && dataProviderSettings.IsValid()){
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.CacheSettings);
                IDataProvider dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();
                builder.Register<IDbContext>(c => new AppContext(dataProviderSettings.DataConnectionString))
                    .InstancePerLifetimeScope();
            }
            else{
                builder.Register<IDbContext>(
                    c => new AppContext(dataSettingsManager.CacheSettings.DataConnectionString))
                    .InstancePerLifetimeScope();
            }

            builder.RegisterGeneric(typeof (EfRepository<>)).As(typeof (IRepository<>)).InstancePerLifetimeScope();

            /*********************************************  
                CACHE MANAGERS
            *********************************************/
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("app_cache_static").SingleInstance();

            /*************************************************************  
                REGISTER TYPE SERVCIES
            *************************************************************/
            builder.RegisterType<ChatLieuService>().As<IChatLieuService>().SingleInstance();
            builder.RegisterType<ChiTietHDBService>().As<IChiTietHDBService>().SingleInstance();
            builder.RegisterType<ChiTietHDNService>().As<IChiTietHDNService>().SingleInstance();
            builder.RegisterType<CongViecService>().As<ICongViecService>().SingleInstance();
            builder.RegisterType<DoiTuongService>().As<IDoiTuongService>().SingleInstance();
            builder.RegisterType<HoaDonBanService>().As<IHoaDonBanService>().SingleInstance();
            builder.RegisterType<HoaDonNhapService>().As<IHoaDonNhapService>().SingleInstance();
            builder.RegisterType<KhachHangService>().As<IKhachHangService>().SingleInstance();
            builder.RegisterType<KichCoService>().As<IKichCoService>().SingleInstance();
            builder.RegisterType<MauService>().As<IMauService>().SingleInstance();
            builder.RegisterType<MuaService>().As<IMuaService>().SingleInstance();
            builder.RegisterType<NhaCungCapService>().As<INhaCungCapService>().SingleInstance();
            builder.RegisterType<NhanVienService>().As<INhanVienService>().SingleInstance();
            builder.RegisterType<NuocSanXuatService>().As<INuocSanXuatService>().SingleInstance();
            builder.RegisterType<SanPhamService>().As<ISanPhamService>().SingleInstance();
            builder.RegisterType<TheLoaiService>().As<ITheLoaiService>().SingleInstance();
            

        }

        /// <summary>
        ///     Gets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order{
            get { return 0; }
        }
    }
}