// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="KichCoController.cs" company="Thanh Dong University">
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
    /// Class KichCoController.
    /// </summary>
    public partial class KichCoController: IBaseController<KichCoModel> {

        /// <summary>
        /// The chat lieu service
        /// </summary>
        private readonly IKichCoService currentService;

        /// <summary>
        /// The view
        /// </summary>
        private readonly KichCoView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="KichCoController"/> class.
        /// </summary>
        /// <param name="currentService">The chat lieu service.</param>
        public KichCoController(IKichCoService currentService) {
            this.currentService = currentService;
            view = new KichCoView(this);
        }
        /// <summary>
        /// Views this instance.
        /// </summary>
        public void View() {
            PostView();
            view.View();
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
        public void Insert(KichCoModel value) {
            try {
                var entity = value.ToEntity();
                currentService.Insert(entity);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        protected virtual KichCo ModelToEntity(KichCoModel model) {
            KichCo a = currentService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(KichCoModel value)
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
        public void Delete(KichCoModel value) {
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
