﻿// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="TheLoaiView.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Controllers.Interface;
using App.Extensions;
using App.Models;
using App.Properties;

namespace App.Views{
    /// <summary>
    ///     Class TheLoaiView.
    /// </summary>
    public partial class TheLoaiView : Form{
        /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<TheLoaiModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<TheLoaiModel> currentModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private TheLoaiModel currentModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TheLoaiView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public TheLoaiView(IBaseController<TheLoaiModel> value){
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
        }

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void View(){
            ShowDialog();
        }

        /// <summary>
        ///     Posts the view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void PostView(IEnumerable<TheLoaiModel> value){
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn{Name = "CB", HeaderText = "", Width = 24, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = true};
            dataGridView.Columns.Add(c);

            dataGridView.DataSource = new BindingSource{DataSource = value};
            DataGridViewColumn dataGridViewColumn = dataGridView.Columns["ID"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;

            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;
            dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvCommandos_DataBindingComplete);
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = false;

        }
        void dgvCommandos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView.ClearSelection();
        }

        /// <summary>
        ///     Handles the Click event of the bntLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuu_Click(object sender, EventArgs e){

            if (txtMaLoai.Text == ""){
                MessageBox.Show("Mã thể loại không được để rỗng");
                return;
            }
            if (txtTenLoai.Text == ""){
                MessageBox.Show("Tên thể loại không được để rỗng");
                return;
            }

            currentModel = (TheLoaiModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){

                var cm = currentModelList.Where(c => c.MaLoai == txtMaLoai.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any()) {
                    MessageBox.Show("Mã thể loại đã tồn tại trong một bản ghi khác");
                    return;
                }
                var ct = currentModelList.Where(c => c.TenLoai == txtTenLoai.Text &&
                    c.ID != currentModel.ID);
                if (ct.Any()) {
                    MessageBox.Show("Tên thể loại đã tồn tại trong một bản ghi khác");
                    return;
                }

                currentModel.MaLoai = txtMaLoai.Text;
                currentModel.TenLoai = txtTenLoai.Text;
                controller.Update(currentModel);
                //re-update UI
                
                dataGridView.UpdateView("MaLoai", currentModel.MaLoai);
                dataGridView.UpdateView("TenLoai", currentModel.TenLoai);

                txtMaLoai.Focus();
                txtMaLoai.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else{
                var cm = currentModelList.Where(c => c.MaLoai == txtMaLoai.Text);
                if (cm.Any()) {
                    MessageBox.Show("Mã thể loại đã tồn tại");
                    return;
                }
                var ct = currentModelList.Where(c => c.TenLoai == txtTenLoai.Text);
                if (ct.Any()) {
                    MessageBox.Show("Tên thể loại đã tồn tại");
                    return;
                }
                currentModel = new TheLoaiModel{
                    MaLoai = txtMaLoai.Text,
                    TenLoai = txtTenLoai.Text,
                };

                controller.Insert(currentModel);
                txtMaLoai.Focus();
                txtMaLoai.SelectAll();
                //txtTenLoai.Text = "";
                controller.ReviewGrid();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
        }

        /// <summary>
        ///     Handles the Click event of the bntLuaChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuaChon_Click(object sender, EventArgs e){
            currentModel = (TheLoaiModel) dataGridView.CurrentSelected(currentModelList);
            controller.Select(currentModel);
        }

        /// <summary>
        ///     Handles the Click event of the bntHuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntHuy_Click(object sender, EventArgs e){
            Hide();
        }

        /// <summary>
        ///     Handles the PreviewKeyDown event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PreviewKeyDownEventArgs" /> instance containing the event data.</param>
        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e){
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
                return;
            if (dataGridView.CurrentRow == null)
                return;
            int index = dataGridView.CurrentRow.Index;
            SelectCellAction(index, 0, false);
        }

        /// <summary>
        ///     Selects the cell action.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="column"></param>
        /// <param name="isMmouse"></param>
        private void SelectCellAction(int index, int column, bool isMmouse){
            dataGridView.Rows[index].Selected = true;
            if (!isMmouse){
                dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);
            }
            else{
                if (column == 0){
                    dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);
                }
            }

            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                where Convert.ToBoolean(row.Cells["CB"].Value)
                select row).ToList();

            bntLuaChon.Enabled = (dataGridView.CurrentRow != null);
            bntXoa.Enabled = selectedRows.Count > 0;

            currentModel = (TheLoaiModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){
                txtMaLoai.Text = currentModel.MaLoai;
                txtTenLoai.Text = currentModel.TenLoai;
            }
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = true;
        }

        /// <summary>
        ///     DGV_s the cell click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void dgv_CellClick(Object sender, DataGridViewCellEventArgs e){
            if (e.RowIndex < 0){
                return;
            }
            int index = e.RowIndex;

            SelectCellAction(e.RowIndex, e.ColumnIndex, true);
        }

        /// <summary>
        ///     Handles the RowPrePaint event of the dgv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPrePaintEventArgs" /> instance containing the event data.</param>
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e){
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        /// <summary>
        ///     Handles the Click event of the bntXoa control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntXoa_Click(object sender, EventArgs e){
            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                where Convert.ToBoolean(row.Cells["CB"].Value)
                select row).ToList();
            if (
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} thể loại này?", selectedRows.Count),
                Resources.View_Confirm,
                    MessageBoxButtons.YesNo) == DialogResult.Yes){
                var s = (from row in dataGridView.Rows.Cast<DataGridViewRow>() where Convert.ToBoolean(row.Cells["CB"].Value) select row.Cells["ID"].Value.ToString()).ToList();

                if (s.Count == 0)
                    return;
                dataGridView.Rows.Clear();
                controller.Delete(string.Join(",", s.ToArray()));
                controller.ReviewGrid();
            }
            bntLuu.Enabled = false;
            bntTaoMoi.Enabled = true;
        }

        /// <summary>
        ///     Handles the Click event of the bntTaoMoi control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntTaoMoi_Click(object sender, EventArgs e){
            dataGridView.ClearSelection();
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMaLoai.Focus();
            bntLuaChon.Enabled = false;
            bntTaoMoi.Enabled = false;
            bntLuu.Enabled = true;
        }
    }
}