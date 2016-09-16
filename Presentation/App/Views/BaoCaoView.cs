// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-11-2016
// ***********************************************************************
// <copyright file="BaoCaoView.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Extensions;
using App.Models;

namespace App.Views {
    /// <summary>
    ///     Class BaoCaoView.
    /// </summary>
    public partial class BaoCaoView: Form {

        private readonly IBaoCaoController<BaoCaoModel> controller;
        private IEnumerable<BaoCaoModel> currentModelList;
        private BaoCaoModel currentModel;
        private DataTable currentDrop;

        public BaoCaoView(IBaoCaoController<BaoCaoModel> value) {
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
            var a = new List<DropdownList>
            {
                new DropdownList{ID=0, Value = "..Lựa chọn báo cáo..."},
                new DropdownList{ID=1, Value = "Sản phẩm tồn kho"},
                new DropdownList{ID=2, Value = "Tổng tiền nhập hàng theo quý"},
                new DropdownList{ID=3, Value = "Tổng tiền bán hàng của một nhân viên"},
                new DropdownList{ID=4, Value = "Tổng tiền 3 khách hàng mua nhiều nhất"}
            };
            currentModel = new BaoCaoModel();
            var b = new BindingSource();
            b.DataSource = a;
            cbbBaoCao.DataSource = b;
            cbbBaoCao.DisplayMember = "Value";
            cbbBaoCao.ValueMember = "ID";
            cbbBaoCao.SelectedValueChanged += new System.EventHandler(comboBox1_SelectedValueChanged);

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            txtNam.Visible = false;
            txtQuy.Visible = false;
            txtMaNhanVien.Visible = false;
            txtNam.Text = "2016";

        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) {
            if (cbbBaoCao.SelectedValue != null)
            {
                label1.Visible = false;
                label2.Visible = false;
                txtQuy.Visible = false;
                label3.Visible = false;
                txtNam.Visible = false;
                txtMaNhanVien.Visible = false;
                var current = cbbBaoCao.SelectedValue.ToInt32();
                
                if (current == 1)
                {
                } 
                else if(current ==2 ) {
                    label1.Visible = true;
                    txtQuy.Visible = true;
                   
                    label3.Visible = true;
                    txtNam.Visible = true;
                    txtQuy.SelectedIndex = 0;
                    loadDataQuy(cbbBaoCao.SelectedValue.ToInt32());

                } else if(current == 3) {
                    label2.Visible = true;
                    txtMaNhanVien.Visible = true;
                } else if(current == 4) {
                    
                }
                
            }
        }
        public void View() {
            ShowDialog();
        }
        public void PostView(IEnumerable<BaoCaoModel> value) {
            currentModelList = value;

            dataGridView.Columns.Clear();
            dataGridView.DataSource = new BindingSource { DataSource = value };
            dataGridView.Columns["ID"].Display(false);
            dataGridView.Columns["KhachHangID"].Display(false);
            dataGridView.Columns["KhachHang"].Display(false);
            dataGridView.Columns["NhanVienID"].Display(false);
            dataGridView.Columns["NhanVien"].Display(false);
            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;
        }
        private void bntLuaChon_Click(object sender, EventArgs e) {
        }
        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if(e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
                return;
            if(dataGridView.CurrentRow == null)
                return;
            int index = dataGridView.CurrentRow.Index;
            SelectCellAction(index, 0, false);
        }
        private void SelectCellAction(int index, int column, bool isMmouse) {
            dataGridView.Rows[index].Selected = true;
        }
        private void dgv_CellClick(Object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex < 0) {
                return;
            }
            int index = e.RowIndex;

