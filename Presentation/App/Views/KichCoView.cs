﻿// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="KichCoView.cs" company="Thanh Dong University">
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
    ///     Class KichCoView.
    /// </summary>
    public partial class KichCoView : Form{
        /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<KichCoModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<KichCoModel> currentModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private KichCoModel currentModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KichCoView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public KichCoView(IBaseController<KichCoModel> value){
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
        public void PostView(IEnumerable<KichCoModel> value){
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn{Name = "CB", HeaderText = "", Width = 24, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = true};
            dataGridView.Columns.Add(c);

            dataGridView.DataSource = new BindingSource{DataSource = value};
            DataGridViewColumn dataGridViewColumn = dataGridView.Columns["ID"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;

            dataGridView.ClearSelection();
            dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvCommandos_DataBindingComplete);
            dataGridView.CurrentCell = null;
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

            if (txtMaCo.Text == ""){
                MessageBox.Show("Mã kích cỡ không được để rỗng");
                return;
            }
            if (txtTenCo.Text == ""){
                MessageBox.Show("Tên kích cỡ không được để rỗng");
                return;
            }

            currentModel = (KichCoModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){

                var cm = currentModelList.Where(c => c.MaCo == txtMaCo.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any()) {
                    MessageBox.Show("Mã kích cỡ đã tồn tại trong một bản ghi khác");
                    return;
                }
                var ct = currentModelList.Where(c => c.TenCo == txtTenCo.Text &&
                    c.ID != currentModel.ID);
                if (ct.Any()) {
                    MessageBox.Show("Tên kích cỡ đã tồn tại trong một bản ghi khác");
                    return;
                }

                currentModel.MaCo = txtMaCo.Text;
                currentModel.TenCo = txtTenCo.Text;
                controller.Update(currentModel);
                //re-update UI
                
                dataGridView.UpdateView("MaCo", currentModel.MaCo);
                dataGridView.UpdateView("TenCo", currentModel.TenCo);

                txtMaCo.Focus();
                txtMaCo.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else{
                var cm = currentModelList.Where(c => c.MaCo == txtMaCo.Text);
                if (cm.Any()) {
                    MessageBox.Show("Mã kích cỡ đã tồn tại");
                    return;
                }
                var ct = currentModelList.Where(c => c.TenCo == txtTenCo.Text);
                if (ct.Any()) {
                    MessageBox.Show("Tên kích cỡ đã tồn tại");
                    return;
                }
                currentModel = new KichCoModel{
                    MaCo = txtMaCo.Text,
                    TenCo = txtTenCo.Text,
                };

                controller.Insert(currentModel);
                txtMaCo.Focus();
                txtMaCo.SelectAll();
                //txtTenCo.Text = "";
                controller.ReviewGrid();
                 bntLuu.Enabled = true;
                bntTaoMoi.Enabled = false;
            }
        }

        /// <summary>
        ///     Handles the Click event of the bntLuaChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuaChon_Click(object sender, EventArgs e){
            currentModel = (KichCoModel) dataGridView.CurrentSelected(currentModelList);
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

            currentModel = (KichCoModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){
                txtMaCo.Text = currentModel.MaCo;
                txtTenCo.Text = currentModel.TenCo;
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
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} kích cỡ này?", selectedRows.Count),
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
            txtMaCo.Text = "";
            txtTenCo.Text = "";
            txtMaCo.Focus();
            bntLuaChon.Enabled = false;
            bntTaoMoi.Enabled = false;
            bntLuu.Enabled = true;
        }
    }
}