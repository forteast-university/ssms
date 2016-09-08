using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Models;

namespace App.Views {
    public partial class ChatLieuView : Form {
        private readonly IBaseController<ChatLieuModel> controller;

        public ChatLieuView(IBaseController<ChatLieuModel> value) {
            controller = value;
            InitializeComponent();
        }

        public void View(){
            ShowDialog();
        }

        public void PostView(IEnumerable<ChatLieuModel> value) {
            Console.WriteLine("Count:" + value.Count());
            dataGridView.DataSource = new BindingSource { DataSource = value };
            var dataGridViewColumn = dataGridView.Columns["ID"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            
        }

        private void bntLuu_Click(object sender, EventArgs e) {
            var a = new ChatLieuModel {
                MaChatLieu = txtMaChatLieu.Text,
                TenChatLieu = txtTenChatLieu.Text,
            };
            controller.Insert(a);
        }

        private void bntLuaChon_Click(object sender, EventArgs e) {

        }

        private void bntHuy_Click(object sender, EventArgs e) {
            Hide();
        }
    }
}