// ***********************************************************************
// Assembly         : App.Service
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="IChatLieuService.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface IHoaDonNhapService
    /// </summary>
    public interface IHoaDonNhapService : ICommonService<HoaDonNhap>
    {
        /// <summary>
        /// Gets hoa don nhap by team.
        /// </summary>
        /// <param name="SoHDN">so hoa don nhap.</param>
        /// <returns>List&lt;HoaDonNhap&gt;.</returns>
        List<HoaDonNhap> GetBaoCaoTheoQuy(DateTime starTime, DateTime endTime);
        List<HoaDonNhap> GetHoaDonNhapByTeam(string SoHDN);
    }
}