// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="Program.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using App.Core.Infrastructure;
using Autofac;

namespace App.Views {
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <value>The container.</value>
        public static IContainer Container { get; set; }
        public static IEngine Engine { get; set; }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [STAThread]
        static void Main() {
            AppFacade.Initialize(false);
            
            Container = AppFacade.Current.ContainerManager.Container;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<MainFrame>());

            //using (var scope = Container.BeginLifetimeScope()) {
            //    Application.Run(scope.Resolve<MainFrame>());        //scope.Resolve<Form1>().DisplayView(); //Display the child form
            //}
        }
    }
}
