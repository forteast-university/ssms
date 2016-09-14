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
            var b = new BindingSource();
            b.DataSource = a;
            cbbBaoCao.DataSource = b;
            cbbBaoCao.DisplayMember = "Value";
            cbbBaoCao.ValueMember = "ID";
            cbbBaoCao.SelectedValueChanged += new System.EventHandler(comboBox1_SelectedValueChanged);

        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) {
            if(cbbBaoCao.SelectedValue != null) {
                var current = cbbBaoCao.SelectedValue.ToInt32();
                if(current == 1) {
                    // todo: Sản phẩm tồn kho
                } else if(current == 2) {
                    // todo: Tổng tiền nhập hàng theo quý
                } else if(current == 3) {
                    // todo: Tổng tiền bán hàng của một nhân viên
                } else if(current == 4) {
                    // todo: Tổng tiền 3 khách hàng mua nhiều nhất
                } else {
                    // todo: clear
                }
            }
        }
        public void View() {
            ShowDialog();
        }
        public void PostView(IEnumerable<BaoCaoModel> value) {
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn {
                Name = "CB",
                HeaderText = "",
                Width = 24,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true
            };
            dataGridView.Columns.Add(c);
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

            //currentModel = (BaoCaoModel)dataGridView.CurrentSelected(currentModelList);
            //if(currentModel != null) {
            //    txtTimKiem.Text = currentModel.MaGiayDep;
            //}
            // bntTimKiem.Enabled = true;
            // bntTaoMoi.Enabled = true;
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
        private void bntTimKiem_Click(object sender, EventArgs e) {

        }
        private void SanPhanListView_Load(object sender, EventArgs e) {

        }
    }
}