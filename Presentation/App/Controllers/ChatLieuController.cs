using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Extensions;
using App.Models;
using App.Properties;
using App.Service.Business;
using App.Views;
using AutoMapper;

namespace App.Controllers {
    public partial class ChatLieuController : IBaseController<ChatLieuModel> {
        
        private readonly IChatLieuService chatLieuService;
        private readonly ChatLieuView view;

        public ChatLieuController(IChatLieuService chatLieuService) {
            this.chatLieuService = chatLieuService;
            view = new ChatLieuView(this);
        }
        public void View(){
            PostView();
            view.View();
        }

        private void PostView() {
            var a = chatLieuService.GetAll();
            var listModel = a.Select(b => b.ToModel()).ToList();
            view.PostView(listModel);
        }

        public void Insert(ChatLieuModel value){
            try{
                var entity = value.ToEntity();
                chatLieuService.Insert(entity);
                PostView();
            }
            catch (Exception ex){
                MessageBox.Show(Resources.Insert_unsuccessful, 
                    Resources.Insert_Fault, MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);    
            }
        }

        public void Update(ChatLieuModel value){
            throw new NotImplementedException();
        }

        public void Delete(int value){
            throw new NotImplementedException();
        }

        public void Delete(ChatLieuModel value){
            throw new NotImplementedException();
        }

        public void Delete(string value){
            throw new NotImplementedException();
        }
    }
}
