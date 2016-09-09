// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="ChatLieuView.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Extensions;
using App.Models;

namespace App.Views {
    /// <summary>
    /// Class ChatLieuView.
    /// </summary>
    public partial class ChatLieuView: Form {
        /// <summary>
        /// The controller
        /// </summary>
        private readonly IBaseController<ChatLieuModel> controller;
        /// <summary>
        /// The value chat lieu model
        /// </summary>
        private IEnumerable<ChatLieuModel> chatLieuModelList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatLieuView"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ChatLieuView(IBaseController<ChatLieuModel> value) {
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
        }

        /// <summary>
        /// Views this instance.
        /// </summary>
        public void View() {
            ShowDialog();
        }

        /// <summary>
        /// Posts the view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void PostView(IEnumerable<ChatLieuModel> value) {
            chatLieuModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn { Name = "CB", HeaderText = "", Width = 24, ReadOnly = true };
            dataGridView.Columns.Add(c);

            dataGridView.DataSource = new BindingSource { DataSource = value };
            DataGridViewColumn dataGridViewColumn = dataGridView.Columns["ID"];
            if(dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;

            dataGridView.ClearSelection();
        }

        /// <summary>
        /// Handles the Click event of the bntLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntLuu_Click(object sender, EventArgs e) {
            var model = (ChatLieuModel)dataGridView.CurrentSelected(chatLieuModelList);
            if(model != null) {
                controller.Update(model);
            } else {
                model = new ChatLieuModel {
                    MaChatLieu = txtMaChatLieu.Text,
                    TenChatLieu = txtTenChatLieu.Text,
                };
                controller.Insert(model);
            }
            controller.ReviewGrid();
        }

        /// <summary>
        /// Handles the Click event of the bntLuaChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntLuaChon_Click(object sender, EventArgs e) {
            var model = (ChatLieuModel)dataGridView.CurrentSelected(chatLieuModelList);
            MessageBox.Show(model.MaChatLieu);
        }

        /// <summary>
        /// Handles the Click event of the bntHuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntHuy_Click(object sender, EventArgs e) {
            Hide();
        }
        /// <summary>
        /// Handles the PreviewKeyDown event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PreviewKeyDownEventArgs"/> instance containing the event data.</param>
        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if(e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
                return;
            if(dataGridView.CurrentRow == null)
                return;
            var index = dataGridView.CurrentRow.Index;
            SelectCellAction(index);
        }

        /// <summary>
        /// Selects the cell action.
        /// </summary>
        /// <param name="index">The index.</param>
        private void SelectCellAction(int index) {
            dataGridView.Rows[index].Selected = true;
            dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);

            var selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                                where Convert.ToBoolean(row.Cells["CB"].Value)
                                select row).ToList();

            bntLuaChon.Enabled = (dataGridView.CurrentRow != null);
            bntXoa.Enabled = selectedRows.Count > 0;

            var model = (ChatLieuModel)dataGridView.CurrentSelected(chatLieuModelList);
            if(model != null) {
                txtMaChatLieu.Text = model.MaChatLieu;
                txtTenChatLieu.Text = model.TenChatLieu;
            }
        }

        /// <summary>
        /// DGV_s the cell click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgv_CellClick(Object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex < 0) {
                return;
            }
            var index = e.RowIndex;
            SelectCellAction(index);
        }

        /// <summary>
        /// Handles the RowPrePaint event of the dgv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPrePaintEventArgs"/> instance containing the event data.</param>
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        /// <summary>
        /// Handles the Click event of the bntXoa control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntXoa_Click(object sender, EventArgs e) {
            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["CB"].Value)
                                                  select row).ToList();
            if(
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} dòng?", selectedRows.Count), "Thông báo",
                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                var s = new List<string>();
                for(int i = 0; i <= selectedRows.Count - 1; i++) {
                    DataGridViewRow drow = dataGridView.Rows[i];
                    if(Convert.ToBoolean(drow.Cells["CB"].Value)) {
                        string id = drow.Cells["ID"].Value.ToString();
                        s.Add(id);
                    }
                }

                if(s.Count == 0)
                    return;
                dataGridView.Rows.Clear();
                controller.Delete(string.Join(",", s.ToArray()));
                controller.ReviewGrid();
            }
        }

        /// <summary>
        /// Handles the Click event of the bntTaoMoi control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntTaoMoi_Click(object sender, EventArgs e) {
            dataGridView.ClearSelection();
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
            txtMaChatLieu.Focus();
            bntLuaChon.Enabled = false;
        }
    }
}