// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-11-2016
// ***********************************************************************
// <copyright file="HoaDonBanListView.cs" company="Thanh Dong University">
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

namespace App.Views {
    /// <summary>
    /// Class HoaDonBanListView.
    /// </summary>
    public partial class HoaDonBanListView: Form {
        /// <summary>
        /// The controller
        /// </summary>
        private readonly IHoaDonBanController<HoaDonBanModel> controller;

        /// <summary>
        /// The value chat lieu model
        /// </summary>
        private IEnumerable<HoaDonBanModel> currentModelList;

        /// <summary>
        /// The current model
        /// </summary>
        private HoaDonBanModel currentModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoaDonBanListView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public HoaDonBanListView(IHoaDonBanController<HoaDonBanModel> value) {
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
        public void PostView(IEnumerable<HoaDonBanModel> value) {
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn { Name = "CB", HeaderText = "", Width = 24, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = true };
            dataGridView.Columns.Add(c);
            dataGridView.DataSource = new BindingSource { DataSource = value };

            dataGridView.Columns["ID"].Display(false);
            dataGridView.Columns["KhachHangID"].Display(false);
            dataGridView.Columns["KhachHang"].Display(false);
            dataGridView.Columns["NhanVienID"].Display(false);
            dataGridView.Columns["NhanVien"].Display(false);

            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;
            //   bntTimKiem.Enabled = false;
            bntTaoMoi.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the bntLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuu_Click(object sender, EventArgs e) {

            // todo: tìm kiếm

            //if (txtMaGiayDep.Text == ""){
            //    MessageBox.Show("Mã sản phẩm không được để rỗng");
            //    return;
            //}
            //if (txtTenGiayDep.Text == ""){
            //    MessageBox.Show("Tên sản phẩm không được để rỗng");
            //    return;
            //}
            //currentModel = (HoaDonBanModel) dataGridView.CurrentSelected(currentModelList);
            //if (currentModel != null){

            //    var cm = currentModelList.Where(c => c.MaGiayDep == txtMaGiayDep.Text &&
            //        c.ID != currentModel.ID);
            //    if (cm.Any()) {
            //        MessageBox.Show("Mã sản phẩm đã tồn tại trong một bản ghi khác");
            //        return;
            //    }
            //    var ct = currentModelList.Where(c => c.TenGiayDep == txtTenGiayDep.Text &&
            //        c.ID != currentModel.ID);
            //    if (ct.Any()) {
            //        MessageBox.Show("Tên sản phẩm đã tồn tại trong một bản ghi khác");
            //        return;
            //    }

            //    currentModel.MaGiayDep = txtMaGiayDep.Text;
            //    currentModel.TenGiayDep = txtTenGiayDep.Text;
            //    controller.Update(currentModel);
            //    //re-update UI

            //    dataGridView.UpdateView("MaGiayDep", currentModel.MaGiayDep);
            //    dataGridView.UpdateView("TenGiayDep", currentModel.TenGiayDep);

            //    txtMaGiayDep.Focus();
            //    txtMaGiayDep.SelectAll();
            //    bntTaoMoi.Enabled = true;
            //    bntLuu.Enabled = true;
            //}
            //else{
            //    var cm = currentModelList.Where(c => c.MaGiayDep == txtMaGiayDep.Text);
            //    if (cm.Any()) {
            //        MessageBox.Show("Mã sản phẩm đã tồn tại");
            //        return;
            //    }
            //    var ct = currentModelList.Where(c => c.TenGiayDep == txtTenGiayDep.Text);
            //    if (ct.Any()) {
            //        MessageBox.Show("Tên sản phẩm đã tồn tại");
            //        return;
            //    }
            //    currentModel = new HoaDonBanModel{
            //        MaGiayDep = txtMaGiayDep.Text,
            //        TenGiayDep = txtTenGiayDep.Text,
            //    };

            //    controller.Insert(currentModel);
            //    txtMaGiayDep.Focus();
            //    txtMaGiayDep.SelectAll();
            //    //txtTenGiayDep.Text = "";
            //    controller.ReviewGrid();
            //    bntTaoMoi.Enabled = true;
            //    bntLuu.Enabled = true;
            //}
        }

        /// <summary>
        /// Handles the Click event of the bntLuaChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuaChon_Click(object sender, EventArgs e) {
            currentModel = (HoaDonBanModel)dataGridView.CurrentSelected(currentModelList);
            //MessageBox.Show(currentModel.MaGiayDep);
        }

        /// <summary>
        /// Handles the Click event of the bntHuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntHuy_Click(object sender, EventArgs e) {
            Hide();
        }

        /// <summary>
        /// Handles the PreviewKeyDown event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PreviewKeyDownEventArgs" /> instance containing the event data.</param>
        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if(e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
                return;
            if(dataGridView.CurrentRow == null)
                return;
            int index = dataGridView.CurrentRow.Index;
            SelectCellAction(index, 0, false);
        }

