﻿using System;
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
    public partial class SanPhamView: Form {
        private ISanPhamController<SanPhamModel> currentController;
        private SanPhamModel currentModel;
        public SanPhamView(ISanPhamController<SanPhamModel> controller) {
            currentController = controller;
            InitializeComponent();
        }

        private bool isCreateNew = false;

        public void InitializeForm(SanPhamModel value) {
            currentModel = value;
            isCreateNew = (value == null);
            this.Text = (value == null) ? "Tạo Sản phẩm" : "Sửa Sản phẩm";
        }

        private void SetLuu(SanPhamModel value) {
            if(isCreateNew) {
                value = new SanPhamModel {
                    MaGiayDep = txtMaSanPham.Text,
                    TenGiayDep = txtTenSanPham.Text,
                    SoLuong = txtSoLuongSanPham.Text.ToInt32(),
                    Anh = txtMaChatLieu.Text,
                    DonGiaNhap = txtDonGiaNhap.Text.ToDecimal(),
                    DonGiaBan = txtDonGiaBan.Text.ToDecimal(),
                    MaLoai = txtMaLoai.Text,
                    MaCo = txtMaCo.Text,
                    MaChatLieu = txtMaChatLieu.Text,
                    MaMau = txtMaMau.Text,
                    MaDoiTuong = txtMaDoiTuong.Text,
                    MaMua = txtMaMua.Text,
                    MaNuocSX = txtMaNuocSanXuat.Text
                };
                currentController.Insert(value);
            } else {

                value.MaGiayDep = txtMaSanPham.Text;
                value.TenGiayDep = txtTenSanPham.Text;
                value.SoLuong = txtSoLuongSanPham.Text.ToInt32();
                value.Anh = txtMaChatLieu.Text;
                value.DonGiaNhap = txtDonGiaNhap.Text.ToDecimal();
                value.DonGiaBan = txtDonGiaBan.Text.ToDecimal();
                value.MaLoai = txtMaLoai.Text;
                value.MaCo = txtMaCo.Text;
                value.MaChatLieu = txtMaChatLieu.Text;
                value.MaMau = txtMaMau.Text;
                value.MaDoiTuong = txtMaDoiTuong.Text;
                value.MaMua = txtMaMua.Text;
                value.MaNuocSX = txtMaNuocSanXuat.Text;

                currentController.Update(currentModel);
            }
        }

        private void bntThoat_Click(object sender, EventArgs e) {
            currentController.HideSanPhamView();
        }

        private void btnLuu_Click(object sender, EventArgs e) {
            SetLuu(currentModel);
            currentController.HideSanPhamView();
        }

        private void btnAnh_Click(object sender, EventArgs e) {

        }

        private void bntMaChatLieu_Click(object sender, EventArgs e) {

        }

        private void bntDoiTuong_Click(object sender, EventArgs e) {

        }

        private void bntMua_Click(object sender, EventArgs e) {

        }

        private void bntLoai_Click(object sender, EventArgs e) {

        }

        private void bntCo_Click(object sender, EventArgs e) {

        }

        private void bntMau_Click(object sender, EventArgs e) {

        }

        private void bntNuocSanXuat_Click(object sender, EventArgs e) {

        }

        private void bntLuuTiepTuc_Click(object sender, EventArgs e) {
            SetLuu(currentModel);
        }
    }
}
