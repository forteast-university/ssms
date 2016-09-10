using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers;
using App.Controllers.Interface;
using App.Extensions;
using App.Models;
using App.Properties;

namespace App.Views
{
    /// <summary>
    ///     Class NhanVienView.
    /// </summary>
    public partial class NhanVienView : Form
    {
        /// <summary>
        ///     The controller
        /// </summary>
        private readonly IBaseController<NhanVienModel> controller;

        /// <summary>
        ///     The value chat lieu model
        /// </summary>
        private IEnumerable<NhanVienModel> currentModelList;

        /// <summary>
        ///     The current model
        /// </summary>
        private NhanVienModel currentModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NhanVienView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NhanVienView(IBaseController<NhanVienModel> value)
        {
            controller = value;
            InitializeComponent();
            bntLuaChon.Enabled = false;
            bntXoa.Enabled = false;
        }

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
        public void PostView(IEnumerable<NhanVienModel> value)
        {
            currentModelList = value;

            dataGridView.Columns.Clear();
            var c = new DataGridViewCheckBoxColumn { Name = "CB", HeaderText = "", Width = 24, ReadOnly = true };
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

        private void bntTaoMoi_Click(object sender, EventArgs e)
        {

        }
    }
}