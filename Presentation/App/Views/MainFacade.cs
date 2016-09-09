using System;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Core.Infrastructure;
using App.Models;
using Autofac;
using Autofac.Core.Registration;

namespace App.Views{
    public partial class MainFacade : Form{
        private readonly IContainer app = AppFacade.Container;

        public MainFacade(){
            InitializeComponent();
            app = AppFacade.Container;
        }

        private void button1_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<NhaCungCapModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntChatLieu_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<ChatLieuModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntMau_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<MauModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntDoiTuong_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<DoiTuongModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntNuocSanXuat_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<NuocSanXuatModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntTheLoai_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<TheLoaiModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntKichCo_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<TheLoaiModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntMua_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<MuaModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntCongViec_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<CongViecModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntNhanVien_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<NhanVienModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntNhaCungCap_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<NhaCungCapModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntKhachHang_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<KhachHangModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntHoaDonNhap_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<HoaDonNhapModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void bntHoaDonBan_Click(object sender, EventArgs e){
            try{
                app.Resolve<IBaseController<HoaDonBanModel>>().View();
            }
            catch (ComponentNotRegisteredException exception){
                Alert(exception.Message);
            }
        }

        private void Alert(string value){
            MessageBox.Show("View chưa được cài đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}