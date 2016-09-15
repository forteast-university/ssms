using System.Windows.Forms;

namespace App.Views
{
    partial class NuocSanXuatView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuocSanXuatView));
            this.bntTaoMoi = new System.Windows.Forms.Button();
            this.bntXoa = new System.Windows.Forms.Button();
            this.bntLuaChon = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNuocSanXuat = new System.Windows.Forms.TextBox();
            this.txtMaNuocSanXuat = new System.Windows.Forms.TextBox();
            this.bntHuy = new System.Windows.Forms.Button();
            this.bntLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bntTaoMoi
            // 
            this.bntTaoMoi.Location = new System.Drawing.Point(284, 7);
            this.bntTaoMoi.Name = "bntTaoMoi";
            this.bntTaoMoi.Size = new System.Drawing.Size(75, 23);
            this.bntTaoMoi.TabIndex = 39;
            this.bntTaoMoi.Text = "Tạo mới";
            this.bntTaoMoi.UseVisualStyleBackColor = true;
            this.bntTaoMoi.Click += new System.EventHandler(this.bntTaoMoi_Click);
            // 
            // bntXoa
            // 
            this.bntXoa.Location = new System.Drawing.Point(13, 394);
            this.bntXoa.Name = "bntXoa";
            this.bntXoa.Size = new System.Drawing.Size(75, 23);
            this.bntXoa.TabIndex = 38;
            this.bntXoa.Text = "Xóa";
            this.bntXoa.UseVisualStyleBackColor = true;
            this.bntXoa.Click += new System.EventHandler(this.bntXoa_Click);
            // 
            // bntLuaChon
            // 
            this.bntLuaChon.Location = new System.Drawing.Point(94, 394);
            this.bntLuaChon.Name = "bntLuaChon";
            this.bntLuaChon.Size = new System.Drawing.Size(75, 23);
            this.bntLuaChon.TabIndex = 37;
            this.bntLuaChon.Text = "Lựa chọn";
            this.bntLuaChon.UseVisualStyleBackColor = true;
            this.bntLuaChon.Click += new System.EventHandler(this.bntLuaChon_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 67);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(347, 321);
            this.dataGridView.TabIndex = 36;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            this.dataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dataGridView_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Tên nước";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Mã nước";
            // 
            // txtTenNuocSanXuat
            // 
            this.txtTenNuocSanXuat.Location = new System.Drawing.Point(88, 38);
            this.txtTenNuocSanXuat.Name = "txtTenNuocSanXuat";
            this.txtTenNuocSanXuat.Size = new System.Drawing.Size(180, 20);
            this.txtTenNuocSanXuat.TabIndex = 33;
            // 
            // txtMaNuocSanXuat
            // 
            this.txtMaNuocSanXuat.Location = new System.Drawing.Point(88, 11);
            this.txtMaNuocSanXuat.Name = "txtMaNuocSanXuat";
            this.txtMaNuocSanXuat.Size = new System.Drawing.Size(180, 20);
            this.txtMaNuocSanXuat.TabIndex = 32;
            // 
            // bntHuy
            // 
            this.bntHuy.Location = new System.Drawing.Point(284, 394);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(75, 23);
            this.bntHuy.TabIndex = 31;
            this.bntHuy.Text = "Hủy bỏ";
            this.bntHuy.UseVisualStyleBackColor = true;
            this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
            // 
            // bntLuu
            // 
            this.bntLuu.Location = new System.Drawing.Point(284, 36);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(75, 23);
            this.bntLuu.TabIndex = 30;
            this.bntLuu.Text = "Lưu";
            this.bntLuu.UseVisualStyleBackColor = true;
            this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
            // 
            // NuocSanXuatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 423);
            this.Controls.Add(this.bntTaoMoi);
            this.Controls.Add(this.bntXoa);
            this.Controls.Add(this.bntLuaChon);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenNuocSanXuat);
            this.Controls.Add(this.txtMaNuocSanXuat);
            this.Controls.Add(this.bntHuy);
            this.Controls.Add(this.bntLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(typeof(AppMediator)).GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuocSanXuatView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nước Sản Xuất";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntTaoMoi;
        private System.Windows.Forms.Button bntXoa;
        private System.Windows.Forms.Button bntLuaChon;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNuocSanXuat;
        private System.Windows.Forms.TextBox txtMaNuocSanXuat;
        private System.Windows.Forms.Button bntHuy;
        private System.Windows.Forms.Button bntLuu;
    }
}