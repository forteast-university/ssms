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
using App.Controllers.Interface;
using App.Extensions;
using App.Models;
using App.Properties;

namespace App.Views{
    /// <summary>
    ///     Class ChatLieuView.
    /// </summary>
    public partial class NhaCungCapView : Form{
        /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<NhaCungCapModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<NhaCungCapModel> currentModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private NhaCungCapModel currentModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChatLieuView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NhaCungCapView(IBaseController<NhaCungCapModel> value) {
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
        public void PostView(IEnumerable<NhaCungCapModel> value){
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn{Name = "CB", HeaderText = "", Width = 24, ReadOnly = true};
            dataGridView.Columns.Add(c);

            dataGridView.DataSource = new BindingSource{DataSource = value};
            DataGridViewColumn dataGridViewColumn = dataGridView.Columns["ID"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;

            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;
            bntLuu.Enabled = false;
            bntTaoMoi.Enabled = true;
        }

        /// <summary>
        ///     Handles the Click event of the bntLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuu_Click(object sender, EventArgs e){

            if (txtMaNCC.Text == ""){
                MessageBox.Show("Mã nhà cung cấp không được để rỗng");
                return;
            }
            if (txtTenNCC.Text == ""){
                MessageBox.Show("Tên nhà cung cấp không được để rỗng");
                return;
            }

            currentModel = (NhaCungCapModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){

                var cm = currentModelList.Where(c => c.MaNCC == txtMaNCC.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any()) {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại trong một bản ghi khác");
                    return;
                }
                var ct = currentModelList.Where(c => c.TenNCC == txtTenNCC.Text &&
                    c.ID != currentModel.ID);
                if (ct.Any()) {
                    MessageBox.Show("Tên nhà cung cấp đã tồn tại trong một bản ghi khác");
                    return;
                }

                currentModel.MaNCC = txtMaNCC.Text;
                currentModel.TenNCC = txtTenNCC.Text;
                currentModel.DiaChi = txtDiaChi.Text;
                currentModel.DienThoai = txtDienThoai.Text;

                controller.Update(currentModel);

                //re-update UI
                dataGridView.UpdateView("MaNCC", currentModel.MaNCC);
                dataGridView.UpdateView("TenNCC", currentModel.TenNCC);
                dataGridView.UpdateView("DiaChi", currentModel.DiaChi);
                dataGridView.UpdateView("DienThoai", currentModel.DienThoai);

                txtMaNCC.Focus();
                txtMaNCC.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else{
                var cm = currentModelList.Where(c => c.MaNCC == txtMaNCC.Text);
                if (cm.Any()) {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại");
                    return;
                }
                var ct = currentModelList.Where(c => c.TenNCC == txtTenNCC.Text);
                if (ct.Any()) {
                    MessageBox.Show("Tên nhà cung cấp đã tồn tại");
                    return;
                }
                currentModel = new NhaCungCapModel{
                    MaNCC = txtMaNCC.Text,
                    TenNCC = txtTenNCC.Text,
                    DiaChi = txtDiaChi.Text,
                    DienThoai = txtDienThoai.Text,
                };

                controller.Insert(currentModel);
                txtMaNCC.Focus();
                txtMaNCC.SelectAll();
                //txtTenChatLieu.Text = "";
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
            currentModel = (NhaCungCapModel) dataGridView.CurrentSelected(currentModelList);
            MessageBox.Show(currentModel.MaNCC);
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

            currentModel = (NhaCungCapModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){
                txtMaNCC.Text = currentModel.MaNCC;
                txtTenNCC.Text = currentModel.TenNCC;
                txtDiaChi.Text = currentModel.DiaChi;
                txtDienThoai.Text = currentModel.DienThoai;
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
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} nhà cung cấp này?", selectedRows.Count), 
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
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtMaNCC.Focus();
            bntLuaChon.Enabled = false;
            bntTaoMoi.Enabled = false;
            bntLuu.Enabled = true;
        }
    }
}