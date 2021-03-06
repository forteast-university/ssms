﻿// ***********************************************************************
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
    public interface ISanPhamController<T>: IBaseController<T> {

        IList<string> ValidateAndFillup(T value);
        void HideSanPhamView();
        
        void CancelBackToListener();
        void SendBackToListener(T value);

        void ShowSanPhamView(T value);
        void ShowSanPhamViewMode(int value);
        void SetSanPhamListView(Form value);

        void ShowTheLoaiView(string ma);
        
        void ShowKichCoView(string ma);
        void ShowChatLieuView(string ma);
        void ShowMauView(string ma);
        void ShowDoiTuongView(string ma);
        void ShowMuaView(string ma);
        void ShowNuocSanXuatView(string ma);
        


    }
}