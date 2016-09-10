// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="SanPhamController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Controllers.Interface;
using App.Core.Domain;
using App.Extensions;
using App.Models;
using App.Properties;
using App.Service.Business;
using App.Views;

namespace App.Controllers
{
    /// <summary>
    ///     Class SanPhamController.
    /// </summary>
    public class SanPhamController : ISanPhamController<SanPhamModel>
    {
        /// <summary>
        ///     The chat lieu service
        /// </summary>
        private readonly ISanPhamService sanPhamService;
        private readonly ITheLoaiService theLoaiService;
        private readonly IKichCoService KichCoService;
        private readonly IChatLieuService chatLieuService;
        private readonly IMauService mauService;
        private readonly IMuaService muaService;
        private readonly IDoiTuongService doiTuongService;
        private readonly INuocSanXuatService nuocSXService;

        private SanPhamView sanPhamView;

        /// <summary>
        ///     The view
        /// </summary>
        private SanPhanListView sanPhanListView;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SanPhamController" /> class.
        /// </summary>
        /// <param name="SanPhamService">The chat lieu service.</param>
        public SanPhamController(ISanPhamService sanPhamService, ITheLoaiService theLoaiService, IKichCoService KichCoService, IChatLieuService chatLieuService, IMauService mauService, IMuaService muaService, IDoiTuongService doiTuongService, INuocSanXuatService nuocSxService)
        {
            this.sanPhamService = sanPhamService;
            this.theLoaiService = theLoaiService;
            this.KichCoService = KichCoService;
            this.chatLieuService = chatLieuService;
            this.mauService = mauService;
            this.muaService = muaService;
            this.doiTuongService = doiTuongService;
            nuocSXService = nuocSxService;
            sanPhamView = new SanPhamView(this);
        }

        public event EventHandler<AppEvent<SanPhamModel>> Notification;

        /// <summary>
        ///     Views this instance.
        /// </summary>
        public void View()
        {
            PostView();
            sanPhanListView.View();
        }

        /// <summary>
        ///     Reviews the grid.
        /// </summary>
        public void ReviewGrid()
        {
            PostView();
        }

        /// <summary>
        ///     Inserts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Insert(SanPhamModel value)
        {
            try
            {
                var entity = value.ToEntity();
                sanPhamService.Insert(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Resources.Insert_Fault, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Updates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Update(SanPhamModel value)
        {
            SanPham entity = ModelToEntity(value);
            sanPhamService.Update(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(int value)
        {
            SanPham entity = sanPhamService.GetById(value);
            sanPhamService.Delete(entity);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(SanPhamModel value)
        {
            Delete(value.ID);
        }

        /// <summary>
        ///     Deletes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Delete(string value)
        {
            List<int> list = value.Split(',').Select(a => Convert.ToInt32(a)).ToList();
            foreach (int i in list)
            {
                Delete(i);
            }
        }

        public IList<string> ValidateAndFillup(SanPhamModel value)
        {
            var a = new List<string>();
            var loai     =  theLoaiService.GetByMa(value.MaLoai);
            var co       =  KichCoService.GetByMa(value.MaCo);
            var chatLieu =  chatLieuService.GetByMa(value.MaChatLieu);
            var mau      =  mauService.GetByMa(value.MaMau);
            var doiTuong =  doiTuongService.GetByMa(value.MaDoiTuong);
            var mua      =  muaService.GetByMa(value.MaMua);
            var nuocSx   =  nuocSXService.GetByMa(value.MaNuocSX);

            if(loai    ==null){a.Add("MaLoai");}
            if(co      ==null){a.Add("MaCo");}
            if(chatLieu==null){a.Add("MaChatLieu");}
            if(mau     ==null){a.Add("MaMau");}
            if(doiTuong==null){a.Add("MaDoiTuong");}
            if(mua     ==null){a.Add("MaMua");}
            if(nuocSx  ==null){a.Add("MaNuocSX");}

            if(loai    !=null){value.TheLoaiID = loai.ID;}
            if(co      !=null){value.KichCoID = co.ID;}
            if(chatLieu!=null){value.ChatLieuID = chatLieu.ID;}
            if(mau     !=null){value.MauID = mau.ID;}
            if(doiTuong!=null){value.DoiTuongID = doiTuong.ID;}
            if(mua     !=null){value.MuaID = mau.ID;}
            if(nuocSx  !=null){value.NuocSanXuatID = nuocSx.ID;}

            return a;
        }

        public void HideSanPhamView()
        {
            sanPhamView.Hide();
        }

        public void ShowSanPhamView(SanPhamModel value)
        {
            sanPhamView.InitializeForm(value);
            sanPhamView.ShowDialog();
        }

        public void SetSanPhamListView(Form value)
        {
            sanPhanListView = (SanPhanListView)value;
        }

        /// <summary>
        ///     Posts the view.
        /// </summary>
        private void PostView()
        {
            IEnumerable<SanPham> a = sanPhamService.GetAll();
            List<SanPhamModel> listModel = a.Select(b => b.ToModel()).ToList();
            sanPhanListView.PostView(listModel);
        }

        protected virtual SanPham ModelToEntity(SanPhamModel model)
        {
            SanPham a = sanPhamService.GetById(model.ID);
            return a == null ? null : model.ToEntity(a);
        }
    }
}