// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="AppEngine.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using ADA.Core.Configuration;
using ADA.Core.Infrastructure.DependencyManagement;
using Autofac;
//using Autofac.Integration.Mvc;

namespace ADA.Core.Infrastructure {
    /// <summary>
    /// Engine
    /// </summary>
    public class AppEngine: IEngine {
        #region Fields

        /// <summary>
        /// The container manager
        /// </summary>
        private ContainerManager containerManager;

        #endregion

        #region Utilities

        /// <summary>
        /// Run startup tasks
        /// </summary>
        protected virtual void RunStartupTasks() {
            var typeFinder = containerManager.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = new List<IStartupTask>();
            foreach (var startUpTaskType in startUpTaskTypes)
            {
                startUpTasks.Add((IStartupTask)Activator.CreateInstance(startUpTaskType));
            }
            //sort
            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
            {
                startUpTask.Execute();
            }
        }

        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="config">Config</param>
        protected virtual void RegisterDependencies(ServerConfig config) {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            containerManager = new ContainerManager(container);

            //we create new instance of ContainerBuilder
            //because Build() or Update() method can only be called once on a ContainerBuilder.

            //dependencies
            var typeFinder = new WebAppTypeFinder();
            builder = new ContainerBuilder();
            builder.RegisterInstance(config).As<ServerConfig>().SingleInstance();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.Update(container);

            //register dependencies provided by other assemblies
            builder = new ContainerBuilder();
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
            {
                drInstances.Add((IDependencyRegistrar) Activator.CreateInstance(drType));
            }
            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
            {
                dependencyRegistrar.Register(builder, typeFinder, config);
            }
            builder.Update(container);

            //set dependency resolver
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            container = builder.Build();

        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize components and plugins in the app environment.
        /// </summary>
        /// <param name="config">Config</param>
        public void Initialize(ServerConfig config) {
            //register dependencies
            RegisterDependencies(config);

            //startup tasks
            if(!config.IgnoreStartupTasks) {
                RunStartupTasks();
            }

        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T.</returns>
        public T Resolve<T>() where T: class {
            return ContainerManager.Resolve<T>();
        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>System.Object.</returns>
        public object Resolve(Type type) {
            return ContainerManager.Resolve(type);
        }

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T[].</returns>
        public T[] ResolveAll<T>() {
            return ContainerManager.ResolveAll<T>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Container manager
        /// </summary>
        /// <value>The container manager.</value>
        public ContainerManager ContainerManager {
            get { return containerManager; }
        }

        #endregion
    }
}
