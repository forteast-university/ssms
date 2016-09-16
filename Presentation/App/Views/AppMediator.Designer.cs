namespace App.Views {
    partial class AppMediator {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMediator));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHuongDan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtCauHinh = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bntKhachHang = new System.Windows.Forms.Button();
            this.bntNhaCungCap = new System.Windows.Forms.Button();
            this.bntNhanVien = new System.Windows.Forms.Button();
            this.bntCongViec = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bntMua = new System.Windows.Forms.Button();
            this.bntKichCo = new System.Windows.Forms.Button();
            this.bntTheLoai = new System.Windows.Forms.Button();
            this.bntNuocSanXuat = new System.Windows.Forms.Button();
            this.bntDoiTuong = new System.Windows.Forms.Button();
            this.bntMau = new System.Windows.Forms.Button();
            this.bntChatLieu = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabHoaDonBan = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabHoaDonNhap = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabSanPham = new System.Windows.Forms.TabPage();
            this.panel = new System.Windows.Forms.Panel();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.txtCauHinh.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabHoaDonBan.SuspendLayout();
            this.tabHoaDonNhap.SuspendLayout();
            this.tabSanPham.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hướngDẫnToolStripMenuItem,
            this.txtUserInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmImportExcel,
            this.tsmExportExcel,
            this.toolStripSeparator3,
            this.tsmBackup,
            this.tsmRestore,
            this.toolStripSeparator1,
            this.tsmTaiKhoan,
            this.toolStripSeparator2,
            this.tsmThoat});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmImportExcel
            // 
            this.tsmImportExcel.Enabled = false;
            this.tsmImportExcel.Name = "tsmImportExcel";
            this.tsmImportExcel.Size = new System.Drawing.Size(188, 22);
            this.tsmImportExcel.Text = "Nhập từ Excel";
            this.tsmImportExcel.Click += new System.EventHandler(this.tsmImportExcel_Click);
            // 
            // tsmExportExcel
            // 
            this.tsmExportExcel.Enabled = false;
            this.tsmExportExcel.Name = "tsmExportExcel";
            this.tsmExportExcel.Size = new System.Drawing.Size(188, 22);
            this.tsmExportExcel.Text = "Xuất ra Excel";
            this.tsmExportExcel.Click += new System.EventHandler(this.tsmExportExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // tsmBackup
            // 
            this.tsmBackup.Enabled = false;
            this.tsmBackup.Name = "tsmBackup";
            this.tsmBackup.Size = new System.Drawing.Size(188, 22);
            this.tsmBackup.Text = "Sao lưu cơ sở dữ liệu";
            this.tsmBackup.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // tsmRestore
            // 
            this.tsmRestore.Enabled = false;
            this.tsmRestore.Name = "tsmRestore";
            this.tsmRestore.Size = new System.Drawing.Size(188, 22);
            this.tsmRestore.Text = "Khởi tạo cơ sở dữ liệu";
            this.tsmRestore.Click += new System.EventHandler(this.tsmRestore_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // tsmTaiKhoan
            // 
            this.tsmTaiKhoan.Enabled = false;
            this.tsmTaiKhoan.Name = "tsmTaiKhoan";
            this.tsmTaiKhoan.Size = new System.Drawing.Size(188, 22);
            this.tsmTaiKhoan.Text = "Tài khoản của tôi";
            this.tsmTaiKhoan.Click += new System.EventHandler(this.tsmTaiKhoan_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // tsmThoat
            // 
            this.tsmThoat.Name = "tsmThoat";
            this.tsmThoat.Size = new System.Drawing.Size(188, 22);
            this.tsmThoat.Text = "Thoát";
            this.tsmThoat.Click += new System.EventHandler(this.tsmThoat_Click);
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHuongDan,
            this.tsmAbout});
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.hướngDẫnToolStripMenuItem.Text = "Trợ giúp";
            // 
            // tsmHuongDan
            // 
            this.tsmHuongDan.Name = "tsmHuongDan";
            this.tsmHuongDan.Size = new System.Drawing.Size(181, 22);
            this.tsmHuongDan.Text = "Hướng dẫn";
            this.tsmHuongDan.Click += new System.EventHandler(this.tsmHuongDan_Click);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(181, 22);
            this.tsmAbout.Text = "Thông tin sản phẩm";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.Size = new System.Drawing.Size(34, 20);
            this.txtUserInfo.Text = ".....";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // txtCauHinh
            // 
            this.txtCauHinh.Controls.Add(this.groupBox2);
            this.txtCauHinh.Controls.Add(this.groupBox1);
            this.txtCauHinh.Location = new System.Drawing.Point(4, 22);
            this.txtCauHinh.Margin = new System.Windows.Forms.Padding(0);
            this.txtCauHinh.Name = "txtCauHinh";
            this.txtCauHinh.Size = new System.Drawing.Size(709, 396);
            this.txtCauHinh.TabIndex = 2;
            this.txtCauHinh.Text = "Cấu hình";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bntKhachHang);
            this.groupBox2.Controls.Add(this.bntNhaCungCap);
            this.groupBox2.Controls.Add(this.bntNhanVien);
            this.groupBox2.Controls.Add(this.bntCongViec);
            this.groupBox2.Location = new System.Drawing.Point(205, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 232);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhóm thông tin phụ";
            // 
            // bntKhachHang
            // 
            this.bntKhachHang.Location = new System.Drawing.Point(107, 48);
            this.bntKhachHang.Name = "bntKhachHang";
            this.bntKhachHang.Size = new System.Drawing.Size(94, 23);
            this.bntKhachHang.TabIndex = 3;
            this.bntKhachHang.Text = "Khách hàng";
            this.bntKhachHang.UseVisualStyleBackColor = true;
            this.bntKhachHang.Click += new System.EventHandler(this.bntKhachHang_Click);
            // 
            // bntNhaCungCap
            // 
            this.bntNhaCungCap.Location = new System.Drawing.Point(107, 19);
            this.bntNhaCungCap.Name = "bntNhaCungCap";
            this.bntNhaCungCap.Size = new System.Drawing.Size(94, 23);
            this.bntNhaCungCap.TabIndex = 2;
            this.bntNhaCungCap.Text = "Nhà cung cấp";
            this.bntNhaCungCap.UseVisualStyleBackColor = true;
            this.bntNhaCungCap.Click += new System.EventHandler(this.bntNhaCungCap_Click);
            // 
            // bntNhanVien
            // 
            this.bntNhanVien.Location = new System.Drawing.Point(7, 47);
            this.bntNhanVien.Name = "bntNhanVien";
            this.bntNhanVien.Size = new System.Drawing.Size(94, 23);
            this.bntNhanVien.TabIndex = 1;
            this.bntNhanVien.Text = "Nhân viên";
            this.bntNhanVien.UseVisualStyleBackColor = true;
            this.bntNhanVien.Click += new System.EventHandler(this.bntNhanVien_Click);
            // 
            // bntCongViec
            // 
            this.bntCongViec.Location = new System.Drawing.Point(7, 19);
            this.bntCongViec.Name = "bntCongViec";
            this.bntCongViec.Size = new System.Drawing.Size(94, 23);
            this.bntCongViec.TabIndex = 0;
            this.bntCongViec.Text = "Công việc";
            this.bntCongViec.UseVisualStyleBackColor = true;
            this.bntCongViec.Click += new System.EventHandler(this.bntCongViec_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntMua);
            this.groupBox1.Controls.Add(this.bntKichCo);
            this.groupBox1.Controls.Add(this.bntTheLoai);
            this.groupBox1.Controls.Add(this.bntNuocSanXuat);
            this.groupBox1.Controls.Add(this.bntDoiTuong);
            this.groupBox1.Controls.Add(this.bntMau);
            this.groupBox1.Controls.Add(this.bntChatLieu);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhóm Sản phẩm";
            // 
            // bntMua
            // 
            this.bntMua.Location = new System.Drawing.Point(6, 198);
            this.bntMua.Name = "bntMua";
            this.bntMua.Size = new System.Drawing.Size(94, 23);
            this.bntMua.TabIndex = 6;
            this.bntMua.Text = "Mùa";
            this.bntMua.UseVisualStyleBackColor = true;
            this.bntMua.Click += new System.EventHandler(this.bntMua_Click);
            // 
            // bntKichCo
            // 
            this.bntKichCo.Location = new System.Drawing.Point(6, 168);
            this.bntKichCo.Name = "bntKichCo";
            this.bntKichCo.Size = new System.Drawing.Size(94, 23);
            this.bntKichCo.TabIndex = 5;
            this.bntKichCo.Text = "Kích cỡ";
            this.bntKichCo.UseVisualStyleBackColor = true;
            this.bntKichCo.Click += new System.EventHandler(this.bntKichCo_Click);
            // 
            // bntTheLoai
            // 
            this.bntTheLoai.Location = new System.Drawing.Point(6, 138);
            this.bntTheLoai.Name = "bntTheLoai";
            this.bntTheLoai.Size = new System.Drawing.Size(94, 23);
            this.bntTheLoai.TabIndex = 4;
            this.bntTheLoai.Text = "Thể loại";
            this.bntTheLoai.UseVisualStyleBackColor = true;
            this.bntTheLoai.Click += new System.EventHandler(this.bntTheLoai_Click);
            // 
            // bntNuocSanXuat
            // 
            this.bntNuocSanXuat.Location = new System.Drawing.Point(6, 108);
            this.bntNuocSanXuat.Name = "bntNuocSanXuat";
            this.bntNuocSanXuat.Size = new System.Drawing.Size(94, 23);
            this.bntNuocSanXuat.TabIndex = 3;
            this.bntNuocSanXuat.Text = "Nước sản xuất";
            this.bntNuocSanXuat.UseVisualStyleBackColor = true;
            this.bntNuocSanXuat.Click += new System.EventHandler(this.bntNuocSanXuat_Click);
            // 
            // bntDoiTuong
            // 
            this.bntDoiTuong.Location = new System.Drawing.Point(6, 78);
            this.bntDoiTuong.Name = "bntDoiTuong";
            this.bntDoiTuong.Size = new System.Drawing.Size(94, 23);
            this.bntDoiTuong.TabIndex = 2;
            this.bntDoiTuong.Text = "Đối tượng";
            this.bntDoiTuong.UseVisualStyleBackColor = true;
            this.bntDoiTuong.Click += new System.EventHandler(this.bntDoiTuong_Click);
            // 
            // bntMau
            // 
            this.bntMau.Location = new System.Drawing.Point(6, 48);
            this.bntMau.Name = "bntMau";
            this.bntMau.Size = new System.Drawing.Size(94, 23);
            this.bntMau.TabIndex = 1;
            this.bntMau.Text = "Màu";
            this.bntMau.UseVisualStyleBackColor = true;
            this.bntMau.Click += new System.EventHandler(this.bntMau_Click);
            // 
            // bntChatLieu
            // 
            this.bntChatLieu.Location = new System.Drawing.Point(6, 19);
            this.bntChatLieu.Name = "bntChatLieu";
            this.bntChatLieu.Size = new System.Drawing.Size(94, 23);
            this.bntChatLieu.TabIndex = 0;
            this.bntChatLieu.Text = "Chất liệu";
            this.bntChatLieu.UseVisualStyleBackColor = true;
            this.bntChatLieu.Click += new System.EventHandler(this.bntChatLieu_Click);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabHoaDonBan);
            this.tabMain.Controls.Add(this.tabHoaDonNhap);
            this.tabMain.Controls.Add(this.tabSanPham);
            this.tabMain.Controls.Add(this.tabBaoCao);
            this.tabMain.Controls.Add(this.txtCauHinh);
            this.tabMain.Location = new System.Drawing.Point(0, 28);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(0, 0);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(717, 422);
            this.tabMain.TabIndex = 3;
            // 
            // tabHoaDonBan
            // 
            this.tabHoaDonBan.Controls.Add(this.panel2);
            this.tabHoaDonBan.Location = new System.Drawing.Point(4, 22);
            this.tabHoaDonBan.Margin = new System.Windows.Forms.Padding(0);
            this.tabHoaDonBan.Name = "tabHoaDonBan";
            this.tabHoaDonBan.Size = new System.Drawing.Size(709, 396);
            this.tabHoaDonBan.TabIndex = 5;
            this.tabHoaDonBan.Text = "Hóa đơn bán";
            this.tabHoaDonBan.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(4, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 395);
            this.panel2.TabIndex = 0;
            // 
            // tabHoaDonNhap
            // 
            this.tabHoaDonNhap.Controls.Add(this.panel1);
            this.tabHoaDonNhap.Location = new System.Drawing.Point(4, 22);
            this.tabHoaDonNhap.Margin = new System.Windows.Forms.Padding(0);
            this.tabHoaDonNhap.Name = "tabHoaDonNhap";
            this.tabHoaDonNhap.Size = new System.Drawing.Size(709, 396);
            this.tabHoaDonNhap.TabIndex = 4;
            this.tabHoaDonNhap.Text = "Hóa đơn nhập";
            this.tabHoaDonNhap.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(4, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 395);
            this.panel1.TabIndex = 0;
            // 
            // tabSanPham
            // 
            this.tabSanPham.Controls.Add(this.panel);
            this.tabSanPham.Location = new System.Drawing.Point(4, 22);
            this.tabSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.tabSanPham.Name = "tabSanPham";
            this.tabSanPham.Size = new System.Drawing.Size(709, 396);
            this.tabSanPham.TabIndex = 3;
            this.tabSanPham.Text = "Sản phẩm";
            this.tabSanPham.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(4, 1);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(702, 395);
            this.panel.TabIndex = 0;
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.panel3);
            this.tabBaoCao.Location = new System.Drawing.Point(4, 22);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(709, 396);
            this.tabBaoCao.TabIndex = 6;
            this.tabBaoCao.Text = "Báo cáo";
            this.tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(4, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 395);
            this.panel3.TabIndex = 0;
            // 
            // AppMediator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 447);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppMediator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Cửa hàng Giày dép";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.txtCauHinh.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabHoaDonBan.ResumeLayout(false);
            this.tabHoaDonNhap.ResumeLayout(false);
            this.tabSanPham.ResumeLayout(false);
            this.tabBaoCao.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TabPage txtCauHinh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bntKhachHang;
        private System.Windows.Forms.Button bntNhaCungCap;
        private System.Windows.Forms.Button bntNhanVien;
        private System.Windows.Forms.Button bntCongViec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bntMua;
        private System.Windows.Forms.Button bntKichCo;
        private System.Windows.Forms.Button bntTheLoai;
        private System.Windows.Forms.Button bntNuocSanXuat;
        private System.Windows.Forms.Button bntDoiTuong;
        private System.Windows.Forms.Button bntMau;
        private System.Windows.Forms.Button bntChatLieu;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSanPham;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem tsmBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmThoat;
        private System.Windows.Forms.ToolStripMenuItem tsmImportExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmRestore;
        private System.Windows.Forms.ToolStripMenuItem tsmHuongDan;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.TabPage tabHoaDonNhap;
        private System.Windows.Forms.TabPage tabHoaDonBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem tsmTaiKhoan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem txtUserInfo;
        private System.Windows.Forms.TabPage tabBaoCao;
    }
}

