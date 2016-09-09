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
    /// Class CongViecController.
    /// </summary>
    public partial class CongViecController : IBaseController<CongViecModel>
    {

        /// <summary>
        /// The cong viec service
        /// </summary>
        private readonly ICongViecService CongViecService;

        /// <summary>
        /// The view
        /// </summary>
        private readonly CongViecView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="CongViecController"/> class.
        /// </summary>
        /// <param name="CongViecService">The cong viec service.</param>
        public CongViecController(ICongViecService CongViecService)
        {
            this.CongViecService = CongViecService;
            view = new CongViecView(this);
        }

        public event EventHandler<AppEvent<CongViecModel>> Notification;

        /// <summary>
        /// Views this instance.
        /// </summary>
        public void View()
        {
            PostView();
            view.View();
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
            var a = CongViecService.GetAll();
            var listModel = a.Select(b => b.ToModel()).ToList();
            view.PostView(listModel);
        }

        /// <summary>
        /// Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(CongViecModel value)
        {
            try
            {
                var entity = value.ToEntity();
                CongViecService.Insert(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        protected virtual CongViec ModelToEntity(CongViecModel model)
        {
            CongViec a = CongViecService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(CongViecModel value)
        {
            var entity = ModelToEntity(value);
            CongViecService.Update(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value)
        {
            var entity = CongViecService.GetById(value);
            CongViecService.Delete(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(CongViecModel value)
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