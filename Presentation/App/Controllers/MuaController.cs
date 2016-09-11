// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="MuaController.cs" company="Thanh Dong University">
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
    /// Class MuaController.
    /// </summary>
    public partial class MuaController: IBaseController<MuaModel> {

        /// <summary>
        /// The chat lieu service
        /// </summary>
        private readonly IMuaService currentService;

        /// <summary>
        /// The view
        /// </summary>
        private readonly MuaView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="MuaController"/> class.
        /// </summary>
        /// <param name="currentService">The chat lieu service.</param>
        public MuaController(IMuaService currentService) {
            this.currentService = currentService;
            view = new MuaView(this);
        }

        public event EventHandler<AppEvent<MuaModel>> Notification;

        public void Select(MuaModel value)
        {
            throw new NotImplementedException();
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
        public void Insert(MuaModel value) {
            try {
                var entity = value.ToEntity();
                currentService.Insert(entity);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        protected virtual Mua ModelToEntity(MuaModel model) {
            Mua a = currentService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(MuaModel value)
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
        public void Delete(MuaModel value) {
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
