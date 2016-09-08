// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="ServerConfig.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Configuration;
using System.Xml;

namespace App.Core.Configuration {
    /// <summary>
    /// Represents a ServerConfig
    /// </summary>
    public class ServerConfig: IConfigurationSectionHandler {
        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>The created section handler object.</returns>
        public object Create(object parent, object configContext, XmlNode section) {
            var config = new ServerConfig();

            var node = section.SelectSingleNode("Installation");
                config.DisableSampleDataDuringInstallation = GetBool(node, "DisableSampleDataDuringInstallation");
                config.UseFastInstallationService = GetBool(node, "UseFastInstallationService");

            return config;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="attrName">Name of the attribute.</param>
        /// <returns>System.String.</returns>
        private string GetString(XmlNode node, string attrName) {
            return SetByXElement(node, attrName, Convert.ToString);
        }

        /// <summary>
        /// Gets the bool.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="attrName">Name of the attribute.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool GetBool(XmlNode node, string attrName) {
            return SetByXElement(node, attrName, Convert.ToBoolean);
        }

        /// <summary>
        /// Sets the by x element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node">The node.</param>
        /// <param name="attrName">Name of the attribute.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>T.</returns>
        private T SetByXElement<T>(XmlNode node, string attrName, Func<string, T> converter) {
            if(node == null || node.Attributes == null)
                return default(T);
            var attr = node.Attributes[attrName];
            if(attr == null)
                return default(T);
            var attrVal = attr.Value;
            return converter(attrVal);
        }

        /// <summary>
        /// A value indicating whether a store owner can install sample data during installation
        /// </summary>
        /// <value><c>true</c> if [disable sample data during installation]; otherwise, <c>false</c>.</value>
        public bool DisableSampleDataDuringInstallation { get; private set; }
        /// <summary>
        /// By default this setting should always be set to "False" (only for advanced users)
        /// </summary>
        /// <value><c>true</c> if [use fast installation service]; otherwise, <c>false</c>.</value>
        public bool UseFastInstallationService { get; private set; }
    }
}
