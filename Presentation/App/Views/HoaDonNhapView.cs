// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-14-2016
// ***********************************************************************
// <copyright file="ChatLieuView.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Controllers.Interface;
using App.Extensions;
using App.Models;
using App.Properties;

namespace App.Views {
    /// <summary>
    /// Class ChatLieuView.
    /// </summary>
    public partial class HoaDonNhapView: Form {
        /// <summary>
        /// The controller
        /// </summary>
        private readonly IHoaDonNhapController<HoaDonNhapModel> controller;

        /// <summary>
        /// The value chat lieu model
        /// </summary>
        private HoaDonNhapModel currentHoaDonNhapModel;

        /// <summary>
        /// The current model
        /// </summary>
        private ChiTietHdnModel currentModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatLieuView" /> class.
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
        /// Views this instance.
        /// </summary>
        public void View() {
            ShowDialog();
        }

        /// <summary>
        /// The is edit mode
        /// </summary>
        private bool isEditMode = true;

        /// <summary>
        /// Sets the mode view.
        /// </summary>
        /// <param name="mode">The mode.</param>
        public void SetModeView(int mode){
            isEditMode = (mode == 1);
        }

        /// <summary>
        /// Posts the view.
        /// </summary>
        public void HideForm(){
            isEditMode = true;
            dataGridView.Columns.Clear();
            currentListDataTable = null;

            txtMaHoaDon.Text    = "";
            txtMaNhanVien.Text  = "";
            txtMaNCC.Text       = "";
            txtNgayNhap.Text    = "";
            txtTongTien.Text    = "";

            this.Hide();
        }

        /// <summary>
        /// Posts the view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void PostView(HoaDonNhapModel value) {
            currentHoaDonNhapModel = value;
            currentListDataTable = null;

            dataGridView.Columns.Clear();
            var g = new DataGridViewCheckBoxColumn { Name = "CB", HeaderText = "", Width = 24, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = true };
            dataGridView.Columns.Add(g);


            dataSourceDataTable = value.ChiTietHDNModel.ToDataTable();
            dataSourceDataTable.AcceptChanges();
            dataBindingSource.DataSource = dataSourceDataTable;
            dataGridView.DataSource = dataBindingSource;

