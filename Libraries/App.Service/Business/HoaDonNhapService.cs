﻿// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="HoaDonNhapService.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Data;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Data;

namespace App.Service.Business
{
    /// <summary>
    ///     Class HoaDonNhapService.
    /// </summary>
    public class HoaDonNhapService : AbstractService, IHoaDonNhapService
    {
        private readonly IRepository<HoaDonNhap> repos;

        public HoaDonNhapService(IRepository<HoaDonNhap> repos, IDataProvider data, IDbContext db)
        {
            this.repos = repos;
            this.data = data;
            this.db = db;
        }

        public HoaDonNhap GetByMa(string ma)
        {
            var query = from a in repos.Table where a.SoHDN == ma select a;
            return query.FirstOrDefault();
        }

        public HoaDonNhap GetById(int id)
        {
            return repos.GetById(id);
        }

        public IEnumerable<HoaDonNhap> GetListByPaging(string value, string index, int page, int size, string sort, out int total)
        {
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<HoaDonNhap>(sp.ToSpString("GetHoaDonNhapByPagingFilter"), sp.GetObject()).ToList<HoaDonNhap>();

            total = (int)sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<HoaDonNhap> GetList(int id)
        {
            //todo: need to optimize
            var query = from p in repos.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<HoaDonNhap> GetTop(int top)
        {
            var q = repos.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<HoaDonNhap> GetAll()
        {
            //todo: need to optimize
            return repos.Table.ToList();
        }

        public void Insert(HoaDonNhap entity)
        {
            repos.Insert(entity);
        }

        public void Insert(IEnumerable<HoaDonNhap> entities)
        {
            foreach (var entity in entities)
            {
                repos.Insert(entity);
            }
        }

        public void Update(HoaDonNhap entity)
        {
            repos.Update(entity);
        }

        public void Update(IEnumerable<HoaDonNhap> entities)
        {
            foreach (var entity in entities)
            {
                repos.Update(entity);
            }
        }

        public void Delete(HoaDonNhap entity)
        {
            repos.Delete(entity);
        }

        public void Delete(IEnumerable<HoaDonNhap> entities)
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
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteHoaDonNhaps"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<HoaDonNhap> GetBaoCaoTheoQuy(DateTime starTime, DateTime endTime)
        {
            var query = from a in repos.Table where a.NgayNhap >= starTime where a.NgayNhap <=endTime select a;
            var list = query.ToList();
            return list;
        }

        public List<HoaDonNhap> GetHoaDonNhapByTeam(string SoHDN)
        {
            var query = from a in repos.Table where a.SoHDN == SoHDN select a;
            var list = query.ToList();
            return list;
        }
       
    }
}
