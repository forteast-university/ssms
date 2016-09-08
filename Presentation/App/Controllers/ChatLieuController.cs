using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Service.Business;
using App.Views;

namespace App.Controllers {
    public partial class ChatLieuController : IChatLieuController{
        
        private IChatLieuService chatLieuService;
        
        private IView view;

        public ChatLieuController(IChatLieuService chatLieuService) {
            this.chatLieuService = chatLieuService;
            
            view = new ChatLieuView();
            view.SetController(this);
        }
        public void View() {
             view.View();
        }

        public void Insert(ChatLieu value){
            Console.WriteLine(value.MaChatLieu);
        }
    }
}
