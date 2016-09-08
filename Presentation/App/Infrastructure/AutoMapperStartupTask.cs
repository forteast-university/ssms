// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="AutoMapperStartupTask.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App.Core.Infrastructure;

namespace App.Infrastructure
{
    /// <summary>
    /// Startup class for AutoMapper
    /// </summary>
    public class AutoMapperStartupTask : IStartupTask
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            AutoMapperConfiguration.Init();
        }

        /// <summary>
        /// Order
        /// </summary>
        /// <value>The order.</value>
        public int Order
        {
            get { return 0; }
        }
    }
}