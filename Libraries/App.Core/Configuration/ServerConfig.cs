// ***********************************************************************
// Assembly         : ADA.Core
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

namespace ADA.Core.Configuration {
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

            //ConnectionString = ConfigurationManager.ConnectionStrings["ServerMapperEntities"].ConnectionString;

            var config = new ServerConfig();

            var startupNode = section.SelectSingleNode("Startup");
            config.IgnoreStartupTasks = GetBool(startupNode, "IgnoreStartupTasks");

            var redisCachingNode = section.SelectSingleNode("RedisCaching");
            config.RedisCachingEnabled = GetBool(redisCachingNode, "Enabled");
            config.RedisCachingConnectionString = GetString(redisCachingNode, "ConnectionString");

            var webFarmsNode = section.SelectSingleNode("WebFarms");
            config.MultipleInstancesEnabled = GetBool(webFarmsNode, "MultipleInstancesEnabled");
            config.RunOnAzureWebsites = GetBool(webFarmsNode, "RunOnAzureWebsites");

            var azureBlobStorageNode = section.SelectSingleNode("AzureBlobStorage");
            config.AzureBlobStorageConnectionString = GetString(azureBlobStorageNode, "ConnectionString");
            config.AzureBlobStorageContainerName = GetString(azureBlobStorageNode, "ContainerName");
            config.AzureBlobStorageEndPoint = GetString(azureBlobStorageNode, "EndPoint");

            var installationNode = section.SelectSingleNode("Installation");
            config.DisableSampleDataDuringInstallation = GetBool(installationNode, "DisableSampleDataDuringInstallation");
            config.UseFastInstallationService = GetBool(installationNode, "UseFastInstallationService");

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
        /// Indicates whether we should ignore startup tasks
        /// </summary>
        /// <value><c>true</c> if [ignore startup tasks]; otherwise, <c>false</c>.</value>
        public bool IgnoreStartupTasks { get; private set; }

        /// <summary>
        /// Indicates whether we should use Redis server for caching (instead of default in-memory caching)
        /// </summary>
        /// <value><c>true</c> if [redis caching enabled]; otherwise, <c>false</c>.</value>
        public bool RedisCachingEnabled { get; private set; }
        /// <summary>
        /// Redis connection string. Used when Redis caching is enabled
        /// </summary>
        /// <value>The redis caching connection string.</value>
        public string RedisCachingConnectionString { get; private set; }
        
        /// <summary>
        /// A value indicating whether the site is run on multiple instances (e.g. web farm, Windows Azure with multiple instances, etc).
        /// Do not enable it if you run on Azure but use one instance only
        /// </summary>
        /// <value><c>true</c> if [multiple instances enabled]; otherwise, <c>false</c>.</value>
        public bool MultipleInstancesEnabled { get; private set; }

        /// <summary>
        /// A value indicating whether the site is run on Windows Azure Websites
        /// </summary>
        /// <value><c>true</c> if [run on azure websites]; otherwise, <c>false</c>.</value>
        public bool RunOnAzureWebsites { get; private set; }

        /// <summary>
        /// Connection string for Azure BLOB storage
        /// </summary>
        /// <value>The azure BLOB storage connection string.</value>
        public string AzureBlobStorageConnectionString { get; private set; }
        /// <summary>
        /// Container name for Azure BLOB storage
        /// </summary>
        /// <value>The name of the azure BLOB storage container.</value>
        public string AzureBlobStorageContainerName { get; private set; }
        /// <summary>
        /// End point for Azure BLOB storage
        /// </summary>
        /// <value>The azure BLOB storage end point.</value>
        public string AzureBlobStorageEndPoint { get; private set; }


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
        

        /// <summary>
        /// Gets the connecttion string.
        /// </summary>
        /// <value>The connecttion string.</value>
        public string ConnectionString { get; private set; }
    }
}