            SelectCellAction(e.RowIndex, e.ColumnIndex, true);
        }
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
        private void bntXoa_Click(object sender, EventArgs e) {
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            //currentModel = (BaoCaoModel)dataGridView.CurrentSelected(currentModelList);
            //controller.ShowBaoCaoView(currentModel);
        }
        private void SanPhanListView_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            if(cbbBaoCao.SelectedValue != null) {
                var current = cbbBaoCao.SelectedValue.ToInt32();
                dataGridView.Columns.Clear();

               


                if(current == 1) {
                    // todo: Sản phẩm tồn kho
                    currentModel = controller.GetData(current, currentModel);
                    dataGridView.DataSource = new BindingSource { DataSource = currentModel.Sanpham };
                    
                    dataGridView.Columns["ID"].Display(false);
                    dataGridView.Columns["TheLoaiID"].Display(false);
                    dataGridView.Columns["KichCoID"].Display(false);
                    dataGridView.Columns["ChatLieuID"].Display(false);
                    dataGridView.Columns["MauID"].Display(false);
                    dataGridView.Columns["DoiTuongID"].Display(false);
                    dataGridView.Columns["MuaID"].Display(false);
                    dataGridView.Columns["NuocSanXuatID"].Display(false);

                    dataGridView.Columns["TheLoai"].Display(false);
                    dataGridView.Columns["KichCo"].Display(false);
                    dataGridView.Columns["ChatLieu"].Display(false);
                    dataGridView.Columns["Mau"].Display(false);
                    dataGridView.Columns["DoiTuong"].Display(false);
                    dataGridView.Columns["Mua"].Display(false);
                    dataGridView.Columns["NuocSanXuat"].Display(false);

                } else if(current == 2) {
                    // todo: Tổng tiền nhập hàng theo quý
                    loadDataQuy(current);
                } else if(current == 3) {
                    // todo: Tổng tiền bán hàng của một nhân viên
                    currentModel.MaNhanVien = txtMaNhanVien.Text;
                    currentModel = controller.GetData(current, currentModel);
                    //------
                    dataGridView.DataSource = new BindingSource { DataSource = currentModel.Hoadonban };
                    dataGridView.Columns["ID"].Display(false);
                    dataGridView.Columns["KhachHangID"].Display(false);
                    dataGridView.Columns["KhachHang"].Display(false);
                    dataGridView.Columns["NhanVienID"].Display(false);
                    dataGridView.Columns["NhanVien"].Display(false);
                } else if(current == 4) {
                    // todo: Tổng tiền 3 khách hàng mua nhiều nhất
                    currentModel.TopBuy = 3;
                    currentModel = controller.GetData(current, currentModel);

                    //------
                    dataGridView.DataSource = new BindingSource { DataSource = currentModel.Hoadonban };
                    dataGridView.Columns["ID"].Display(false);
                    dataGridView.Columns["KhachHangID"].Display(false);
                    dataGridView.Columns["KhachHang"].Display(false);
                    dataGridView.Columns["NhanVienID"].Display(false);
                    dataGridView.Columns["NhanVien"].Display(false);
                    dataGridView.Columns["MaNV"].Display(false);
                    dataGridView.Columns["SoHDB"].Display(false);

                    if(dataGridView.Columns["MaKhach"] != null)
                        dataGridView.Columns["MaKhach"].DisplayIndex = 0;
                    if(dataGridView.Columns["TongTien"] != null)
                        dataGridView.Columns["TongTien"].DisplayIndex = 1;
                } else {
                    // todo: clear
                }
                dataGridView.ClearSelection();
                dataGridView.CurrentCell = null;

            }
        }

        public void loadDataQuy(Int32 current)
        {
            var y = txtNam.Text;
            var q = txtQuy.SelectedItem.ToString().ToQuy(y);
           
            currentModel.startTime = q.StartTime;
            currentModel.endTime = q.EndTime;
            currentModel = controller.GetData(current, currentModel);
            //-------------------------------
            dataGridView.DataSource = new BindingSource { DataSource = currentModel.Hoadonnhap };
            dataGridView.Columns["ID"].Display(false);
            dataGridView.Columns["NhaCungCapID"].Display(false);
            dataGridView.Columns["NhaCungCap"].Display(false);
            dataGridView.Columns["NhanVienID"].Display(false);
            dataGridView.Columns["NhanVien"].Display(false);
        }
    }
}