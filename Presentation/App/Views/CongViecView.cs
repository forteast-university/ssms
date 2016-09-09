using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Extensions;
using App.Models;

namespace App.Views
{
    public partial class CongViecView : Form
    {
         /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<CongViecModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<CongViecModel> CongViecModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private CongViecModel currentModel;
        
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
        public void PostView(IEnumerable<CongViecModel> value){
            CongViecModelList = value;

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
        ///     Initializes a new instance of the <see cref="CongViecView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public CongViecView(IBaseController<CongViecModel> value){
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
        }
        public CongViecView()
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

            currentModel = (CongViecModel)dataGridView.CurrentSelected(CongViecModelList);
            if (currentModel != null)
            {
                txtMaCongViec.Text = currentModel.MaCV;
                txtCongViec.Text = currentModel.TenCV;
            }
            bntLuu.Enabled = true;
            bntTaoMoi.Enabled = true;
        }



        private void bntTaoMoi_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            txtMaCongViec.Text = "";
            txtCongViec.Text = "";
            txtMaCongViec.Focus();
            bntLuaChon.Enabled = false;
            bntTaoMoi.Enabled = false;
            bntLuu.Enabled = true;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {

            if (txtMaCongViec.Text == "")
            {
                MessageBox.Show("Mã công việc không được để rỗng");
                return;
            }
            if (txtCongViec.Text == "")
            {
                MessageBox.Show("Tên công việc không được để rỗng");
                return;
            }

            currentModel = (CongViecModel)dataGridView.CurrentSelected(CongViecModelList);
            if (currentModel != null)
            {

                var cm = CongViecModelList.Where(c => c.MaCV == txtMaCongViec.Text &&
                    c.ID != currentModel.ID);
                if (cm.Any())
                {
                    MessageBox.Show("Mã công việc đã tồn tại trong một bản ghi khác");
                    return;
                }
                var ct = CongViecModelList.Where(c => c.TenCV == txtCongViec.Text &&
                    c.ID != currentModel.ID);
                if (ct.Any())
                {
                    MessageBox.Show("Tên công việc đã tồn tại trong một bản ghi khác");
                    return;
                }

                currentModel.MaCV = txtMaCongViec.Text;
                currentModel.TenCV = txtCongViec.Text;
                controller.Update(currentModel);
                //re-update UI

                dataGridView.UpdateView("MaCongViec", currentModel.MaCV);
                dataGridView.UpdateView("TenCongViec", currentModel.TenCV);

                txtMaCongViec.Focus();
                txtMaCongViec.SelectAll();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
            else
            {
                var cm = CongViecModelList.Where(c => c.MaCV == txtMaCongViec.Text);
                if (cm.Any())
                {
                    MessageBox.Show("Mã công việc đã tồn tại");
                    return;
                }
                var ct = CongViecModelList.Where(c => c.TenCV == txtCongViec.Text);
                if (ct.Any())
                {
                    MessageBox.Show("Tên công việc đã tồn tại");
                    return;
                }
                currentModel = new CongViecModel
                {
                    MaCV = txtMaCongViec.Text,
                    TenCV = txtCongViec.Text,
                };

                controller.Insert(currentModel);
                txtMaCongViec.Focus();
                txtMaCongViec.SelectAll();
                //txtTenCongViec.Text = "";
                controller.ReviewGrid();
                bntTaoMoi.Enabled = true;
                bntLuu.Enabled = true;
            }
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
        /// <summary>
        ///     Selects the cell action.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="column"></param>
        /// <param name="isMmouse"></param>
   
        private void bntLuaChon_Click(object sender, EventArgs e)
        {
            currentModel = (CongViecModel)dataGridView.CurrentSelected(CongViecModelList);
            MessageBox.Show(currentModel.MaCV);
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

        private void bntHuy_Click(object sender, EventArgs e)
        {
            Hide();
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
