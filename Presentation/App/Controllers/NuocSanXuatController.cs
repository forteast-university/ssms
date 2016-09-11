// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="NuocSanXuatController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Extensions;
using App.Models;
using App.Properties;
using App.Service.Business;
using App.Views;
using AutoMapper;

namespace App.Controllers {
    /// <summary>
    /// Class NuocSanXuatController.
    /// </summary>
    public partial class NuocSanXuatController: IBaseController<NuocSanXuatModel> {

        /// <summary>
        /// The nuoc san xuat service
        /// </summary>
        private readonly INuocSanXuatService currentService;

        /// <summary>
        /// The view
        /// </summary>
        private readonly NuocSanXuatView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="NuocSanXuatController"/> class.
        /// </summary>
        /// <param name="currentService">The nuoc san xuat service.</param>
        public NuocSanXuatController(INuocSanXuatService currentService) {
            this.currentService = currentService;
            view = new NuocSanXuatView(this);
        }

        public event EventHandler<AppEvent<NuocSanXuatModel>> Notification;

        public void Select(NuocSanXuatModel value)
        {
            //NuocSanXuat
            if(Notification != null) {
                Notification(Mediator.SAN_PHAM_CALL_NUOC_SANXUAT_GET_MA, new AppEvent<NuocSanXuatModel> { value = value });
                Notification = null;
            }
        }

        /// <summary>
        /// Views this instance.
        /// </summary>
        public void ShowForm() {
            PostView();
            view.View();
        }

        public void HideForm()
        {
            view.Hide();
        }

        /// <summary>
        /// Reviews the grid.
        /// </summary>
        public void ReviewGrid() {
            PostView();
        }
        /// <summary>
        /// Posts the view.
        /// </summary>
        private void PostView() {
            var a = currentService.GetAll();
            var listModel = a.Select(b => b.ToModel()).ToList();
            view.PostView(listModel);
        }

        /// <summary>
        /// Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(NuocSanXuatModel value) {
            try {
                var entity = value.ToEntity();
                currentService.Insert(entity);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        protected virtual NuocSanXuat ModelToEntity(NuocSanXuatModel model) {
            NuocSanXuat a = currentService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(NuocSanXuatModel value)
        {
            var entity = ModelToEntity(value);
            currentService.Update(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value) {
            var entity = currentService.GetById(value);
            currentService.Delete(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(NuocSanXuatModel value) {
            Delete(value.ID);
        }
        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(string value) {
            var list = value.Split(',').Select(a => Convert.ToInt32(a)).ToList();
            foreach(var i in list) {
                Delete(i);
            }
        }
    }
}
