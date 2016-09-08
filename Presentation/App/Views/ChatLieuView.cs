using System;
using System.Windows.Forms;
using App.Controllers;
using App.Models;

namespace App.Views{
    public partial class ChatLieuView : Form, IView{
        private IChatLieuController controller;

        public ChatLieuView(){
            InitializeComponent();
            Console.WriteLine("ChatLieuView:InitializeComponent");
        }

        public void SetController(IChatLieuController value){
            controller = value;
        }

        public void ClearGrid(){
            throw new NotImplementedException();
        }

        public void View(){
            ShowDialog();
        }

        public void Create(){
            throw new NotImplementedException();
        }

        public void Delete(){
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e){
            var a = new ChatLieuModel{
                MaChatLieu = "4",
                TenChatLieu = "5",
            };
            controller.Insert(a);
        }
    }
}