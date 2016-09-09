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
    public partial class DoiTuongView : Form
    {
        /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<DoiTuongModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<DoiTuongModel> DoiTuongModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private DoiTuongModel currentModel;

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void View()
        {
            ShowDialog();
        }

        /// <summary>
        ///     Posts the view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void PostView(IEnumerable<DoiTuongModel> value)
        {
            DoiTuongModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn { Name = "CB", HeaderText = "", Width = 24, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = true };
            dataGridView.Columns.Add(c);

            dataGridView.DataSource = new BindingSource { DataSource = value };
            DataGridViewColumn dataGridViewColumn = dataGridView.Columns["ID"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;

            dataGridView.ClearSelection();
            dataGridView.CurrentCell = null;
            bntLuu.Enabled = false;
            bntTaoMoi.Enabled = true;
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="DoiTuongView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DoiTuongView(IBaseController<DoiTuongModel> value)
        {
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
        }
        public DoiTuongView()
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

            currentModel = (DoiTuongModel)dataGridView.CurrentSelected(DoiTuongModelList);
            if (currentModel != null)
            {
                txtMaDoiTuong.Text = currentModel.MaDoiTuong;
                txtTenDoiTuong.Text = currentModel.TenDoiTuong;
            }
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = true;
        }






        private void bntTaoMoi_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            txtMaDoiTuong.Text = "";
            txtTenDoiTuong.Text = "";
            txtMaDoiTuong.Focus();
            bntLuaChon.Enabled = false;
            bntTaoMoi.Enabled = false;
            bntLuu.Enabled = true;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {

            if (txtMaDoiTuong.Text == "")
            {
                MessageBox.Show("Mã đối tượng không được để rỗng");
                return;
            }
            if (txtTenDoiTuong.Text == "")
            {
                MessageBox.Show("Tên đối tượng không được để rỗng");
                return;
            }

            currentModel = (DoiTuongModel)dataGridView.CurrentSelected(DoiTuongModelList);
            if (currentModel != null)
            {

                var cm = DoiTuongModelList.Where(c => c.MaDoiTuong == txtMaDoiTuong.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any())
                {
                    MessageBox.Show("Mã đối tượng đã tồn tại trong một bản ghi khác");
                    return;
                }
                var ct = DoiTuongModelList.Where(c => c.TenDoiTuong == txtTenDoiTuong.Text &&
                    c.ID != currentModel.ID);
                if (ct.Any())
                {
                    MessageBox.Show("Tên đối tượng đã tồn tại trong một bản ghi khác");
                    return;
                }

                currentModel.MaDoiTuong = txtMaDoiTuong.Text;
                currentModel.TenDoiTuong = txtTenDoiTuong.Text;
                controller.Update(currentModel);
                //re-update UI

                dataGridView.UpdateView("MaDoiTuong", currentModel.MaDoiTuong);
                dataGridView.UpdateView("TenDoiTuong", currentModel.TenDoiTuong);

                txtMaDoiTuong.Focus();
                txtMaDoiTuong.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else
            {
                var cm = DoiTuongModelList.Where(c => c.MaDoiTuong == txtMaDoiTuong.Text);
                if (cm.Any())
                {
                    MessageBox.Show("Mã đối tượng đã tồn tại");
                    return;
                }
                var ct = DoiTuongModelList.Where(c => c.TenDoiTuong == txtTenDoiTuong.Text);
                if (ct.Any())
                {
                    MessageBox.Show("Tên đối tượng đã tồn tại");
                    return;
                }
                currentModel = new DoiTuongModel
                {
                    MaDoiTuong = txtMaDoiTuong.Text,
                    TenDoiTuong = txtTenDoiTuong.Text,
                };

                controller.Insert(currentModel);
                txtMaDoiTuong.Focus();
                txtMaDoiTuong.SelectAll();
                //txtTenDoiTuong.Text = "";
                controller.ReviewGrid();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void bntLuaChon_Click(object sender, EventArgs e)
        {
            currentModel = (DoiTuongModel)dataGridView.CurrentSelected(DoiTuongModelList);
            MessageBox.Show(currentModel.MaDoiTuong);
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