        /// <summary>
        /// Selects the cell action.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="column">The column.</param>
        /// <param name="isMmouse">if set to <c>true</c> [is mmouse].</param>
        private void SelectCellAction(int index, int column, bool isMmouse) {
            dataGridView.Rows[index].Selected = true;
            if(!isMmouse) {
                dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);
            } else {
                if(column == 0) {
                    dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);
                }
            }

            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["CB"].Value)
                                                  select row).ToList();

            bntLuaChon.Enabled = (dataGridView.CurrentRow != null);
            bntXoa.Enabled = selectedRows.Count > 0;

            //currentModel = (HoaDonBanModel)dataGridView.CurrentSelected(currentModelList);
            //if(currentModel != null) {
            //    txtTimKiem.Text = currentModel.MaGiayDep;
            //}
            // bntTimKiem.Enabled = true;
            bntTaoMoi.Enabled = true;
        }

        /// <summary>
        /// DGV_s the cell click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void dgv_CellClick(Object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex < 0) {
                return;
            }
            int index = e.RowIndex;

            SelectCellAction(e.RowIndex, e.ColumnIndex, true);
        }

        /// <summary>
        /// Handles the RowPrePaint event of the dgv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPrePaintEventArgs" /> instance containing the event data.</param>
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        /// <summary>
        /// Handles the Click event of the bntXoa control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntXoa_Click(object sender, EventArgs e) {
            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["CB"].Value)
                                                  select row).ToList();
            if(
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} hóa đơn này không?", selectedRows.Count),
                Resources.View_Confirm,
                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                var s = (from row in dataGridView.Rows.Cast<DataGridViewRow>() where Convert.ToBoolean(row.Cells["CB"].Value) select row.Cells["ID"].Value.ToString()).ToList();

                if(s.Count == 0)
                    return;
                dataGridView.Rows.Clear();
                controller.Delete(string.Join(",", s.ToArray()));
                controller.ReviewGrid();
            }
            //bntTimKiem.Enabled = false;
            bntTaoMoi.Enabled = true;
        }
        /// <summary>
        /// Handles the Click event of the bntTaoMoi control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntTaoMoi_Click(object sender, EventArgs e) {
            controller.ShowHoaDonBanView(null);
        }
        /// <summary>
        /// Handles the CellDoubleClick event of the dgv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            currentModel = (HoaDonBanModel)dataGridView.CurrentSelected(currentModelList);
            controller.ShowHoaDonBanView(currentModel);
        }

        /// <summary>
        /// Handles the Click event of the TimKiem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            var dataModelList = DataTimKiem();
            if(dataModelList.Any()) {
                dataGridView.DataSource = new BindingSource { DataSource = dataModelList };
            }
        }

        /// <summary>
        /// Datas the tim kiem.
        /// </summary>
        /// <returns>IEnumerable&lt;HoaDonBanModel&gt;.</returns>
        private IEnumerable<HoaDonBanModel> DataTimKiem() {
            var dataModelList = currentModelList;
            // var dataModelList= currentModelList.Where(c => c.MaGiayDep.Contains(txtTimKiem.Text.Trim()) || c.TenGiayDep.Contains(txtTimKiem.Text.Trim()));      
            if (cbbTimKiem.SelectedItem == "Mã hóa đơn")
            {
                dataModelList = currentModelList.Where(c => c.SoHDB.Contains(txtTimKiem.Text.Trim()));
            }
            else if (cbbTimKiem.SelectedItem == "Mã khách hàng")
            {
                dataModelList = currentModelList.Where(c => c.MaKhach.Contains(txtTimKiem.Text.Trim()));
            }
            else if (cbbTimKiem.SelectedItem == "Mã nhân viên")
            {
                dataModelList = currentModelList.Where(c => c.MaNV.Contains(txtTimKiem.Text.Trim()));
            }
            return dataModelList;
        }

        /// <summary>
        /// Handles the Click event of the bntTimKiem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntTimKiem_Click(object sender, EventArgs e) {

            var dataModelList = DataTimKiem();
            if(dataModelList.Any()) {
                dataGridView.DataSource = new BindingSource { DataSource = dataModelList };
            } else {
                MessageBox.Show("không tìm thấy hóa đơn!");
            }
        }

        /// <summary>
        /// The danh sach t
        /// </summary>
        string[] danhSachT =
        {
            "Mã hóa đơn", 
            "Mã nhân viên",
            "Mã khách hàng"
        };

        /// <summary>
        /// Handles the Load event of the HoaDonBanListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SanPhanListView_Load(object sender, EventArgs e) {
            cbbTimKiem.DataSource = danhSachT;
        }
    }
}