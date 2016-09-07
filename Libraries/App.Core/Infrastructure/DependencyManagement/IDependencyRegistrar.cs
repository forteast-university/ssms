// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="IDependencyRegistrar.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ADA.Core.Configuration;
using Autofac;

namespace ADA.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// Dependency registrar interface
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, ServerConfig config);

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        /// <value>The order.</value>
        int Order { get; }
    }
}
