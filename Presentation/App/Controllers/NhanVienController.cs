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
using App.Extensions;
using App.Models;
using App.Properties;
using App.Service.Business;
using App.Views;

namespace App.Controllers{
    /// <summary>
    ///     Class NhanVienController.
    /// </summary>
    public class NhanVienController : INhanVienController<NhanVienModel>{
        /// <summary>
        ///     The chat lieu service
        /// </summary>
        private readonly INhanVienService currentService;

        /// <summary>
        ///     The view
        /// </summary>
        private readonly DangNhapView view;
        private readonly NhanVienView viewNhanVien;

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
                    //view.Hide();
                }
            }
            else{
                //Notification(Mediator.DANGNHAP_KHONG_THANH_CONG, new AppEvent<NhanVienModel>{}); return;
            }
            view.Hide();
        }
        public event EventHandler<AppEvent<NhanVienModel>> Notification;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NhanVienController" /> class.
        /// </summary>
        /// <param name="currentService">The chat lieu service.</param>
        public NhanVienController(INhanVienService currentService){
            this.currentService = currentService;
            view = new DangNhapView(this);
            //viewNhanVien = new NhanVienView(this);
        }

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void View(){
            PostView();
            view.View();
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
            view.ShowDialog();
        }

        

        /// <summary>
        ///     Posts the view.
        /// </summary>
        private void PostView(){
            IEnumerable<NhanVien> a = currentService.GetAll();
            List<NhanVienModel> listModel = a.Select(b => b.ToModel()).ToList();
            view.PostView(listModel);
        }

        protected virtual NhanVien ModelToEntity(NhanVienModel model){
            NhanVien a = currentService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}