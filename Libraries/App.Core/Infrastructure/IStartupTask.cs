// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="IStartupTask.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Infrastructure
{
    /// <summary>
    /// Interface which should be implemented by tasks run on startup
    /// </summary>
    public interface IStartupTask 
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        void Execute();

        /// <summary>
        /// Order
        /// </summary>
        /// <value>The order.</value>
        int Order { get; }
    }
}
