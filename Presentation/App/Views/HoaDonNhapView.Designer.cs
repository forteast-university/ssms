using System.Windows.Forms;

namespace App.Views {
    partial class HoaDonNhapView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.bntLuu = new System.Windows.Forms.Button();
            this.bntHuy = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bntLuaChon = new System.Windows.Forms.Button();
            this.bntXoa = new System.Windows.Forms.Button();
            this.bntTaoMoi = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bntLuu
            // 
            this.bntLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntLuu.Location = new System.Drawing.Point(427, 403);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(75, 23);
            this.bntLuu.TabIndex = 10;
            this.bntLuu.Text = "Lưu";
            this.bntLuu.UseVisualStyleBackColor = true;
            this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
            // 
            // bntHuy
            // 
            this.bntHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntHuy.Location = new System.Drawing.Point(427, 432);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(75, 23);
            this.bntHuy.TabIndex = 15;
            this.bntHuy.Text = "Hủy bỏ";
            this.bntHuy.UseVisualStyleBackColor = true;
            this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 118);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(489, 282);
            this.dataGridView.TabIndex = 12;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_ChangedValue);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            this.dataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dataGridView1_PreviewKeyDown);
            // 
            // bntLuaChon
            // 
            this.bntLuaChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntLuaChon.Location = new System.Drawing.Point(94, 432);
            this.bntLuaChon.Name = "bntLuaChon";
            this.bntLuaChon.Size = new System.Drawing.Size(75, 23);
            this.bntLuaChon.TabIndex = 14;
            this.bntLuaChon.Text = "Lựa chọn";
            this.bntLuaChon.UseVisualStyleBackColor = true;
            this.bntLuaChon.Click += new System.EventHandler(this.bntLuaChon_Click);
            // 
            // bntXoa
            // 
            this.bntXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntXoa.Location = new System.Drawing.Point(13, 432);
            this.bntXoa.Name = "bntXoa";
            this.bntXoa.Size = new System.Drawing.Size(75, 23);
            this.bntXoa.TabIndex = 13;
            this.bntXoa.Text = "Xóa";
            this.bntXoa.UseVisualStyleBackColor = true;
            this.bntXoa.Click += new System.EventHandler(this.bntXoa_Click);
            // 
            // bntTaoMoi
            // 
            this.bntTaoMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntTaoMoi.Location = new System.Drawing.Point(404, 89);
            this.bntTaoMoi.Name = "bntTaoMoi";
            this.bntTaoMoi.Size = new System.Drawing.Size(98, 23);
            this.bntTaoMoi.TabIndex = 11;
            this.bntTaoMoi.Text = "Thêm sản phẩm";
            this.bntTaoMoi.UseVisualStyleBackColor = true;
            this.bntTaoMoi.Click += new System.EventHandler(this.bntTaoMoi_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTongTien.Location = new System.Drawing.Point(94, 406);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(264, 20);
            this.txtTongTien.TabIndex = 5;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(94, 38);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(264, 20);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tổng tiền";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ngày nhập";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Mã nhân viên";
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Location = new System.Drawing.Point(94, 90);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.Size = new System.Drawing.Size(130, 20);
            this.txtNgayNhap.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Mã NCC";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(94, 64);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(264, 20);
            this.txtMaNCC.TabIndex = 6;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(94, 12);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(264, 20);
            this.txtMaHoaDon.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mã hóa đơn";
            // 
            // HoaDonNhapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 467);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.txtNgayNhap);
            this.Controls.Add(this.txtMaNCC);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bntTaoMoi);
            this.Controls.Add(this.bntXoa);
            this.Controls.Add(this.bntLuaChon);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.bntHuy);
            this.Controls.Add(this.bntLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "HoaDonNhapView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn nhập";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Button bntLuu;
        private System.Windows.Forms.Button bntHuy;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button bntLuaChon;
        private Button bntXoa;
        private Button bntTaoMoi;
        private TextBox txtTongTien;
        private TextBox txtMaNhanVien;
        private Label label5;
        private Label label9;
        private Label label12;
        private DateTimePicker txtNgayNhap;
        private Label label6;
        private TextBox txtMaNCC;
        private TextBox txtMaHoaDon;
        private Label label1;
    }
}