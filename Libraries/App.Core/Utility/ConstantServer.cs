// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="Constant.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace App.Core.Utility {
    /// <summary>
    /// Class ConstantServer.
    /// </summary>


    /// <summary>
    /// Class ConstantServer.
    /// </summary>
    public class ConstantServer {
        public ConstantServer(){}

        /// <summary>
        /// Enum DependencyMapping
        /// </summary>
        public enum DependencyMapping {
            /// <summary>
            /// The server
            /// </summary>
            Server = 1,
            /// <summary>
            /// The url
            /// </summary>
            Url = 2,
            /// <summary>
            /// The repos
            /// </summary>
            Product = 3,
            /// <summary>
            /// The repos application
            /// </summary>
            ProductApplication = 4
        }
    }
}