            //dataGridView.DataSource = new BindingSource { DataSource = value.ChiTietHDNModel };

            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.ID)].Display(false);
            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.SanPhamID)].Display(false);
            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.SanPham)].Display(false);
            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.HoaDonNhapID)].Display(false);
            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.HoaDonNhap)].Display(false);
            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.SoHDN)].Display(false);
            dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.IDModel)].Display(false);

            if (dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)] != null)
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].DisplayIndex = 1;

            if (value != null){
                if (value.SoHDN!=null) txtMaHoaDon.Text = value.SoHDN;
                if (value.MaNV != null) txtMaNhanVien.Text = value.MaNV;
                if (value.MaNCC != null) txtMaNCC.Text = value.MaNCC;
                if (value.NgayNhap != null) txtNgayNhap.Text = value.NgayNhap.ToDateString();
                if (value.TongTien != null) txtTongTien.Text = value.TongTien.ToString();
            }

            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;

            if (isEditMode){
                bntLuu.Enabled = false;
                bntTaoMoi.Enabled = true;
                bntXoa.Enabled = false;
                bntLuaChon.Enabled = false;
                txtMaHoaDon.Focus();
            }
            else{
                bntLuu.Enabled = false;
                bntTaoMoi.Enabled = false;
                bntXoa.Enabled = false;
            }
            currentModel = null;
        }

        /// <summary>
        /// Handles the Click event of the bntLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuu_Click(object sender, EventArgs e) {
            if (txtMaHoaDon.Text == "") {
                MessageBox.Show("Mã nhà cung cấp không được để rỗng");
                txtMaHoaDon.Focus();
                return;
            }
            if (txtMaNhanVien.Text == ""){
                MessageBox.Show("Mã nhân viên không được để rỗng");
                txtMaNhanVien.Focus();
                return;
            }
            if (txtMaNCC.Text == ""){
                MessageBox.Show("Mã nhà cung cấp không được để rỗng");
                txtMaNCC.Focus();
                return;
            }
            if (txtTongTien.Text.ToDecimal() <=0) {
                MessageBox.Show("Hóa đơn phải có gía trị lớn hơn 1 đơn vị");
                txtTongTien.Focus();
                return;
            }
            
            currentHoaDonNhapModel.SoHDN = txtMaHoaDon.Text;
            currentHoaDonNhapModel.MaNCC = txtMaNCC.Text;
            currentHoaDonNhapModel.MaNV = txtMaNhanVien.Text;
            currentHoaDonNhapModel.NgayNhap = txtNgayNhap.Text.ToDateTime();

            var validate = controller.ValidateAndFillup(currentHoaDonNhapModel);
            if (validate != null)
            {
                if(validate.Contains("MaNV"))
                {
                    txtMaNhanVien.Focus();
                    txtMaNhanVien.SelectAll();
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }
                if(validate.Contains("MaNCC")) {
                    txtMaNCC.Focus();
                    txtMaNCC.SelectAll();
                    MessageBox.Show("Mã nhà cung cấp không tồn tại!");
                    return;
                }
                if(validate.Contains("SoHDN")) {
                    txtMaHoaDon.Focus();
                    txtMaHoaDon.SelectAll();
                    MessageBox.Show("Mã hóa đơn đã tồn tại!");
                    return;
                }
            }
            controller.SaveHoaDonNhap(currentHoaDonNhapModel);

        }
        /// <summary>
        /// Handles the Click event of the bntLuaChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntLuaChon_Click(object sender, EventArgs e) {
            //currentModel = (HoaDonNhapModel) dataGridView.CurrentSelected(currentModelList);
            //MessageBox.Show(currentModel.MaHoaDonNhap);
        }

        /// <summary>
        /// Handles the Click event of the bntHuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bntHuy_Click(object sender, EventArgs e){
            HideForm();
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
            var selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>() where Convert.ToBoolean(row.Cells["CB"].Value) select row).ToList();

            currentModel = (ChiTietHdnModel)dataGridView.CurrentSelected(currentHoaDonNhapModel.ChiTietHDN);
            bntLuaChon.Enabled = (dataGridView.CurrentRow != null);
            if (isEditMode){
                bntLuu.Enabled = true;
                bntTaoMoi.Enabled = true;
                bntXoa.Enabled = selectedRows.Count > 0;
            } 
        }
        /// <summary>
        /// Handles the SelectionChanged event of the dataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dataGridView_SelectionChanged(object sender, System.EventArgs e) {

        }



        /// <summary>
        /// DGV_s the cell click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs" /> instance containing the event data.</param>
        private void dataGridView1_ChangedValue(Object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex < 0) {
                return;
            }
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            currentRowSelected = row;

            // from 1 no 0
            var m = dataGridView.Rows[currentRowSelected].Cells;
            if(col > 0) {
                if(dataGridView.Columns[col].Name == Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)) {
                    var id = m[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].Value.ToString();
                    if(id != "-1" && id != "") {

                        var RowIDs = (from rowx in dataGridView.Rows.Cast<DataGridViewRow>() where (rowx.Cells[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].Value.ToString() == id) select rowx).ToList();
                        if (RowIDs.Any())
                        {
                            MessageBox.Show("Mã sản phẩm đã tồn tại!");
                            m[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].Value = "-1";
                            return;
                        }

                        var noex = controller.CheckMaFromSanPham(id);
                        if (noex == null){
                            if (MyDialogs.Question("Mã sản phẩm chưa tồn tại, bạn muốn khai báo không?") == false){
                                m[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].Value = "-1";
                            }
                            else{
                                controller.ShowSanPhamViewToCreate(id);
                            }
                        }
                        else{
                            // get back đơn giá nhập!
                            dataGridView.Rows[currentRowSelected].Cells[Rf.Name<ChiTietHdnModel>(c => c.DonGia)].Value = noex.DonGiaNhap;
                        }
                    }
                }

                var a = m[Rf.Name<ChiTietHdnModel>(c => c.SoLuong)].Value.ToInt32();
                var b = m[Rf.Name<ChiTietHdnModel>(c => c.DonGia)].Value.ToDecimal();
                var d = m[Rf.Name<ChiTietHdnModel>(c => c.GiamGia)].Value.ToDecimal();
                if(d > b) {
                    m[Rf.Name<ChiTietHdnModel>(c => c.GiamGia)].Value = d;
                }
                var total = a * (b - d);
                m[Rf.Name<ChiTietHdnModel>(c => c.ThanhTien)].Value = total;
            }
            var sum = (from r in dataGridView.Rows.Cast<DataGridViewRow>() select r.Cells[Rf.Name<ChiTietHdnModel>(c => c.ThanhTien)].Value.ToDecimal()).Sum(c => c);
            txtTongTien.Text = sum.ToString(CultureInfo.InvariantCulture);
            if (currentListDataTable != null){
                for (int i = 0; i < currentListDataTable.Count; i++){
                    if (currentListDataTable.ElementAt(i).IDModel ==
                        m[Rf.Name<ChiTietHdnModel>(c => c.IDModel)].Value.ToString()){
                        currentListDataTable.ElementAt(i).DonGia =
                            m[Rf.Name<ChiTietHdnModel>(c => c.DonGia)].Value.ToDecimal();
                        currentListDataTable.ElementAt(i).GiamGia =
                            m[Rf.Name<ChiTietHdnModel>(c => c.GiamGia)].Value.ToDecimal();
                        currentListDataTable.ElementAt(i).SoLuong =
                            m[Rf.Name<ChiTietHdnModel>(c => c.SoLuong)].Value.ToInt32();
                        currentListDataTable.ElementAt(i).MaGiayDep =
                            m[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].Value.ToString();
                        currentListDataTable.ElementAt(i).ThanhTien =
                            m[Rf.Name<ChiTietHdnModel>(c => c.ThanhTien)].Value.ToDecimal();
                    }
                }
                currentHoaDonNhapModel.TongTien = txtTongTien.Text.ToDecimal();
                currentHoaDonNhapModel.ChiTietHDNModel = currentListDataTable;
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
            int index = e.RowIndex;
            currentRowSelected = index;
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
                MessageBox.Show(string.Format("Bạn có chắc chắn xóa {0} đơn hàng này không?", selectedRows.Count),
                Resources.View_Confirm,
                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                
                var s = (from row in dataGridView.Rows.Cast<DataGridViewRow>() 
                         where Convert.ToBoolean(row.Cells["CB"].Value) 
                         select row.Index).ToList();

                if(s.Count == 0) return;

                for (int k = s.Count-1; k >= 0; k--){
                    var i = s.ElementAt(k);
                    var mx = dataGridView.Rows[i].Cells;
                    for (int j = 0; j < currentListDataTable.Count; j++){
                        var m = currentListDataTable.ElementAt(j);
                        if (m.IDModel == mx[Rf.Name<ChiTietHdnModel>(c => c.IDModel)].Value){
                            currentListDataTable.RemoveAt(j);break;
                        }
                    }
                    dataSourceDataTable.Rows.RemoveAt(i);
                }

                //var dt = (DataTable) dataBindingSource.DataSource;
                //dataGridView.Rows.RemoveAt(); 
                //dataGridView.Rows.Clear();
                //controller.Delete(string.Join(",", s.ToArray()));
                //controller.ReviewGrid();
            }

            if (dataSourceDataTable.Rows.Count == 0) { 
                bntXoa.Enabled = false;
                bntLuaChon.Enabled = false;
                //bntLuu.Enabled = false;
                //bntTaoMoi.Enabled = true;
            }
        }

        /// <summary>
        /// The current row selected
        /// </summary>
        private int currentRowSelected = -1;

        /// <summary>
        /// Res the select row.
        /// </summary>
        private void ReSelectRow() {
            if(dataGridView != null) {
                if(dataGridView.Rows.Count > 0) {
                    if(currentRowSelected != -1)
                        if(currentRowSelected < dataGridView.Rows.Count)
                            dataGridView.Rows[currentRowSelected].Selected = true;
                        else {
                            currentRowSelected = 0;
                        }
                }
            }

        }

        /// <summary>
        /// The current list data table
        /// </summary>
        protected List<ChiTietHdnModel> currentListDataTable;
        /// <summary>
        /// The data binding source
        /// </summary>
        protected BindingSource dataBindingSource = new BindingSource();
        /// <summary>
        /// The data source data table
        /// </summary>
        protected DataTable dataSourceDataTable;
        /// <summary>
        /// Sets the cell san pham With SanPhamModel from outsite
        /// We need to save it to model of ChiTietHoaDon
        /// One HoaDon complete - create and pham
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetCellSanPham(SanPhamModel value) {
            if (dataGridView != null) {
                if (dataGridView.Rows.Count > 0) {
                    if (currentRowSelected != -1)
                        if (currentRowSelected < dataGridView.Rows.Count)
                            dataGridView.Rows[currentRowSelected].Selected = true;
                        else {
                            currentRowSelected = 0;
                        }

                    dataGridView.Rows[currentRowSelected].Cells[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].Value = (value == null) ? "-1" : value.MaGiayDep;
                    if (value != null) {
                        var m = dataGridView.Rows[currentRowSelected].Cells;
                        for (int i = 0; i < currentListDataTable.Count; i++) {
                            if (currentListDataTable.ElementAt(i).IDModel == m[Rf.Name<ChiTietHdnModel>(c => c.IDModel)].Value.ToString()) {
                                currentListDataTable.ElementAt(i).SanPham = value.ToEntity();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Adds the new template.
        /// </summary>
        /// <param name="table">The table.</param>
        public void AddNewTemplate(DataTable table) {
            var m = table.NewRow();
            var a = TemplateNew();
             //todo: check now
            currentListDataTable.Add(a);

            m[Rf.Name<ChiTietHdnModel>(c => c.ID)] = a.ID;
            m[Rf.Name<ChiTietHdnModel>(c => c.DonGia)] = a.DonGia;
            m[Rf.Name<ChiTietHdnModel>(c => c.GiamGia)] = a.GiamGia;
            m[Rf.Name<ChiTietHdnModel>(c => c.SoLuong)] = a.SoLuong;
            m[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)] = a.MaGiayDep;
            m[Rf.Name<ChiTietHdnModel>(c => c.ThanhTien)] = a.ThanhTien;
            m[Rf.Name<ChiTietHdnModel>(c => c.IDModel)] = a.IDModel;
            table.Rows.Add(m);
            //table.AcceptChanges();
        }

        /// <summary>
        /// Templates the new.
        /// </summary>
        /// <returns>ChiTietHdnModel.</returns>
        private ChiTietHdnModel TemplateNew(){
            return new ChiTietHdnModel{
                MaGiayDep = "-1", ID = -1, SoLuong = 0, DonGia = 0, GiamGia = 0
            };
        }

        /// <summary>
        /// Handles the Click event of the bntTaoMoi control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntTaoMoi_Click(object sender, EventArgs e) {
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = true;
            bntXoa.Enabled = true;
            bntLuaChon.Enabled = true;

            currentListDataTable = currentListDataTable ?? new List<ChiTietHdnModel>
            {
                TemplateNew()
            };


            if(dataGridView.Rows.Count == 0) {

                dataSourceDataTable = currentListDataTable.ToDataTable();
                dataSourceDataTable.AcceptChanges();
                dataBindingSource.DataSource = dataSourceDataTable;

                dataGridView.DataSource = dataBindingSource;
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.ID)].Display(false);
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.SanPhamID)].Display(false);
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.SanPham)].Display(false);
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.HoaDonNhapID)].Display(false);
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.HoaDonNhap)].Display(false);
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.SoHDN)].Display(false);
                dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.IDModel)].Display(false);

                if(dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)] != null)
                    dataGridView.Columns[Rf.Name<ChiTietHdnModel>(c => c.MaGiayDep)].DisplayIndex = 1;
            } else {
                AddNewTemplate((DataTable)dataBindingSource.DataSource);
            }
        }
        /// <summary>
        /// Sets the text ma cv.
        /// </summary>
        /// <param name="ma">The ma.</param>
        public void SetTxtMaCv(string ma) {
            //txtMaCV.Text = ma;
        }
        /// <summary>
        /// Initializes the form.
        /// </summary>
        /// <param name="value">The value.</param>
        public void InitializeForm(HoaDonNhapModel value) {
            //txtMaCV.Text = value;
        }
    }
}