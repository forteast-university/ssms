﻿using System.Windows.Forms;

namespace App.Views {
    partial class ChatLieuView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.txtMaChatLieu = new System.Windows.Forms.TextBox();
            this.txtTenChatLieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bntLuaChon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bntLuu
            // 
            this.bntLuu.Location = new System.Drawing.Point(284, 37);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(75, 23);
            this.bntLuu.TabIndex = 0;
            this.bntLuu.Text = "Lưu";
            this.bntLuu.UseVisualStyleBackColor = true;
            this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
            // 
            // bntHuy
            // 
            this.bntHuy.Location = new System.Drawing.Point(284, 395);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(75, 23);
            this.bntHuy.TabIndex = 1;
            this.bntHuy.Text = "Hủy bỏ";
            this.bntHuy.UseVisualStyleBackColor = true;
            this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
            // 
            // txtMaChatLieu
            // 
            this.txtMaChatLieu.Location = new System.Drawing.Point(88, 12);
            this.txtMaChatLieu.Name = "txtMaChatLieu";
            this.txtMaChatLieu.Size = new System.Drawing.Size(180, 20);
            this.txtMaChatLieu.TabIndex = 2;
            // 
            // txtTenChatLieu
            // 
            this.txtTenChatLieu.Location = new System.Drawing.Point(88, 39);
            this.txtTenChatLieu.Name = "txtTenChatLieu";
            this.txtTenChatLieu.Size = new System.Drawing.Size(180, 20);
            this.txtTenChatLieu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã chất liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên chất liệu";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 68);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(347, 321);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellClick += new DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.MultiSelect = false;
            this.dataGridView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.AllowUserToResizeRows = false;
            // 
            // bntLuaChon
            // 
            this.bntLuaChon.Location = new System.Drawing.Point(13, 395);
            this.bntLuaChon.Name = "bntLuaChon";
            this.bntLuaChon.Size = new System.Drawing.Size(75, 23);
            this.bntLuaChon.TabIndex = 7;
            this.bntLuaChon.Text = "Lựa chọn";
            this.bntLuaChon.UseVisualStyleBackColor = true;
            this.bntLuaChon.Click += new System.EventHandler(this.bntLuaChon_Click);
            // 
            // ChatLieuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 430);
            this.Controls.Add(this.bntLuaChon);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenChatLieu);
            this.Controls.Add(this.txtMaChatLieu);
            this.Controls.Add(this.bntHuy);
            this.Controls.Add(this.bntLuu);
            this.Name = "ChatLieuView";
            this.Text = "Chất Liệu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntLuu;
        private System.Windows.Forms.Button bntHuy;
        private System.Windows.Forms.TextBox txtMaChatLieu;
        private System.Windows.Forms.TextBox txtTenChatLieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button bntLuaChon;
    }
}