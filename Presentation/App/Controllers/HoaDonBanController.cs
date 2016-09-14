// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-12-2016
// ***********************************************************************
// <copyright file="HoaDonBanController.cs" company="Thanh Dong University">
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
    /// <summary>
    /// Class HoaDonBanController.
    /// </summary>
    public class HoaDonBanController: IHoaDonBanController<HoaDonBanModel> {
        /// <summary>
        /// The chat lieu service
        /// </summary>
        private readonly IHoaDonBanService hoaDonNhapService;

        private readonly ISanPhamService sanPhamService;
        /// <summary>
        /// The loai service
        /// </summary>
        private readonly ITheLoaiService theLoaiService;
        /// <summary>
        /// The kich co service
        /// </summary>
        private readonly IKichCoService kichCoService;
        /// <summary>
        /// The chat lieu service
        /// </summary>
        private readonly IChatLieuService chatLieuService;
        /// <summary>
        /// The mau service
        /// </summary>
        private readonly IMauService mauService;
        /// <summary>
        /// The mua service
        /// </summary>
        private readonly IMuaService muaService;
        /// <summary>
        /// The doi tuong service
        /// </summary>
        private readonly IDoiTuongService doiTuongService;
        /// <summary>
        /// The nuoc sx service
        /// </summary>
        private readonly INuocSanXuatService nuocSxService;

        /// <summary>
        /// The chi tiet HDB service
        /// </summary>
        private readonly IChiTietHDBService chiTietHdbService;
        private readonly INhanVienService nhanVienService;
        private readonly IKhachHangService khachHangService;

        /// <summary>
        /// The hoa don nhap view
        /// </summary>
        private HoaDonBanView hoaDonNhapView;

        /// <summary>
        /// The view
        /// </summary>
        private HoaDonBanListView hoaDonNhapListView;
        /// <summary>
        /// Occurs when [notification].
        /// </summary>
        public event EventHandler<AppEvent<HoaDonBanModel>> Notification;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoaDonBanController" /> class.
        /// </summary>
        /// <param name="hoaDonNhapService">The hoa don nhap service.</param>
        /// <param name="theLoaiService">The loai service.</param>
        /// <param name="kichCoService">The kich co service.</param>
        /// <param name="chatLieuService">The chat lieu service.</param>
        /// <param name="mauService">The mau service.</param>
        /// <param name="muaService">The mua service.</param>
        /// <param name="doiTuongService">The doi tuong service.</param>
        /// <param name="nuocSxService">The nuoc sx service.</param>
        public HoaDonBanController(IHoaDonBanService hoaDonNhapService, ITheLoaiService theLoaiService, IKichCoService kichCoService, IChatLieuService chatLieuService, IMauService mauService, IMuaService muaService, IDoiTuongService doiTuongService, INuocSanXuatService nuocSxService, ISanPhamService sanPhamService, IChiTietHDBService chiTietHdbService, INhanVienService nhanVienService, IKhachHangService khachHangService) {
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

            hoaDonNhapView = new HoaDonBanView(this);
        }
        /// <summary>
        /// Selects the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Select(HoaDonBanModel value) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Views this instance.
        /// </summary>
        public void ShowForm() {
            PostView();
            hoaDonNhapListView.View();
        }

        /// <summary>
        /// Hides the form.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void HideForm() {
            // we dont hide this form
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reviews the grid.
        /// </summary>
        public void ReviewGrid() {
            PostView();
        }

        /// <summary>
        /// Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(HoaDonBanModel value) {
            try {
                var entity = value.ToEntity();
                hoaDonNhapService.Insert(entity);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(HoaDonBanModel value) {
            HoaDonBan entity = ModelToEntity(value);
            hoaDonNhapService.Update(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value) {
            var entity = hoaDonNhapService.GetById(value);
            hoaDonNhapService.Delete(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(HoaDonBanModel value) {
            Delete(value.ID);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(string value) {
            List<int> list = value.Split(',').Select(a => Convert.ToInt32(a)).ToList();
            foreach(int i in list) {
                Delete(i);
            }
        }
        /// <summary>
        /// Hides the hoa don nhap view.
        /// </summary>
        public void HideHoaDonBanView() {
            hoaDonNhapView.Hide();
        }

        /// <summary>
        /// Shows the hoa don nhap view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void ShowHoaDonBanView(HoaDonBanModel value) {
            // creat
            if(value == null) {
                value = new HoaDonBanModel();
                hoaDonNhapView.SetModeView(1);
                hoaDonNhapView.PostView(value);
                hoaDonNhapView.View();
            } else {
                //view only
                var a = hoaDonNhapService.GetById(value.ID);
                var b = a.ToModel();
                b.ChiTietHDBModel = chiTietHdbService.GetChiTietHDBByTeam(b.SoHDB).Select(c => c.ToModel()).ToList();
                hoaDonNhapView.SetModeView(0);
                hoaDonNhapView.PostView(b);
                hoaDonNhapView.View();
            }

        }
        public IList<string> ValidateAndFillup(HoaDonBanModel value) {
            var a = new List<string>();
            var nhanvien     =  nhanVienService.GetByMa(value.MaNV);
            var khach       =  khachHangService.GetByMa(value.MaKhach);
            var hoadon       =  khachHangService.GetByMa(value.SoHDB);

            if(nhanvien == null) { a.Add("MaNV"); }
            if(khach == null) { a.Add("MaKhach"); }
            if(hoadon != null) { a.Add("SoHDB"); }

            if(nhanvien != null) { value.NhanVienID = nhanvien.ID; }
            if(khach != null) { value.KhachHangID = khach.ID; }
            return a;
        }
        public void SaveHoaDonBan(HoaDonBanModel value) {
            var sanPhamCtrl = app.Resolve<ISanPhamController<SanPhamModel>>();

            var hdEntity = value.ToEntity();

            hdEntity.NhanVienID = nhanVienService.GetByMa(hdEntity.MaNV).ID;
            hdEntity.KhachHangID = khachHangService.GetByMa(hdEntity.MaKhach).ID;

            hoaDonNhapService.Insert(hdEntity);

            foreach(var hds in value.ChiTietHDBModel) {
                if(hds.SanPham != null) {
                    var sp = hds.SanPham;
                    sp.DonGiaBan = (hds.DonGia + Math.Round(hds.DonGia * (decimal)0.1));
                    sp.DonGiaNhap = hds.DonGia;
                    sp.SoLuong = hds.SoLuong;
                    sanPhamService.Insert(sp);
                    hds.SanPhamID = sp.ID;
                } else {
                    var sp = sanPhamService.GetByMa(hds.MaGiayDep);
                    sp.DonGiaBan = (hds.DonGia + Math.Round(hds.DonGia * (decimal)0.1));
                    sp.DonGiaNhap = hds.DonGia;
                    sp.SoLuong = sp.SoLuong + hds.SoLuong;

                    hds.SanPhamID = sp.ID;

                    sanPhamService.Update(sp);
                }
                hds.SoHDB = hdEntity.SoHDB;
                hds.HoaDonBanID = hdEntity.ID;
                chiTietHdbService.Insert(hds.ToEntity());
            }
            // update UI on SanPham View
            hoaDonNhapView.HideForm();
            sanPhamCtrl.ReviewGrid();
            PostView();
        }

        /// <summary>
        /// Sets the hoa don nhap ListView.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetHoaDonBanListView(Form value) {
            hoaDonNhapListView = (HoaDonBanListView)value;
        }

        public void HideSanPhamView() {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// The application
        /// </summary>
        private readonly IContainer app = AppFacade.Container;
        /// <summary>
        /// Adds the event listener.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        public void AddEventListener<T>(object sender, AppEvent<T> e) {
            var key = sender.ToString();
            if(key == Mediator.HOA_DON_BAN_CANCEL_SAM_PHAM_GET_SANPHAM) {
                hoaDonNhapView.SetCellSanPham(null);
                app.Resolve<ISanPhamController<SanPhamModel>>().HideSanPhamView();
            }
            if(key == Mediator.HOA_DON_BAN_CALL_SAM_PHAM_GET_SANPHAM) {
                if(e == null)
                    return;
                if(e.value == null)
                    return;
                var m = e.value as SanPhamModel;
                if(m == null)
                    return;
                hoaDonNhapView.SetCellSanPham(m);
                app.Resolve<ISanPhamController<SanPhamModel>>().HideSanPhamView();
            }
        }
        public void ShowSanPhamViewToCreate(string ma) {
            try {
                var a = app.Resolve<ISanPhamController<SanPhamModel>>();
                a.Notification += AddEventListener;
                a.ShowSanPhamViewMode(0);
                a.ShowSanPhamView(new SanPhamModel { MaGiayDep = ma });
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public SanPhamModel CheckMaFromSanPham(string ma) {
            var m = sanPhamService.GetByMa(ma);
            if(m == null)
                return null;
            return m.ToModel();
        }


        /// <summary>
        /// Posts the view.
        /// </summary>
        private void PostView() {
            var a = hoaDonNhapService.GetAll();
            var listModel = a.Select(b => b.ToModel()).ToList();
            hoaDonNhapListView.PostView(listModel);
        }

        /// <summary>
        /// Models to entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>HoaDonBan.</returns>
        protected virtual HoaDonBan ModelToEntity(HoaDonBanModel model) {
            HoaDonBan a = hoaDonNhapService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}