// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="DependencyRegistrar.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using App.Core.Caching;
using App.Core.Configuration;
using App.Core.Infrastructure.DependencyManagement;
using App.Service.Business;
using App.Views;
using Autofac;
using Autofac.Core;

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
        public void Register(ContainerBuilder builder, App.Core.Infrastructure.ITypeFinder typeFinder, ServerConfig config) {
            //we cache presentation models between requests
            
            //builder.RegisterType<ErrorController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("app_cache_static"));
            builder.RegisterType<MainFrame>().WithParameter(ResolvedParameter.ForNamed<IChatLieuService>("1"));
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