using System.Windows.Forms;

namespace App.Views
{
    partial class SanPhamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanPhamView));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.txtSoLuongSanPham = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaMau = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNuocSanXuat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaChatLieu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaDoiTuong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaMua = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnAnh = new System.Windows.Forms.Button();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.bntThoat = new System.Windows.Forms.Button();
            this.bntLuuTiepTuc = new System.Windows.Forms.Button();
            this.bntMaChatLieu = new System.Windows.Forms.Button();
            this.bntDoiTuong = new System.Windows.Forms.Button();
            this.bntMua = new System.Windows.Forms.Button();
            this.bntLoai = new System.Windows.Forms.Button();
            this.bntCo = new System.Windows.Forms.Button();
            this.bntMau = new System.Windows.Forms.Button();
            this.bntNuocSanXuat = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(114, 12);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(213, 20);
            this.txtMaSanPham.TabIndex = 1;
            // 
            // txtSoLuongSanPham
            // 
            this.txtSoLuongSanPham.Location = new System.Drawing.Point(114, 116);
            this.txtSoLuongSanPham.Name = "txtSoLuongSanPham";
            this.txtSoLuongSanPham.Size = new System.Drawing.Size(213, 20);
            this.txtSoLuongSanPham.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số lượng sản phẩm";
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Location = new System.Drawing.Point(114, 143);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(132, 20);
            this.txtMaLoai.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã loại";
            // 
            // txtMaCo
            // 
            this.txtMaCo.Location = new System.Drawing.Point(114, 169);
            this.txtMaCo.Name = "txtMaCo";
            this.txtMaCo.Size = new System.Drawing.Size(132, 20);
            this.txtMaCo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã cỡ";
            // 
            // txtMaMau
            // 
            this.txtMaMau.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtMaMau.Location = new System.Drawing.Point(114, 221);
            this.txtMaMau.Name = "txtMaMau";
            this.txtMaMau.Size = new System.Drawing.Size(132, 20);
            this.txtMaMau.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã màu";
            // 
            // txtMaNuocSanXuat
            // 
            this.txtMaNuocSanXuat.Location = new System.Drawing.Point(114, 298);
            this.txtMaNuocSanXuat.Name = "txtMaNuocSanXuat";
            this.txtMaNuocSanXuat.Size = new System.Drawing.Size(132, 20);
            this.txtMaNuocSanXuat.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã mùa";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Location = new System.Drawing.Point(114, 38);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(213, 20);
            this.txtTenSanPham.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tên sản phẩm";
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(114, 64);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(213, 20);
            this.txtDonGiaNhap.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Đơn giá nhập";
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Location = new System.Drawing.Point(114, 90);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(213, 20);
            this.txtDonGiaBan.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Đơn giá bán";
            // 
            // txtMaChatLieu
            // 
            this.txtMaChatLieu.Location = new System.Drawing.Point(114, 195);
            this.txtMaChatLieu.Name = "txtMaChatLieu";
            this.txtMaChatLieu.Size = new System.Drawing.Size(132, 20);
            this.txtMaChatLieu.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Mã chất liệu";
            // 
            // txtMaDoiTuong
            // 
            this.txtMaDoiTuong.Location = new System.Drawing.Point(114, 246);
            this.txtMaDoiTuong.Name = "txtMaDoiTuong";
            this.txtMaDoiTuong.Size = new System.Drawing.Size(132, 20);
            this.txtMaDoiTuong.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Mã đối tượng";
            // 
            // txtMaMua
            // 
            this.txtMaMua.Location = new System.Drawing.Point(114, 272);
            this.txtMaMua.Name = "txtMaMua";
            this.txtMaMua.Size = new System.Drawing.Size(132, 20);
            this.txtMaMua.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Mã nước sản xuất";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(82, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Ảnh";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(171, 354);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 23;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnAnh
            // 
            this.btnAnh.Location = new System.Drawing.Point(252, 325);
            this.btnAnh.Name = "btnAnh";
            this.btnAnh.Size = new System.Drawing.Size(75, 23);
            this.btnAnh.TabIndex = 21;
            this.btnAnh.Text = "Chọn ảnh";
            this.btnAnh.UseVisualStyleBackColor = true;
            this.btnAnh.Click += new System.EventHandler(this.btnAnh_Click);
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(114, 326);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(132, 20);
            this.txtAnh.TabIndex = 20;
            // 
            // bntThoat
            // 
            this.bntThoat.Location = new System.Drawing.Point(252, 353);
            this.bntThoat.Name = "bntThoat";
            this.bntThoat.Size = new System.Drawing.Size(75, 23);
            this.bntThoat.TabIndex = 24;
            this.bntThoat.Text = "Thoát";
            this.bntThoat.UseVisualStyleBackColor = true;
            this.bntThoat.Click += new System.EventHandler(this.bntThoat_Click);
            // 
            // bntLuuTiepTuc
            // 
            this.bntLuuTiepTuc.Location = new System.Drawing.Point(70, 354);
            this.bntLuuTiepTuc.Name = "bntLuuTiepTuc";
            this.bntLuuTiepTuc.Size = new System.Drawing.Size(95, 23);
            this.bntLuuTiepTuc.TabIndex = 22;
            this.bntLuuTiepTuc.Text = "Lưu & Tiếp tục";
            this.bntLuuTiepTuc.UseVisualStyleBackColor = true;
            this.bntLuuTiepTuc.Click += new System.EventHandler(this.bntLuuTiepTuc_Click);
            // 
            // bntMaChatLieu
            // 
            this.bntMaChatLieu.Location = new System.Drawing.Point(252, 194);
            this.bntMaChatLieu.Name = "bntMaChatLieu";
            this.bntMaChatLieu.Size = new System.Drawing.Size(75, 23);
            this.bntMaChatLieu.TabIndex = 11;
            this.bntMaChatLieu.Text = "Chất liệu";
            this.bntMaChatLieu.UseVisualStyleBackColor = true;
            this.bntMaChatLieu.Click += new System.EventHandler(this.bntMaChatLieu_Click);
            // 
            // bntDoiTuong
            // 
            this.bntDoiTuong.Location = new System.Drawing.Point(252, 245);
            this.bntDoiTuong.Name = "bntDoiTuong";
            this.bntDoiTuong.Size = new System.Drawing.Size(75, 23);
            this.bntDoiTuong.TabIndex = 15;
            this.bntDoiTuong.Text = "Đối tượng";
            this.bntDoiTuong.UseVisualStyleBackColor = true;
            this.bntDoiTuong.Click += new System.EventHandler(this.bntDoiTuong_Click);
            // 
            // bntMua
            // 
            this.bntMua.Location = new System.Drawing.Point(252, 271);
            this.bntMua.Name = "bntMua";
            this.bntMua.Size = new System.Drawing.Size(75, 23);
            this.bntMua.TabIndex = 17;
            this.bntMua.Text = "Mùa";
            this.bntMua.UseVisualStyleBackColor = true;
            this.bntMua.Click += new System.EventHandler(this.bntMua_Click);
            // 
            // bntLoai
            // 
            this.bntLoai.Location = new System.Drawing.Point(252, 142);
            this.bntLoai.Name = "bntLoai";
            this.bntLoai.Size = new System.Drawing.Size(75, 23);
            this.bntLoai.TabIndex = 7;
            this.bntLoai.Text = "Loại";
            this.bntLoai.UseVisualStyleBackColor = true;
            this.bntLoai.Click += new System.EventHandler(this.bntLoai_Click);
            // 
            // bntCo
            // 
            this.bntCo.Location = new System.Drawing.Point(252, 168);
            this.bntCo.Name = "bntCo";
            this.bntCo.Size = new System.Drawing.Size(75, 23);
            this.bntCo.TabIndex = 9;
            this.bntCo.Text = "Cỡ";
            this.bntCo.UseVisualStyleBackColor = true;
            this.bntCo.Click += new System.EventHandler(this.bntCo_Click);
            // 
            // bntMau
            // 
            this.bntMau.Location = new System.Drawing.Point(252, 220);
            this.bntMau.Name = "bntMau";
            this.bntMau.Size = new System.Drawing.Size(75, 23);
            this.bntMau.TabIndex = 13;
            this.bntMau.Text = "Màu";
            this.bntMau.UseVisualStyleBackColor = true;
            this.bntMau.Click += new System.EventHandler(this.bntMau_Click);
            // 
            // bntNuocSanXuat
            // 
            this.bntNuocSanXuat.Location = new System.Drawing.Point(252, 297);
            this.bntNuocSanXuat.Name = "bntNuocSanXuat";
            this.bntNuocSanXuat.Size = new System.Drawing.Size(75, 23);
            this.bntNuocSanXuat.TabIndex = 19;
            this.bntNuocSanXuat.Text = "Nước SX";
            this.bntNuocSanXuat.UseVisualStyleBackColor = true;
            this.bntNuocSanXuat.Click += new System.EventHandler(this.bntNuocSanXuat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(344, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(395, 364);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // SanPhamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 390);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bntNuocSanXuat);
            this.Controls.Add(this.bntMau);
            this.Controls.Add(this.bntCo);
            this.Controls.Add(this.bntLoai);
            this.Controls.Add(this.bntMua);
            this.Controls.Add(this.bntDoiTuong);
            this.Controls.Add(this.bntMaChatLieu);
            this.Controls.Add(this.bntLuuTiepTuc);
            this.Controls.Add(this.bntThoat);
            this.Controls.Add(this.txtAnh);
            this.Controls.Add(this.btnAnh);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtMaMua);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMaDoiTuong);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtMaChatLieu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDonGiaBan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDonGiaNhap);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTenSanPham);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaNuocSanXuat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaMau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaCo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaLoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoLuongSanPham);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaSanPham);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SanPhamView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.TextBox txtSoLuongSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaMau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaNuocSanXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaChatLieu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaDoiTuong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaMua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnAnh;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.Button bntThoat;
        private System.Windows.Forms.Button bntLuuTiepTuc;
        private System.Windows.Forms.Button bntMaChatLieu;
        private System.Windows.Forms.Button bntDoiTuong;
        private System.Windows.Forms.Button bntMua;
        private System.Windows.Forms.Button bntLoai;
        private System.Windows.Forms.Button bntCo;
        private System.Windows.Forms.Button bntMau;
        private System.Windows.Forms.Button bntNuocSanXuat;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
    }
}