// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le, Cang Nguyen
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="Program.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary>
// Tutor: M.Sc Cuong Tran: tranduccuong121@gmail.com
//</summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using App.Core.Infrastructure;
using App.Views;
using Autofac;

namespace App {
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class App{
        [STAThread]
        public static void Main() {
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            AppFacade.Initialize(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(AppFacade.Container.Resolve<AppMediator>());
        }
    }
}
