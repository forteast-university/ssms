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
            /// The product
            /// </summary>
            Product = 3,
            /// <summary>
            /// The product application
            /// </summary>
            ProductApplication = 4
        }

        /// <summary>
        /// The serve r_ optional list
        /// </summary>
        public static List<SearchOptionalList> OptionalList(){
            return new List<SearchOptionalList>{
                new SearchOptionalList{Id = 1, Selected = false, Value = "Server"},
                new SearchOptionalList{Id = 2, Selected = false, Value = "URL"},
                new SearchOptionalList{Id = 3, Selected = false, Value = "Product"},
                new SearchOptionalList{Id = 4, Selected = false, Value = "Application"}
            };
        } 
        public static IEnumerable<string> ServerEnvironment = new List<string> { "DEV", "PPD", "PROD", "DR" };
        /// <summary>
        /// The serve r_ type
        /// </summary>
        public static IEnumerable<string> ServerType = new List<string> { "FTP", "SMTP", "Web", "App", "Database", "Web API" };
    }
}
