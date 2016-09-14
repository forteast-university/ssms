// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="HoaDonBanService.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Data;
using App.Core.Domain;
using App.Data;

namespace App.Service.Business
{
    /// <summary>
    ///     Class HoaDonBanService.
    /// </summary>
    public class HoaDonBanService : AbstractService, IHoaDonBanService
    {
        private readonly IRepository<HoaDonBan> repos;

        public HoaDonBanService(IRepository<HoaDonBan> repos, IDataProvider data, IDbContext db)
        {
            this.repos = repos;
            this.data = data;
            this.db = db;
        }

        public HoaDonBan GetByMa(string ma)
        {
            var query = from a in repos.Table where a.SoHDB == ma select a;
            return query.FirstOrDefault();
        }

        public HoaDonBan GetById(int id)
        {
            return repos.GetById(id);
        }

        public IEnumerable<HoaDonBan> GetListByPaging(string value, string index, int page, int size, string sort, out int total)
        {
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<HoaDonBan>(sp.ToSpString("GetHoaDonBanByPagingFilter"), sp.GetObject()).ToList<HoaDonBan>();

            total = (int)sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<HoaDonBan> GetList(int id)
        {
            //todo: need to optimize
            var query = from p in repos.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<HoaDonBan> GetTop(int top)
        {
            var q = repos.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<HoaDonBan> GetAll()
        {
            //todo: need to optimize
            return repos.Table.ToList();
        }

        public void Insert(HoaDonBan entity)
        {
            repos.Insert(entity);
        }

        public void Insert(IEnumerable<HoaDonBan> entities)
        {
            foreach (var entity in entities)
            {
                repos.Insert(entity);
            }
        }

        public void Update(HoaDonBan entity)
        {
            repos.Update(entity);
        }

        public void Update(IEnumerable<HoaDonBan> entities)
        {
            foreach (var entity in entities)
            {
                repos.Update(entity);
            }
        }

        public void Delete(HoaDonBan entity)
        {
            repos.Delete(entity);
        }

        public void Delete(IEnumerable<HoaDonBan> entities)
        {
            foreach (var entity in entities)
            {
                repos.Delete(entity);
            }
        }

        public bool Delete(IList<int> entities)
        {
            if (entities.Count == 0)
                return false;
            var list = String.Join(",", entities);
            var sp = new SpHelper().Add("ids", list, 1000);
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteHoaDonBans"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<HoaDonBan> GetHoaDonTopBestBuy(int top)
        {
            //var query = repos.Table
            //    .GroupBy(l => l.MaKhach)
            //    .Select(cl => new HoaDonBan {
            //        MaKhach = cl.First().MaKhach,
            //        TongTien = cl.Sum(c => c.TongTien)
            //    });

            //var query = from line in repos.Table
            //              group line by line.KhachHang into g
            //            select new HoaDonBan {
            //                MaKhach = g.First().MaKhach,
            //                TongTien = g.Sum(c => c.TongTien),
            //              };


            //var query =  from bs in repos.Table
            //             group bs by bs.KhachHang into g
            //             orderby g.Sum(x => x.TongTien) descending
            //             select new {
            //                 MaKhach = g.First().MaKhach,
            //                 SoHDB = "",
            //                 NgayBan = DateTime.Now,
            //                 MaNV = "-1",
            //                 KhachHangID = 0,
            //                 NhanVienID = 0,
            //                 TongTien = g.Sum(x => x.TongTien)
            //             };


           var query= from r in repos.Table
            group r by new
            {
                r.MaKhach
            }
            into g
            select new 
            {
                g.Key.MaKhach,
                TongTien = g.Sum(x => x.TongTien)
            };

            var mmm = query.Take(top).ToList().Select(c=>new HoaDonBan{MaKhach = c.MaKhach, TongTien = c.TongTien});
            return mmm.ToList();
        }

        public List<HoaDonBan> GetHoaDonByNhanVien(string maNhanVien)
        {
            var query = from a in repos.Table where a.MaNV == maNhanVien select a;
            var list = query.ToList();
            return list;
        }

        public List<HoaDonBan> GetChiTietHDBByTeam(string SoHDB)
        {
            var query = from a in repos.Table where a.SoHDB == SoHDB select a;
            var list = query.ToList();
            return list;
        }
    }
}
