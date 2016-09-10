// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="AppMediator.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Core.Infrastructure;
using App.Models;
using Autofac;
using Autofac.Core.Registration;
using App.Extensions;
using System.Drawing;

namespace App.Views {
    /// <summary>
    /// Class AppMediator.
    /// </summary>
    public partial class AppMediator: Form {
        /// <summary>
        /// The application
        /// </summary>
        private readonly IContainer app = AppFacade.Container;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppMediator"/> class.
        /// </summary>
        public AppMediator() {
            InitializeComponent();
            app = AppFacade.Container;
            //InitializeFirst();
            LoadSanPhamView();

        }
        public void Eventlistener<T>(object sender, AppEvent<T> e) {
            var key = sender.ToString();
            if(key == Mediator.DANGNHAP_KHONG_THANH_CONG) {
                Application.Exit();
            }
        }
        private void InitializeFirst() {
            try {
                var a = app.Resolve<INhanVienController<NhanVienModel>>();
                a.Notification += Eventlistener;
                a.ShowDangNhap();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        private void LoadSanPhamView() {
            var b = app.Resolve<ISanPhamController<SanPhamModel>>();
            var a = new SanPhanListView(b) { TopLevel = false, Parent = this, Dock = DockStyle.Fill, FormBorderStyle = FormBorderStyle.None };
            panel.Controls.Add(a);
            b.SetSanPhamListView(a);
            a.Show();
            b.ReviewGrid();
        }


        /// <summary>
        /// Handles the Click event of the bntChatLieu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntChatLieu_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<ChatLieuModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntMau control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntMau_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<MauModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntDoiTuong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntDoiTuong_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<DoiTuongModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntNuocSanXuat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntNuocSanXuat_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<NuocSanXuatModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntTheLoai control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntTheLoai_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<TheLoaiModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntKichCo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntKichCo_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<KichCoModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntMua control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntMua_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<MuaModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntCongViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntCongViec_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<CongViecModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntNhanVien_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<NhanVienModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntNhaCungCap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntNhaCungCap_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<NhaCungCapModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntKhachHang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntKhachHang_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<KhachHangModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntHoaDonNhap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntHoaDonNhap_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<HoaDonNhapModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the bntHoaDonBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bntHoaDonBan_Click(object sender, EventArgs e) {
            try {
                var a = app.Resolve<IBaseController<HoaDonBanModel>>();
                a.Notification += Eventlistener;
                a.View();
            } catch(ComponentNotRegisteredException exception) {
                Alert(exception.Message);
            }
        }

        /// <summary>
        /// Alerts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        private void Alert(string value) {
            MessageBox.Show("View chưa được cài đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}