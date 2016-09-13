using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Extensions;
using App.Models;

namespace App.Views {
    public partial class DangNhapView : Form {
        /// <summary>
        ///     The controller
        /// </summary>
        private INhanVienController<NhanVienModel> controller;


        /// <summary>
        ///     The current model
        /// </summary>
        private NhanVienModel currentModel;

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void View() {
            Show();
        }

        /// <summary>
        ///     Posts the view.
        /// </summary>
        /// <param name="value">The value.</param>
        public void PostView(IEnumerable<NhanVienModel> value) {

        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="NhanVienView" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DangNhapView(INhanVienController<NhanVienModel> value) {
            controller = value;
            InitializeComponent();
        }

        private void bntThoat_Click(object sender, EventArgs e) {
            controller.CloseParent();
        }

        public void ConfirmWrong()
        {
            txtMaNhanVien.Focus();
            txtMaNhanVien.SelectAll();
            Alert("Đăng nhập không thành công, xin kiểm tra lại thông tin");
        }

        private void bntDongY_Click(object sender, EventArgs e) {
            if (txtMaNhanVien.Text == "")
            {
                Alert("Yêu cầu nhập mã nhân viên");
                return;
            }
            if(txtMatKhau.Text == "") {
                Alert("Yêu cầu nhập mật khẩu");
                return;
            }

            var a = new NhanVienModel {
                MaNhanVien = txtMaNhanVien.Text,
                MatKhau = txtMatKhau.Text
            };
            controller.DangNhap(a);
        }
        public void Alert(string value) {
            MessageBox.Show(value, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
             controller.ShowForm();
        }

        public void SetTxtMaNhanVien(string ma){
            txtMaNhanVien.Text = ma;
        }
    }
}
