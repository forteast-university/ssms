// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="IEngine.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using ADA.Core.Configuration;
using ADA.Core.Infrastructure.DependencyManagement;

namespace ADA.Core.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the
    /// various services composing the App engine. Edit functionality, modules
    /// and implementations access most App functionality through this
    /// interface.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Container manager
        /// </summary>
        /// <value>The container manager.</value>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize components and plugins in the app environment.
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(ServerConfig config);

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T.</returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>System.Object.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T[].</returns>
        T[] ResolveAll<T>();
    }
}
