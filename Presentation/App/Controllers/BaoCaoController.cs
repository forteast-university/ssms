// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-12-2016
// ***********************************************************************
// <copyright file="BaoCaoController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Extensions;
using App.Models;
using App.Properties;
using App.Service.Business;
using App.Views;
using Autofac;
using Autofac.Core.Registration;

namespace App.Controllers {
    
    public class BaoCaoController: IBaoCaoController<BaoCaoModel>{

        private readonly IHoaDonNhapService hoaDonNhapService;
        private readonly IHoaDonBanService hoaDonBanService;
        private readonly ISanPhamService sanPhamService;

        private readonly ITheLoaiService theLoaiService;
        private readonly IKichCoService kichCoService;
        private readonly IChatLieuService chatLieuService;
        private readonly IMauService mauService;
        private readonly IMuaService muaService;
        private readonly IDoiTuongService doiTuongService;
        private readonly INuocSanXuatService nuocSxService;
        private readonly IChiTietHDBService chiTietHdbService;
        private readonly INhanVienService nhanVienService;
        private readonly IKhachHangService khachHangService;

        private BaoCaoView baoCaoView;

        public event EventHandler<AppEvent<BaoCaoModel>> Notification;

        public BaoCaoController(IHoaDonNhapService hoaDonNhapService, ITheLoaiService theLoaiService, IKichCoService kichCoService, IChatLieuService chatLieuService, IMauService mauService, IMuaService muaService, IDoiTuongService doiTuongService, INuocSanXuatService nuocSxService, ISanPhamService sanPhamService, IChiTietHDBService chiTietHdbService, INhanVienService nhanVienService, IKhachHangService khachHangService, IHoaDonBanService hoaDonBanService) {
            this.hoaDonNhapService = hoaDonNhapService;
            this.theLoaiService = theLoaiService;
            this.kichCoService = kichCoService;
            this.chatLieuService = chatLieuService;
            this.mauService = mauService;
            this.muaService = muaService;
            this.doiTuongService = doiTuongService;
            this.nuocSxService = nuocSxService;
            this.sanPhamService = sanPhamService;
            this.chiTietHdbService = chiTietHdbService;
            this.nhanVienService = nhanVienService;
            this.khachHangService = khachHangService;
            this.hoaDonBanService = hoaDonBanService;
        }
        public void ShowForm() {
            PostView();
            baoCaoView.View();
        }
        public void ReviewGrid() {
            PostView();
        }
        private readonly IContainer app = AppFacade.Container;

        public void PostView() {
            //var a = hoaDonNhapService.GetAll();
            //var listModel = a.Select(b => b.ToModel()).ToList();
            //baoCaoView.PostView(listModel);
        }
    }
}