// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-12-2016
// ***********************************************************************
// <copyright file="HoaDonNhapController.cs" company="Thanh Dong University">
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
    /// Class HoaDonNhapController.
    /// </summary>
    public class HoaDonNhapController: IHoaDonNhapController<HoaDonNhapModel> {
        /// <summary>
        /// The chat lieu service
        /// </summary>
        private readonly IHoaDonNhapService hoaDonNhapService;

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
        /// The chi tiet HDN service
        /// </summary>
        private readonly IChiTietHDNService chiTietHdnService;
        private readonly INhanVienService nhanVienService;
        private readonly INhaCungCapService nhaCungCapService;

        /// <summary>
        /// The hoa don nhap view
        /// </summary>
        private HoaDonNhapView hoaDonNhapView;

        /// <summary>
        /// The view
        /// </summary>
        private HoaDonNhapListView hoaDonNhapListView;
        /// <summary>
        /// Occurs when [notification].
        /// </summary>
        public event EventHandler<AppEvent<HoaDonNhapModel>> Notification;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoaDonNhapController" /> class.
        /// </summary>
        /// <param name="hoaDonNhapService">The hoa don nhap service.</param>
        /// <param name="theLoaiService">The loai service.</param>
        /// <param name="kichCoService">The kich co service.</param>
        /// <param name="chatLieuService">The chat lieu service.</param>
        /// <param name="mauService">The mau service.</param>
        /// <param name="muaService">The mua service.</param>
        /// <param name="doiTuongService">The doi tuong service.</param>
        /// <param name="nuocSxService">The nuoc sx service.</param>
        public HoaDonNhapController(IHoaDonNhapService hoaDonNhapService, ITheLoaiService theLoaiService, IKichCoService kichCoService, IChatLieuService chatLieuService, IMauService mauService, IMuaService muaService, IDoiTuongService doiTuongService, INuocSanXuatService nuocSxService, ISanPhamService sanPhamService, IChiTietHDNService chiTietHdnService, INhanVienService nhanVienService, INhaCungCapService nhaCungCapService) {
            this.hoaDonNhapService = hoaDonNhapService;
            this.theLoaiService = theLoaiService;
            this.kichCoService = kichCoService;
            this.chatLieuService = chatLieuService;
            this.mauService = mauService;
            this.muaService = muaService;
            this.doiTuongService = doiTuongService;
            this.nuocSxService = nuocSxService;
            this.sanPhamService = sanPhamService;
            this.chiTietHdnService = chiTietHdnService;
            this.nhanVienService = nhanVienService;
            this.nhaCungCapService = nhaCungCapService;

            hoaDonNhapView = new HoaDonNhapView(this);
        }
        /// <summary>
        /// Selects the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Select(HoaDonNhapModel value) {
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
        public void Insert(HoaDonNhapModel value) {
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
        public void Update(HoaDonNhapModel value) {
            HoaDonNhap entity = ModelToEntity(value);
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
        public void Delete(HoaDonNhapModel value) {
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
        public void HideHoaDonNhapView() {
            hoaDonNhapView.Hide();
        }

        /// <summary>
        /// Shows the hoa don nhap view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void ShowHoaDonNhapView(HoaDonNhapModel value) {
            // creat
            if(value == null) {
                value = new HoaDonNhapModel();
                hoaDonNhapView.SetModeView(1);
                hoaDonNhapView.PostView(value);
                hoaDonNhapView.View();
            } else {
                //view only
                var a = hoaDonNhapService.GetById(value.ID);
                var b = a.ToModel();
                b.ChiTietHDNModel = chiTietHdnService.GetChiTietHDNByTeam(b.SoHDN).Select(c => c.ToModel()).ToList();
                hoaDonNhapView.SetModeView(0);
                hoaDonNhapView.PostView(b);
                hoaDonNhapView.View();
            }

        }
        public IList<string> ValidateAndFillup(HoaDonNhapModel value) {
            var a = new List<string>();
            var nhanvien     =  nhanVienService.GetByMa(value.MaNV);
            var ncc       =  nhaCungCapService.GetByMa(value.MaNCC);
            var hd       =  nhaCungCapService.GetByMa(value.SoHDN);

            if(nhanvien == null) { a.Add("MaNV"); }
            if(ncc == null) { a.Add("MaNCC"); }
            if(hd != null) { a.Add("SoHDN"); }

            if(nhanvien != null) { value.NhanVienID = nhanvien.ID; }
            if(ncc != null) { value.NhaCungCapID = ncc.ID; }
            return a;
        }
        public void SaveHoaDonNhap(HoaDonNhapModel value) {
            var sanPhamCtrl = app.Resolve<ISanPhamController<SanPhamModel>>();

            var hdEntity = value.ToEntity();

            hdEntity.NhanVienID = nhanVienService.GetByMa(hdEntity.MaNV).ID;
            hdEntity.NhaCungCapID = nhaCungCapService.GetByMa(hdEntity.MaNCC).ID;

            hoaDonNhapService.Insert(hdEntity);

            foreach(var hds in value.ChiTietHDNModel) {
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
                hds.SoHDN = hdEntity.SoHDN;
                hds.HoaDonNhapID = hdEntity.ID;
                chiTietHdnService.Insert(hds.ToEntity());
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
        public void SetHoaDonNhapListView(Form value) {
            hoaDonNhapListView = (HoaDonNhapListView)value;
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
            if(key == Mediator.HOA_DON_NHAP_CANCEL_SAM_PHAM_GET_SANPHAM) {
                hoaDonNhapView.SetCellSanPham(null);
                app.Resolve<ISanPhamController<SanPhamModel>>().HideSanPhamView();
            }
            if(key == Mediator.HOA_DON_NHAP_CALL_SAM_PHAM_GET_SANPHAM) {
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
        /// <returns>HoaDonNhap.</returns>
        protected virtual HoaDonNhap ModelToEntity(HoaDonNhapModel model) {
            HoaDonNhap a = hoaDonNhapService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}