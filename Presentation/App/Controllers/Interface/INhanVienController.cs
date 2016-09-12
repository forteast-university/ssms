// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-08-2016
// ***********************************************************************
// <copyright file="IChatLieuController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.Extensions;
using App.Models;

namespace App.Controllers.Interface{
    /// <summary>
    /// Interface IChatLieuController
    /// </summary>
    public interface INhanVienController<T> : IBaseController<T>
    {

        IList<string> ValidateAndFillup(NhanVienModel value);
        IList<NhanVienModel> Get(string value);
        void ShowDangNhap();
        void CloseParent();
        void DangNhap(T value);
        void ShowCongViecView(string ma);
    }
}