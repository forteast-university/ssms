// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="NhanVienController.cs" company="Thanh Dong University">
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

namespace App.Controllers{
    /// <summary>
    ///     Class NhanVienController.
    /// </summary>
    public class NhanVienController : INhanVienController<NhanVienModel>{
        /// <summary>
        ///     The chat lieu service
        /// </summary>
        private readonly INhanVienService currentService;

        private readonly IContainer app = AppFacade.Container;
        /// <summary>
        ///     The dangNhapView
        /// </summary>
        private readonly DangNhapView dangNhapView;
        private readonly NhanVienView nhanVienView;

        public void CloseParent() {

            var a = new AppEvent<NhanVienModel>{value = new NhanVienModel{
                MaNhanVien = "",
                MatKhau= ""
            }};
            Notification(Mediator.DANGNHAP_KHONG_THANH_CONG, a);
        }

        public void DangNhap(NhanVienModel value){
            //todo check account and pass
            var a = currentService.GetNhanVienByMaNhanVien(value.MaNhanVien);
            if (a != null){
                if (value.MatKhau == a.MatKhau){
                    //todo: pass
                    //dangNhapView.Hide();
                }
            }
            else{
                //Notification(Mediator.DANGNHAP_KHONG_THANH_CONG, new AppEvent<NhanVienModel>{}); return;
            }
            dangNhapView.Hide();
        }
        public void AddEventListener<T>(object sender, AppEvent<T> e) {
            var key = sender.ToString();
            if(key == Mediator.NHAN_VIEN_CALL_CONG_VIEC_GET_MA)
            {
                if(e!=null){
                    if (e.value != null){
                        var m = e.value as CongViecModel;
                        if (m != null)
                        {
                            nhanVienView.SetTxtMaCv(m.MaCV);
                            app.Resolve<IBaseController<CongViecModel>>().HideForm();
                        }
                    }
                }
            }
        }
        public void ShowCongViecView(string ma){
            try {
                var a = app.Resolve<ICongViecController<CongViecModel>>();
                a.Notification += AddEventListener;
                a.ShowForm();
            } catch(ComponentNotRegisteredException exception) {
            }
        }

        public event EventHandler<AppEvent<NhanVienModel>> Notification;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NhanVienController" /> class.
        /// </summary>
        /// <param name="currentService">The chat lieu service.</param>
        public NhanVienController(INhanVienService currentService){
            this.currentService = currentService;
            dangNhapView = new DangNhapView(this);
            nhanVienView = new NhanVienView(this);
        }

        public void Select(NhanVienModel value)
        {
            //Notification(Mediator.DANGNHAP_KHONG_THANH_CONG, new AppEvent<NhanVienModel>{value = value});
        }

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void ShowForm(){
            PostView();
            nhanVienView.View();
        }

        public void HideForm()
        {
            nhanVienView.Hide();
        }

        /// <summary>
        ///     Reviews the grid.
        /// </summary>
        public void ReviewGrid(){
            PostView();
        }

        /// <summary>
        ///     Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(NhanVienModel value){
            try{
                NhanVien entity = value.ToEntity();
                currentService.Insert(entity);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(NhanVienModel value){
            NhanVien entity = ModelToEntity(value);
            currentService.Update(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value){
            NhanVien entity = currentService.GetById(value);
            currentService.Delete(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(NhanVienModel value){
            Delete(value.ID);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(string value){
            List<int> list = value.Split(',').Select(a => Convert.ToInt32(a)).ToList();
            foreach (int i in list){
                Delete(i);
            }
        }

        public IList<NhanVienModel> Get(string value){
            throw new NotImplementedException();
        }

        public void ShowDangNhap() {
            dangNhapView.ShowDialog();
        }

        

        /// <summary>
        ///     Posts the dangNhapView.
        /// </summary>
        private void PostView(){
            IEnumerable<NhanVien> a = currentService.GetAll();
            List<NhanVienModel> listModel = a.Select(b => b.ToModel()).ToList();
            nhanVienView.PostView(listModel);
        }

        protected virtual NhanVien ModelToEntity(NhanVienModel model){
            NhanVien a = currentService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}