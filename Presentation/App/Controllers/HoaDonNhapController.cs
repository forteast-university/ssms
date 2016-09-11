// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
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

namespace App.Controllers
{
    /// <summary>
    ///     Class HoaDonNhapController.
    /// </summary>
    public class HoaDonNhapController : IHoaDonNhapController<HoaDonNhapModel>
    {
        /// <summary>
        ///     The chat lieu service
        /// </summary>
        private readonly IHoaDonNhapService sanPhamService;
        private readonly ITheLoaiService theLoaiService;
        private readonly IKichCoService kichCoService;
        private readonly IChatLieuService chatLieuService;
        private readonly IMauService mauService;
        private readonly IMuaService muaService;
        private readonly IDoiTuongService doiTuongService;
        private readonly INuocSanXuatService nuocSxService;

        private readonly IChiTietHDNService chiTietHdnService;

        private HoaDonNhapView sanPhamView;

        /// <summary>
        ///     The view
        /// </summary>
        private HoaDonNhapListView hoaDonNhapListView;
        public event EventHandler<AppEvent<HoaDonNhapModel>> Notification;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HoaDonNhapController" /> class.
        /// </summary>
        public HoaDonNhapController(IHoaDonNhapService sanPhamService, ITheLoaiService theLoaiService, IKichCoService kichCoService, IChatLieuService chatLieuService, IMauService mauService, IMuaService muaService, IDoiTuongService doiTuongService, INuocSanXuatService nuocSxService)
        {
            this.sanPhamService = sanPhamService;
            this.theLoaiService = theLoaiService;
            this.kichCoService = kichCoService;
            this.chatLieuService = chatLieuService;
            this.mauService = mauService;
            this.muaService = muaService;
            this.doiTuongService = doiTuongService;
            this.nuocSxService = nuocSxService;

            sanPhamView = new HoaDonNhapView(this);
        }
        public void Select(HoaDonNhapModel value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void ShowForm()
        {
            PostView();
            hoaDonNhapListView.View();
        }

        public void HideForm()
        {
            // we dont hide this form
            throw new NotImplementedException();
        }
        /// <summary>
        ///     Reviews the grid.
        /// </summary>
        public void ReviewGrid()
        {
            PostView();
        }

        /// <summary>
        ///     Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(HoaDonNhapModel value)
        {
            try
            {
                var entity = value.ToEntity();
                sanPhamService.Insert(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(HoaDonNhapModel value)
        {
            HoaDonNhap entity = ModelToEntity(value);
            sanPhamService.Update(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value)
        {
            HoaDonNhap entity = sanPhamService.GetById(value);
            sanPhamService.Delete(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(HoaDonNhapModel value)
        {
            Delete(value.ID);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(string value)
        {
            List<int> list = value.Split(',').Select(a => Convert.ToInt32(a)).ToList();
            foreach (int i in list)
            {
                Delete(i);
            }
        }

        public IList<string> ValidateAndFillup(HoaDonNhapModel value)
        {
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

        public void HideHoaDonNhapView()
        {
            sanPhamView.Hide();
        }

        public void ShowHoaDonNhapView(HoaDonNhapModel value)
        {
            sanPhamView.InitializeForm(value);
            sanPhamView.ShowDialog();
        }

        public void SetHoaDonNhapListView(Form value)
        {
            hoaDonNhapListView = (HoaDonNhapListView)value;
        }

        private readonly IContainer app = AppFacade.Container;
        public void AddEventListener<T>(object sender, AppEvent<T> e) {
            //var key = sender.ToString();
            //if (key == Mediator.SAN_PHAM_CALL_THE_LOAI_GET_MA)
            //{
            //    //---------------------TheLoai
            //    if(e == null)
            //        return;
            //    if(e.value == null)
            //        return;
            //    var m = e.value as TheLoaiModel;
            //    if(m == null)
            //        return;
            //    sanPhamView.SetTxtMaTheLoai(m.MaLoai);
            //    app.Resolve<IBaseController<TheLoaiModel>>().HideForm();
            //}
            //if (key == Mediator.SAN_PHAM_CALL_KICH_CO_GET_MA)
            //{
            //    //---------------------KichCo
            //    if(e == null)
            //        return;
            //    if(e.value == null)
            //        return;
            //    var m = e.value as KichCoModel;
            //    if(m == null)
            //        return;
            //    sanPhamView.SetTxtMaKichCo(m.MaCo);
            //    app.Resolve<IBaseController<KichCoModel>>().HideForm();
            //}
            //if (key == Mediator.SAN_PHAM_CALL_CHAT_LIEU_GET_MA)
            //{
            //    //---------------------ChatLieu
            //    if(e == null)
            //        return;
            //    if(e.value == null)
            //        return;
            //    var m = e.value as ChatLieuModel;
            //    if(m == null)
            //        return;
            //    sanPhamView.SetTxtMaChatLieu(m.MaChatLieu);
            //    app.Resolve<IBaseController<ChatLieuModel>>().HideForm();
            //}
            //if (key == Mediator.SAN_PHAM_CALL_MAU_GET_MA)
            //{
                
            //    //---------------------Mau
            //    if(e == null) return;
            //    if(e.value == null)return;
            //    var m = e.value as MauModel;
            //    if(m == null) return;
            //    sanPhamView.SetTxtMaMau(m.MaMau);
            //    app.Resolve<IBaseController<MauModel>>().HideForm();

            //}
            //if (key == Mediator.SAN_PHAM_CALL_DOI_TUONG_GET_MA)
            //{
            //    //---------------------DoiTuong
            //    if(e == null) return;
            //    if(e.value == null)return;
            //    var m = e.value as DoiTuongModel;
            //    if(m == null) return;
            //    sanPhamView.SetTxtMaDoiTuong(m.MaDoiTuong);
            //    app.Resolve<IBaseController<DoiTuongModel>>().HideForm();
            //}
            //if (key == Mediator.SAN_PHAM_CALL_MUA_GET_MA)
            //{
            //    //---------------------Mua
            //    if(e == null) return;
            //    if(e.value == null)return;
            //    var m = e.value as MuaModel;
            //    if(m == null) return;
            //    sanPhamView.SetTxtMaMua(m.MaMua);
            //    app.Resolve<IBaseController<MuaModel>>().HideForm();
                
            //}
            //if (key == Mediator.SAN_PHAM_CALL_NUOC_SANXUAT_GET_MA)
            //{
            //    //---------------------NuocSanXuat
            //    if(e == null) return;
            //    if(e.value == null)return;
            //    var m = e.value as NuocSanXuatModel;
            //    if(m == null) return;
            //    sanPhamView.SetTxtMaNuocSanXuat(m.MaNuocSX);
            //    app.Resolve<IBaseController<NuocSanXuatModel>>().HideForm();
            //}
        }
        public void ShowTheLoaiView(string ma) {
            try {
                var a = app.Resolve<IBaseController<TheLoaiModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public void ShowKichCoView(string ma) {
            try {
                var a = app.Resolve<IBaseController<KichCoModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public void ShowChatLieuView(string ma) {
            try {
                var a = app.Resolve<IBaseController<ChatLieuModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public void ShowMauView(string ma) {
            try {
                var a = app.Resolve<IBaseController<MauModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public void ShowDoiTuongView(string ma) {
            try {
                var a = app.Resolve<IBaseController<DoiTuongModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public void ShowMuaView(string ma) {
            try {
                var a = app.Resolve<IBaseController<MuaModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }
        public void ShowNuocSanXuatView(string ma) {
            try {
                var a = app.Resolve<IBaseController<NuocSanXuatModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }

        /// <summary>
        ///     Posts the view.
        /// </summary>
        private void PostView()
        {
            IEnumerable<HoaDonNhap> a = sanPhamService.GetAll();
            List<HoaDonNhapModel> listModel = a.Select(b => b.ToModel()).ToList();
            hoaDonNhapListView.PostView(listModel);
        }

        protected virtual HoaDonNhap ModelToEntity(HoaDonNhapModel model)
        {
            HoaDonNhap a = sanPhamService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}