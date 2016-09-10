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
            if (isCreateNew)
            {
                txtMaSanPham.Text = "";
                txtTenSanPham.Text = "";
                txtSoLuongSanPham.Text = "";
                txtMaChatLieu.Text = "";
                txtDonGiaNhap.Text = "";
                txtDonGiaBan.Text = "";
                txtMaLoai.Text = "";
                txtMaCo.Text = "";
                txtMaChatLieu.Text = "";
                txtMaMau.Text = "";
                txtMaDoiTuong.Text = "";
                txtMaMua.Text = "";
                txtMaNuocSanXuat.Text = "";
            }
            else
            {

                txtMaSanPham.Text = value.MaGiayDep;
                txtTenSanPham.Text = value.TenGiayDep;
                txtSoLuongSanPham.Text = value.SoLuong.ToString();
                txtMaChatLieu.Text = value.Anh;
                txtDonGiaNhap.Text = value.DonGiaNhap.ToString();
                txtDonGiaBan.Text = value.DonGiaBan.ToString();
                txtMaLoai.Text = value.MaLoai;
                txtMaCo.Text = value.MaCo;
                txtMaChatLieu.Text = value.MaChatLieu;
                txtMaMau.Text = value.MaMau;
                txtMaDoiTuong.Text = value.MaDoiTuong;
                txtMaMua.Text = value.MaMua;
                txtMaNuocSanXuat.Text = value.MaNuocSX;
            }
        }

        private SanPhamModel FulfilmentFild(SanPhamModel value) {
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
            }
            return value;
        }

        private void OnSetSave(bool isContinue) {
            var a = FulfilmentFild(currentModel);
            var validate = currentController.ValidateAndFillup(a);
            if(validate != null) {
                if(validate.Contains("MaLoai")) {
                    txtMaLoai.Focus();
                    txtMaLoai.SelectAll();
                    return;
                }
                if(validate.Contains("MaCo")) {
                    txtMaCo.Focus();
                    txtMaCo.SelectAll();
                    return;
                }
                if(validate.Contains("MaChatLieu")) {
                    txtMaChatLieu.Focus();
                    txtMaChatLieu.SelectAll();
                    return;
                }
                if(validate.Contains("MaMau")) {
                    txtMaMau.Focus();
                    txtMaMau.SelectAll();
                    return;
                }
                if(validate.Contains("MaDoiTuong")) {
                    txtMaDoiTuong.Focus();
                    txtMaDoiTuong.SelectAll();
                    return;
                }
                if(validate.Contains("MaMua")) {
                    txtMaMua.Focus();
                    txtMaMua.SelectAll();
                    return;
                }
                if(validate.Contains("MaNuocSanXuat")) {
                    txtMaNuocSanXuat.Focus();
                    txtMaNuocSanXuat.SelectAll();
                    return;
                }
            }
            if(isCreateNew) {
                currentController.Insert(a);
            } else {
                currentController.Update(a);
            }
            if(!isContinue)
                currentController.HideSanPhamView();

            currentController.ReviewGrid();
        }

        private void bntThoat_Click(object sender, EventArgs e) {
            currentController.HideSanPhamView();
        }

        private void btnLuu_Click(object sender, EventArgs e) {

            OnSetSave(false);
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
            OnSetSave(false);
        }
    }
}
