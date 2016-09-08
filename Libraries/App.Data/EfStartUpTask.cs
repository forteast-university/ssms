// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="EfStartUpTask.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App.Core;
using App.Core.Infrastructure;

namespace App.Data
{
    /// <summary>
    /// Class EfStartUpTask.
    /// </summary>
    public class EfStartUpTask : IStartupTask
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
           // var settings = AppFacade.Current.Resolve<DataSettings>();
           // if (settings != null && settings.IsValid())
           // {
           //     var provider = AppFacade.Current.Resolve<IDataProvider>();
           //     if (provider == null)
           //         throw new AppException("No IDataProvider found");
           //     provider.SetDatabaseInitializer();
           // }
        }

        /// <summary>
        /// Order
        /// </summary>
        /// <value>The order.</value>
        public int Order
        {
            //ensure that this task is run first 
            get { return -1000; }
        }
    }
}
