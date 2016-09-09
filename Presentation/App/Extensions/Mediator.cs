﻿// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="AppMediatorEvent.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Extensions {
    /// <summary>
    /// Class AppMediatorEvent.
    /// </summary>
    public class Mediator{
        public static string DANGNHAP_THANH_CONG = "DANG_NHAP_THANH_CONG";
        public static string DANGNHAP_KHONG_THANH_CONG = "DANG_NHAP_KHONG_THANH_CONG";
    }

    public class AppEvent<T> : EventArgs{

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// 
        public T value{
            get;
            set;
        }
        public string Name {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address {
            get;
            set;
        }
    }
}