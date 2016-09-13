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
        public HoaDonNhapController(IHoaDonNhapService hoaDonNhapService, ITheLoaiService theLoaiService, IKichCoService kichCoService, IChatLieuService chatLieuService, IMauService mauService, IMuaService muaService, IDoiTuongService doiTuongService, INuocSanXuatService nuocSxService, ISanPhamService sanPhamService) {
            this.hoaDonNhapService = hoaDonNhapService;
            this.theLoaiService = theLoaiService;
            this.kichCoService = kichCoService;
            this.chatLieuService = chatLieuService;
            this.mauService = mauService;
            this.muaService = muaService;
            this.doiTuongService = doiTuongService;
            this.nuocSxService = nuocSxService;
            this.sanPhamService = sanPhamService;

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
            HoaDonNhap entity = hoaDonNhapService.GetById(value);
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
        /// Validates the and fillup.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public IList<string> ValidateAndFillup(HoaDonNhapModel value) {
            var a = new List<string>();

            //var loai     =  theLoaiService.GetByMa(value.MaLoai);
            //var co       =  KichCoService.GetByMa(value.MaCo);
            //var chatLieu =  chatLieuService.GetByMa(value.MaChatLieu);
            //var mau      =  mauService.GetByMa(value.MaMau);
            //var doiTuong =  doiTuongService.GetByMa(value.MaDoiTuong);
            //var mua      =  muaService.GetByMa(value.MaMua);
            //var nuocSx   =  nuocSXService.GetByMa(value.MaNuocSX);

            //if(loai    ==null){a.Add("MaLoai");}
            //if(co      ==null){a.Add("MaCo");}
            //if(chatLieu==null){a.Add("MaChatLieu");}
            //if(mau     ==null){a.Add("MaMau");}
            //if(doiTuong==null){a.Add("MaDoiTuong");}
            //if(mua     ==null){a.Add("MaMua");}
            //if(nuocSx  ==null){a.Add("MaNuocSX");}

            //if(loai    !=null){value.TheLoaiID = loai.ID;}
            //if(co      !=null){value.KichCoID = co.ID;}
            //if(chatLieu!=null){value.ChatLieuID = chatLieu.ID;}
            //if(mau     !=null){value.MauID = mau.ID;}
            //if(doiTuong!=null){value.DoiTuongID = doiTuong.ID;}
            //if(mua     !=null){value.MuaID = mau.ID;}
            //if(nuocSx  !=null){value.NuocSanXuatID = nuocSx.ID;}

            return a;
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
            if(value==null)value = new HoaDonNhapModel();
            hoaDonNhapView.InitializeForm(value);
            hoaDonNhapView.PostView(value);
            hoaDonNhapView.View();
        }

        /// <summary>
        /// Sets the hoa don nhap ListView.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetHoaDonNhapListView(Form value) {
            hoaDonNhapListView = (HoaDonNhapListView)value;
        }

        public void HideSanPhamView()
        {
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
            if(key == Mediator.HOA_DON_NHAP_CALL_SAM_PHAM_GET_SANPHAM) {
                if(e == null)
                    return;
                if(e.value == null)
                    return;
                var m = e.value as SanPhamModel;
                if(m == null)
                    return;
                hoaDonNhapView.SetCellSanPham(m);
                app.Resolve<ISanPhamController<SanPhamModel>>().HideForm();
            }
        }
        public void ShowSanPhamView(int mode) {
            try {
                var a = app.Resolve<ISanPhamController<SanPhamModel>>();
                a.Notification += AddEventListener;
                a.ShowSanPhamViewMode(mode);
                a.ShowSanPhamView(new SanPhamModel());
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public SanPhamModel CheckMaFromSanPham(string ma) {
            var m = sanPhamService.GetByMa(ma);
            if (m == null) return null;
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