using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Models;
using App.Extensions;

namespace App.Views {
    public partial class ChatLieuView : Form {
        private readonly IBaseController<ChatLieuModel> controller;
        private IEnumerable<ChatLieuModel> valueChatLieuModel;
        public ChatLieuView(IBaseController<ChatLieuModel> value) {
            controller = value;
            InitializeComponent();
        }

        public void View() {
            ShowDialog();
        }

        public void PostView(IEnumerable<ChatLieuModel> value){
            valueChatLieuModel = value;
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

        private void bntLuaChon_Click(object sender, EventArgs e){
            var model = (ChatLieuModel) dataGridView.CurrentSelected(valueChatLieuModel);
            MessageBox.Show(model.MaChatLieu);
        }

        private void bntHuy_Click(object sender, EventArgs e) {
            Hide();
        }

        private void dgv_CellClick(System.Object sender, DataGridViewCellEventArgs e) {
            
            if (e.RowIndex < 0) {
                return;
            }

            int index = e.RowIndex;
            dataGridView.Rows[index].Selected = true;
        }
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
    }
}