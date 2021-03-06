﻿using System.Windows.Forms;

namespace App.Views
{
    partial class MauView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MauView));
            this.bntTaoMoi = new System.Windows.Forms.Button();
            this.bntXoa = new System.Windows.Forms.Button();
            this.bntLuaChon = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenMau = new System.Windows.Forms.TextBox();
            this.txtMaMau = new System.Windows.Forms.TextBox();
            this.bntHuy = new System.Windows.Forms.Button();
            this.bntLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bntTaoMoi
            // 
            this.bntTaoMoi.Location = new System.Drawing.Point(253, 6);
            this.bntTaoMoi.Name = "bntTaoMoi";
            this.bntTaoMoi.Size = new System.Drawing.Size(75, 23);
            this.bntTaoMoi.TabIndex = 29;
            this.bntTaoMoi.Text = "Tạo mới";
            this.bntTaoMoi.UseVisualStyleBackColor = true;
            this.bntTaoMoi.Click += new System.EventHandler(this.bntTaoMoi_Click);
            // 
            // bntXoa
            // 
            this.bntXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntXoa.Location = new System.Drawing.Point(15, 397);
            this.bntXoa.Name = "bntXoa";
            this.bntXoa.Size = new System.Drawing.Size(75, 23);
            this.bntXoa.TabIndex = 28;
            this.bntXoa.Text = "Xóa";
            this.bntXoa.UseVisualStyleBackColor = true;
            this.bntXoa.Click += new System.EventHandler(this.bntXoa_Click);
            // 
            // bntLuaChon
            // 
            this.bntLuaChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntLuaChon.Location = new System.Drawing.Point(96, 397);
            this.bntLuaChon.Name = "bntLuaChon";
            this.bntLuaChon.Size = new System.Drawing.Size(75, 23);
            this.bntLuaChon.TabIndex = 27;
            this.bntLuaChon.Text = "Lựa chọn";
            this.bntLuaChon.UseVisualStyleBackColor = true;
            this.bntLuaChon.Click += new System.EventHandler(this.bntLuaChon_Click);
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
            this.dataGridView.Location = new System.Drawing.Point(12, 62);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(396, 329);
            this.dataGridView.TabIndex = 26;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            this.dataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dataGridView_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tên màu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mã màu";
            // 
            // txtTenMau
            // 
            this.txtTenMau.Location = new System.Drawing.Point(67, 34);
            this.txtTenMau.Name = "txtTenMau";
            this.txtTenMau.Size = new System.Drawing.Size(180, 20);
            this.txtTenMau.TabIndex = 23;
            // 
            // txtMaMau
            // 
            this.txtMaMau.Location = new System.Drawing.Point(67, 7);
            this.txtMaMau.Name = "txtMaMau";
            this.txtMaMau.Size = new System.Drawing.Size(180, 20);
            this.txtMaMau.TabIndex = 22;
            // 
            // bntHuy
            // 
            this.bntHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntHuy.Location = new System.Drawing.Point(333, 397);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(75, 23);
            this.bntHuy.TabIndex = 21;
            this.bntHuy.Text = "Hủy bỏ";
            this.bntHuy.UseVisualStyleBackColor = true;
            this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
            // 
            // bntLuu
            // 
            this.bntLuu.Location = new System.Drawing.Point(253, 33);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(75, 23);
            this.bntLuu.TabIndex = 20;
            this.bntLuu.Text = "Lưu";
            this.bntLuu.UseVisualStyleBackColor = true;
            this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
            // 
            // MauView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 430);
            this.Controls.Add(this.bntTaoMoi);
            this.Controls.Add(this.bntXoa);
            this.Controls.Add(this.bntLuaChon);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenMau);
            this.Controls.Add(this.txtMaMau);
            this.Controls.Add(this.bntHuy);
            this.Controls.Add(this.bntLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(typeof(AppMediator)).GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MauView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Màu ";
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
        private System.Windows.Forms.TextBox txtTenMau;
        private System.Windows.Forms.TextBox txtMaMau;
        private System.Windows.Forms.Button bntHuy;
        private System.Windows.Forms.Button bntLuu;
    }
}