// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="ChatLieuController.cs" company="Thanh Dong University">
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
    /// Class ChatLieuController.
    /// </summary>
    public partial class ChatLieuController: IBaseController<ChatLieuModel> {

        /// <summary>
        /// The chat lieu service
        /// </summary>
        private readonly IChatLieuService chatLieuService;

        /// <summary>
        /// The view
        /// </summary>
        private readonly ChatLieuView view;



        /// <summary>
        /// Initializes a new instance of the <see cref="ChatLieuController"/> class.
        /// </summary>
        /// <param name="chatLieuService">The chat lieu service.</param>
        public ChatLieuController(IChatLieuService chatLieuService) {
            this.chatLieuService = chatLieuService;
            view = new ChatLieuView(this);
        }

        public event EventHandler<AppEvent<ChatLieuModel>> Notification;

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
            var a = chatLieuService.GetAll();
            var listModel = a.Select(b => b.ToModel()).ToList();
            view.PostView(listModel);
        }

        /// <summary>
        /// Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(ChatLieuModel value) {
            try {
                var entity = value.ToEntity();
                chatLieuService.Insert(entity);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        protected virtual ChatLieu ModelToEntity(ChatLieuModel model) {
            ChatLieu a = chatLieuService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
        /// <summary>
        /// Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(ChatLieuModel value)
        {
            var entity = ModelToEntity(value);
            chatLieuService.Update(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value) {
            var entity = chatLieuService.GetById(value);
            chatLieuService.Delete(entity);
        }

        /// <summary>
        /// Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(ChatLieuModel value) {
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
