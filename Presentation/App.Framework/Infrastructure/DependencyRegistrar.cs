using System.Linq;
using App.Core.Caching;
using App.Core.Configuration;
using App.Core.Data;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Core.Infrastructure.DependencyManagement;
using App.Data;
using App.Service;
using App.Service.Business;
using Autofac;

namespace App.Framework.Infrastructure {
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

           var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();


            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            if(dataProviderSettings != null && dataProviderSettings.IsValid()) {
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();
                builder.Register<IDbContext>(c => new AppContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            } else {
                builder.Register<IDbContext>(c => new AppContext(dataSettingsManager.LoadSettings().DataConnectionString)).InstancePerLifetimeScope();
            }

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            /*********************************************  
                CACHE MANAGERS
            *********************************************/
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("app_cache_static").SingleInstance();

            /*************************************************************  
                BUSINESS OR SERVCIES
            *************************************************************/
            builder.RegisterType<ChatLieuService>().As<IChatLieuService>().SingleInstance();
            
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order {
            get { return 0; }
        }
    }
}