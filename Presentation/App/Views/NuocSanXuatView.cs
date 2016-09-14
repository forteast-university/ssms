using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Controllers;
using App.Controllers.Interface;
using App.Extensions;
using App.Models;

namespace App.Views
{
    public partial class NuocSanXuatView : Form
    {
           /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<NuocSanXuatModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<NuocSanXuatModel> NuocSanXuatModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private NuocSanXuatModel currentModel;
        
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
        public void PostView(IEnumerable<NuocSanXuatModel> value){
            NuocSanXuatModelList = value;

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
        ///     Initializes a new instance of the <see cref="NuocSanXuatView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NuocSanXuatView(IBaseController<NuocSanXuatModel> value){
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
        }
        public NuocSanXuatView()
        {
            InitializeComponent();
        }
        private void SelectCellAction(int index, int column, bool isMmouse)
        {
            dataGridView.Rows[index].Selected = true;
            if (!isMmouse)
            {
                dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);
            }
            else
            {
                if (column == 0)
                {
                    dataGridView[0, index].Value = !Convert.ToBoolean(dataGridView.Rows[index].Cells[0].Value);
                }
            }

            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["CB"].Value)
                                                  select row).ToList();

            bntLuaChon.Enabled = (dataGridView.CurrentRow != null);
            bntXoa.Enabled = selectedRows.Count > 0;

            currentModel = (NuocSanXuatModel)dataGridView.CurrentSelected(NuocSanXuatModelList);
            if (currentModel != null)
            {
                txtMaNuocSanXuat.Text = currentModel.MaNuocSX;
                txtTenNuocSanXuat.Text = currentModel.TenNuocSX;
            }
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = true;
        }



        private void bntTaoMoi_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            txtMaNuocSanXuat.Text = "";
            txtTenNuocSanXuat.Text = "";
            txtMaNuocSanXuat.Focus();
            bntLuaChon.Enabled = false;
            bntTaoMoi.Enabled = false;
            bntLuu.Enabled = true;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {

            if (txtMaNuocSanXuat.Text == "")
            {
                MessageBox.Show("Mã nước sản xuất không được để rỗng");
                return;
            }
            if (txtTenNuocSanXuat.Text == "")
            {
                MessageBox.Show("Tên nước sản xuất không được để rỗng");
                return;
            }

            currentModel = (NuocSanXuatModel)dataGridView.CurrentSelected(NuocSanXuatModelList);
            if (currentModel != null)
            {

                var cm = NuocSanXuatModelList.Where(c => c.MaNuocSX == txtMaNuocSanXuat.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any())
                {
                    MessageBox.Show("Mã nước sản xuất đã tồn tại trong một bản ghi khác");
                    return;
                }
                var ct = NuocSanXuatModelList.Where(c => c.TenNuocSX == txtTenNuocSanXuat.Text &&
                    c.ID != currentModel.ID);
                if (ct.Any())
                {
                    MessageBox.Show("Tên nước sản xuất đã tồn tại trong một bản ghi khác");
                    return;
                }

                currentModel.MaNuocSX = txtMaNuocSanXuat.Text;
                currentModel.TenNuocSX = txtTenNuocSanXuat.Text;
                controller.Update(currentModel);
                //re-update UI

                dataGridView.UpdateView("MaNuocSX", currentModel.MaNuocSX);
                dataGridView.UpdateView("TenNuocSX", currentModel.TenNuocSX);

                txtMaNuocSanXuat.Focus();
                txtMaNuocSanXuat.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else
            {
                var cm = NuocSanXuatModelList.Where(c => c.MaNuocSX == txtMaNuocSanXuat.Text);
                if (cm.Any())
                {
                    MessageBox.Show("Mã nước sản xuất đã tồn tại");
                    return;
                }
                var ct = NuocSanXuatModelList.Where(c => c.TenNuocSX == txtTenNuocSanXuat.Text);
                if (ct.Any())
                {
                    MessageBox.Show("Tên nước sản xuất đã tồn tại");
                    return;
                }
                currentModel = new NuocSanXuatModel
                {
                    MaNuocSX = txtMaNuocSanXuat.Text,
                    TenNuocSX = txtTenNuocSanXuat.Text,
                };

                controller.Insert(currentModel);
                txtMaNuocSanXuat.Focus();
                txtMaNuocSanXuat.SelectAll();
                //txtTenNuocSanXuat.Text = "";
                controller.ReviewGrid();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dataGridView.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["CB"].Value)
                                                  select row).ToList();
            if (
                MessageBox.Show(string.Format("Bạn có muốn xóa {0} dòng?", selectedRows.Count),
                "Thông báo",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
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

        private void bntLuaChon_Click(object sender, EventArgs e)
        {

            currentModel = (NuocSanXuatModel)dataGridView.CurrentSelected(NuocSanXuatModelList);
            controller.Select(currentModel);
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            int index = e.RowIndex;

            SelectCellAction(e.RowIndex, e.ColumnIndex, true);
        }

        private void dataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
                return;
            if (dataGridView.CurrentRow == null)
                return;
            int index = dataGridView.CurrentRow.Index;
            SelectCellAction(index, 0, false);
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
    }
}
