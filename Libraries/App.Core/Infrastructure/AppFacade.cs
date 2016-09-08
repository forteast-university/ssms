// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="AppFacade.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.CompilerServices;
using App.Core.Configuration;
using System.Configuration;

namespace App.Core.Infrastructure {
    /// <summary>
    /// Provides access to the singleton instance of the App engine.
    /// </summary>
    public class AppFacade {
        #region Methods

        /// <summary>
        /// Initializes a static instance of the App factory.
        /// </summary>
        /// <param name="forceRecreate">Creates a new factory instance even though the factory has been previously initialized.</param>
        /// <returns>IEngine.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate) {
            if(Singleton<IEngine>.Instance == null || forceRecreate) {
                Singleton<IEngine>.Instance = new AppEngine();
                var config = ConfigurationManager.GetSection("ServerConfig") as ServerConfig;
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IEngine engine) {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the singleton App engine used to access App services.
        /// </summary>
        /// <value>The current.</value>
        public static IEngine Current {
            get {
                if(Singleton<IEngine>.Instance == null) {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }
}
