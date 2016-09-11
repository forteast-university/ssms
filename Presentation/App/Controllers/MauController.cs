// ***********************************************************************
// Assembly         : App
// Author           : Cang Nguyen
// Created          : 09-09-2016
//
// Last Modified By : Cang Nguyen
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="MauController.cs" company="Thanh Dong University">
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

namespace App.Controllers
{
    /// <summary>
    /// Class MauController.
    /// </summary>
    public partial class MauController : IBaseController<MauModel>
    {

        /// <summary>
        /// The mau service
        /// </summary>
        private readonly IMauService MauService;

        /// <summary>
        /// The view
        /// </summary>
        private readonly MauView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="MauController" /> class.
        /// </summary>
        /// <param name="MauService">The mau service.</param>
        public MauController(IMauService MauService)
        {
            this.MauService = MauService;
            view = new MauView(this);
        }

        public event EventHandler<AppEvent<MauModel>> Notification;

        public void Select(MauModel value)
        {
            //Mau
            if(Notification != null) {
                Notification(Mediator.SAN_PHAM_CALL_MAU_GET_MA, new AppEvent<MauModel> { value = value });
                Notification = null;
            }
        }

        /// <summary>
        /// Views this instance.
        /// </summary>
        public void ShowForm()
        {
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
        public void ReviewGrid()
        {
            PostView();
        }
        /// <summary>
        /// Posts the view.
        /// </summary>
        private void PostView()
        {
            var a = MauService.GetAll();
            var listModel = a.Select(b => b.ToModel()).ToList();
            view.PostView(listModel);
        }

        /// <summary>
        /// Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(MauModel value)
        {
            try
            {
                var entity = value.ToEntity();
                MauService.Insert(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Models to entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Mau.</returns>
        protected virtual Mau ModelToEntity(MauModel model)
        {
            Mau a = MauService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(MauModel value)
        {
            var entity = ModelToEntity(value);
            MauService.Update(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value)
        {
            var entity = MauService.GetById(value);
            MauService.Delete(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(MauModel value)
        {
            Delete(value.ID);
        }
        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(string value)
        {
            var list = value.Split(',').Select(a => Convert.ToInt32(a)).ToList();
            foreach (var i in list)
            {
                Delete(i);
            }
        }
    }
}