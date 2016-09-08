// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="WebAppTypeFinder.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
//using System.Web;
//using System.Web.Hosting;

namespace App.Core.Infrastructure {
    /// <summary>
    /// Provides information about types in the current web application.
    /// Optionally this class can look at all assemblies in the bin folder.
    /// </summary>
    public class WebAppTypeFinder: AppDomainTypeFinder {
        #region Fields

        /// <summary>
        /// The ensure bin folder assemblies loaded
        /// </summary>
        private bool ensureBinFolderAssembliesLoaded = true;
        /// <summary>
        /// The bin folder assemblies loaded
        /// </summary>
        private bool binFolderAssembliesLoaded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether assemblies in the bin folder of the web application should be specifically checked for being loaded on application load. This is need in situations where plugins need to be loaded in the AppDomain after the application been reloaded.
        /// </summary>
        /// <value><c>true</c> if [ensure bin folder assemblies loaded]; otherwise, <c>false</c>.</value>
        public bool EnsureBinFolderAssembliesLoaded {
            get { return ensureBinFolderAssembliesLoaded; }
            set { ensureBinFolderAssembliesLoaded = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a physical disk path of \Bin directory
        /// </summary>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        public virtual string GetBinDirectory() {
            //if(HostingEnvironment.IsHosted) {
            //    //hosted
            //    return HttpRuntime.BinDirectory;
            //}

            //not hosted. For example, run either in unit tests
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Gets the assemblies related to the current implementation.
        /// </summary>
        /// <returns>A list of assemblies that should be loaded by the App factory.</returns>
        public override IList<Assembly> GetAssemblies() {
            if(EnsureBinFolderAssembliesLoaded && !binFolderAssembliesLoaded) {
                binFolderAssembliesLoaded = true;
                var binPath = GetBinDirectory();
                //binPath = _webHelper.MapPath("~/bin");
                LoadMatchingAssemblies(binPath);
            }

            return base.GetAssemblies();
        }

        #endregion
    }
}
