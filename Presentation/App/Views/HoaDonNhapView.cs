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
    public partial class HoaDonNhapView : Form{
        /// <summary>
        ///     The controller
        /// </summary>
        private readonly IHoaDonNhapController<HoaDonNhapModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<HoaDonNhapModel> currentModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private HoaDonNhapModel currentModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChatLieuView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public HoaDonNhapView(IHoaDonNhapController<HoaDonNhapModel> value) {
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
            txtNgayNhap.Format = DateTimePickerFormat.Custom;
            txtNgayNhap.CustomFormat = "dd/MM/yyyy";
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
        public void PostView(IEnumerable<HoaDonNhapModel> value){
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn{Name = "CB", HeaderText = "", Width = 24, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = true};
            dataGridView.Columns.Add(c);

            dataGridView.DataSource = new BindingSource{DataSource = value};
            dataGridView.Columns["ID"].Display(false);
            dataGridView.Columns["NhanVienID"].Display(false);
            dataGridView.Columns["NhaCungCapID"].Display(false);
            dataGridView.Columns["NhanVien"].Display(false);
            dataGridView.Columns["NhaCungCap"].Display(false);
            //if(dataGridView.Columns["MaHoaDonNhap"]!=null)
            //    dataGridView.Columns["MaHoaDonNhap"].DisplayIndex = 0;
            //if(dataGridView.Columns["TenHoaDonNhap"]!=null)
            //    dataGridView.Columns["TenHoaDonNhap"].DisplayIndex = 1;
            //if(dataGridView.Columns["GioiTinh"]!=null)
            //    dataGridView.Columns["GioiTinh"].DisplayIndex = 3;
            //if(dataGridView.Columns["NgaySinhModel"]!=null)
            //    dataGridView.Columns["NgaySinhModel"].DisplayIndex = 4;

            
            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = false;

            //bntSuaMatKhau.Visible = false;
            //txtMatKhau.Visible = (!bntSuaMatKhau.Visible);
            //txtMatKhau2.Visible = (!bntSuaMatKhau.Visible);
            
            currentModel = null;

        }

        /// <summary>
        ///     Handles the Click event of the bntLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuu_Click(object sender, EventArgs e){

            /*
            if (txtMaHoaDonNhap.Text == ""){
                MessageBox.Show("Mã nhân viên không được để rỗng");
                return;
            }
            if (txtTenHoaDonNhap.Text == ""){
                MessageBox.Show("Tên nhân viên không được để rỗng");
                return;
            }

            currentModel = (HoaDonNhapModel) dataGridView.CurrentSelected(currentModelList);
            if (currentModel != null){

                var cm = currentModelList.Where(c => c.MaHoaDonNhap == txtMaHoaDonNhap.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any()) {
                    MessageBox.Show("Mã nhân viên đã tồn tại trong một bản ghi khác");
                    return;
                }
                if (!bntSuaMatKhau.Visible)
                {
                    if (txtMatKhau.Text != txtMatKhau2.Text)
                    {
                        MessageBox.Show("Mật khẩu không giống nhau");
                        return;
                    }
                    currentModel.MatKhau = txtMatKhau.Text.ToEncrypt();
                }
                currentModel.MaHoaDonNhap = txtMaHoaDonNhap.Text;
                currentModel.TenHoaDonNhap = txtTenHoaDonNhap.Text;
                currentModel.DiaChi = txtDiaChi.Text;
                currentModel.DienThoai = txtDienThoai.Text;
                currentModel.GioiTinh = txtGioiTinh.Text;
                currentModel.NgaySinh = txtNgaySinh.Text.ToDateTime();
                currentModel.MaCV = txtMaCV.Text;

                controller.Update(currentModel);

                //re-update UI
                dataGridView.UpdateView("MaHoaDonNhap", currentModel.MaHoaDonNhap);
                dataGridView.UpdateView("TenHoaDonNhap", currentModel.TenHoaDonNhap);
                dataGridView.UpdateView("DiaChi", currentModel.DiaChi);
                dataGridView.UpdateView("DienThoai", currentModel.DienThoai);
                dataGridView.UpdateView("GioiTinh", currentModel.GioiTinh);
                dataGridView.UpdateView("NgaySinh", currentModel.NgaySinhModel);
                dataGridView.UpdateView("MaCV", currentModel.MaCV);

                txtMaHoaDonNhap.Focus();
                txtMaHoaDonNhap.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else{
                var cm = currentModelList.Where(c => c.MaHoaDonNhap == txtMaHoaDonNhap.Text);
                if (cm.Any()) {
                    MessageBox.Show("Mã nhân viên đã tồn tại");
                    return;
                }
                if(txtMatKhau.Text != txtMatKhau2.Text) {
                    MessageBox.Show("Mật khẩu không giống nhau");
                    return;
                }
                //var ct = currentModelList.Where(c => c.TenHoaDonNhap == txtTenHoaDonNhap.Text);
                //if (ct.Any()) {
                //    MessageBox.Show("Tên nhân viên đã tồn tại");
                //    return;
                //}
                currentModel = new HoaDonNhapModel{
                    MaHoaDonNhap = txtMaHoaDonNhap.Text,
                    TenHoaDonNhap = txtTenHoaDonNhap.Text,
                    DiaChi = txtDiaChi.Text,
                    DienThoai = txtDienThoai.Text,
                    GioiTinh = txtGioiTinh.Text,
                    NgaySinh = txtNgaySinh.Text.ToDateTime(),
                    MatKhau = txtMatKhau.Text.ToEncrypt(),
                    MaCV = txtMaCV.Text
                };
                
                controller.Insert(currentModel);
                txtMaHoaDonNhap.Focus();
                txtMaHoaDonNhap.SelectAll();
                //txtTenChatLieu.Text = "";
                controller.ReviewGrid();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }

            */

        }

        /// <summary>
        ///     Handles the Click event of the bntLuaChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuaChon_Click(object sender, EventArgs e){
            //currentModel = (HoaDonNhapModel) dataGridView.CurrentSelected(currentModelList);
            //MessageBox.Show(currentModel.MaHoaDonNhap);
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
            var selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>() where Convert.ToBoolean(row.Cells["CB"].Value) select row).ToList();

            bntLuaChon.Enabled = (dataGridView.CurrentRow != null);
            bntXoa.Enabled = selectedRows.Count > 0;

            currentModel = (HoaDonNhapModel) dataGridView.CurrentSelected(currentModelList);
            
            //if (currentModel != null){
            //    txtMaHoaDonNhap.Text = currentModel.MaHoaDonNhap;
            //    txtTenHoaDonNhap.Text = currentModel.TenHoaDonNhap;
            //    txtDiaChi.Text = currentModel.DiaChi;
            //    txtDienThoai.Text = currentModel.DienThoai;
            //    txtNgaySinh.Text = currentModel.NgaySinh.ToDateString();
            //    txtMaCV.Text = currentModel.MaCV;
            //    txtGioiTinh.Text = currentModel.GioiTinh;
            //}

            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = true;
            //bntSuaMatKhau.Visible = true;
            //txtMatKhau.Visible = (!bntSuaMatKhau.Visible);
            //txtMatKhau2.Visible = (!bntSuaMatKhau.Visible);
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
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} nhân viên này?", selectedRows.Count), 
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
            //dataGridView.ClearSelection();
            //txtMaHoaDonNhap.Text = "";
            //txtTenHoaDonNhap.Text = "";
            //txtDiaChi.Text = "";
            //txtDienThoai.Text = "";
            //txtMaHoaDonNhap.Focus();
            //bntLuaChon.Enabled = false;
            //bntTaoMoi.Enabled = false;
            //bntLuu.Enabled = true;
            //bntSuaMatKhau.Visible = false;
            //txtMatKhau.Visible = (!bntSuaMatKhau.Visible);
            //txtMatKhau2.Visible = (!bntSuaMatKhau.Visible);
        }
        public void SetTxtMaCv(string ma)
        {
            //txtMaCV.Text = ma;
        }
        public void InitializeForm(HoaDonNhapModel value)
        {
            //txtMaCV.Text = value;
        }
        private void bntCongViec_Click(object sender, EventArgs e) {
            //controller.ShowCongViecView(txtMaCV.Text);
        }

        private void bntSuaMatKhau_Click(object sender, EventArgs e)
        {
            //bntSuaMatKhau.Visible = false;
            //txtMatKhau.Visible = (!bntSuaMatKhau.Visible);
            //txtMatKhau2.Visible = (!bntSuaMatKhau.Visible);
        }
    }
}