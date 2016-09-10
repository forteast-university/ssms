// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="SanPhamController.cs" company="Thanh Dong University">
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

namespace App.Controllers
{
    /// <summary>
    ///     Class SanPhamController.
    /// </summary>
    public class SanPhamController : ISanPhamController<SanPhamModel>
    {
        /// <summary>
        ///     The chat lieu service
        /// </summary>
        private readonly ISanPhamService SanPhamService;

        private SanPhamView sanPhamView;

        /// <summary>
        ///     The view
        /// </summary>
        private SanPhanListView sanPhanListView;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SanPhamController" /> class.
        /// </summary>
        /// <param name="SanPhamService">The chat lieu service.</param>
        public SanPhamController(ISanPhamService SanPhamService)
        {
            this.SanPhamService = SanPhamService;
            //view = new SanPhanListView(this);
            sanPhamView = new SanPhamView(this);
        }

        public event EventHandler<AppEvent<SanPhamModel>> Notification;

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void View()
        {
            PostView();
            sanPhanListView.View();
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
        public void Insert(SanPhamModel value)
        {
            try
            {
                SanPham entity = value.ToEntity();
                SanPhamService.Insert(entity);
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
        public void Update(SanPhamModel value)
        {
            SanPham entity = ModelToEntity(value);
            SanPhamService.Update(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value)
        {
            SanPham entity = SanPhamService.GetById(value);
            SanPhamService.Delete(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(SanPhamModel value)
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

        public void HideSanPhamView()
        {
            sanPhamView.Hide();
        }

        public void ShowSanPhamView(SanPhamModel value)
        {
            sanPhamView.InitializeForm(value);
            sanPhamView.ShowDialog();
        }

        public void SetSanPhamListView(Form value)
        {
            sanPhanListView = (SanPhanListView)value;
        }

        /// <summary>
        ///     Posts the view.
        /// </summary>
        private void PostView()
        {
            IEnumerable<SanPham> a = SanPhamService.GetAll();
            List<SanPhamModel> listModel = a.Select(b => b.ToModel()).ToList();
            sanPhanListView.PostView(listModel);
        }

        protected virtual SanPham ModelToEntity(SanPhamModel model)
        {
            SanPham a = SanPhamService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}