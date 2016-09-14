// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="SanPhamService.cs" company="Thanh Dong University">
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
using System.IO;

namespace App.Service.Business
{
    /// <summary>
    ///     Class SanPhamService.
    /// </summary>
    public class SanPhamService : AbstractService, ISanPhamService
    {
        private readonly IRepository<SanPham> repos;
        private readonly IRepository<ChiTietHDB> hodon;

        public SanPhamService(IRepository<SanPham> repos, IDataProvider data, IDbContext db, IRepository<ChiTietHDB> hodon)
        {
            this.repos = repos;
            this.hodon = hodon;
            this.data = data;
            this.db = db;
        }

        public SanPham GetByMa(string ma)
        {
            var query = from a in repos.Table where a.MaGiayDep == ma select a;
            return query.FirstOrDefault();
        }

        public SanPham GetById(int id)
        {
            return repos.GetById(id);
        }

        public IEnumerable<SanPham> GetListByPaging(string value, string index, int page, int size, string sort, out int total)
        {
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<SanPham>(sp.ToSpString("GetSanPhamByPagingFilter"), sp.GetObject()).ToList<SanPham>();

            total = (int)sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<SanPham> GetList(int id)
        {
            //todo: need to optimize
            var query = from p in repos.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<SanPham> GetTop(int top)
        {
            var q = repos.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<SanPham> GetAll()
        {
            //todo: need to optimize
            return repos.Table.ToList();
        }

        public void Insert(SanPham entity)
        {
            repos.Insert(entity);
        }

        public void Insert(IEnumerable<SanPham> entities)
        {
            foreach (var entity in entities)
            {
                repos.Insert(entity);
            }
        }

        public void Update(SanPham entity)
        {
            repos.Update(entity);
        }

        public void Update(IEnumerable<SanPham> entities)
        {
            foreach (var entity in entities)
            {
                repos.Update(entity);
            }
        }

        public void Delete(SanPham entity)
        {
            repos.Delete(entity);
        }

        public void Delete(IEnumerable<SanPham> entities)
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
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteSanPhams"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<SanPham> GetSanPhamByTeam(string maGiayDep)
        {
            var query = from a in repos.Table where a.MaGiayDep == maGiayDep select a;
            var list = query.ToList();
            return list;
        }

        public List<SanPham> GetHangTonKho()
        {
            var qa = (from a in hodon.Table select a.SanPhamID);
            var qb = (from a in repos.Table where !qa.Contains(a.ID) select a);
            return qb.ToList();
        }

        public string GetNewUrlImage(string urlold, string fileName, string NewForderUrl)
        {
            string dest = NewForderUrl + "\\" + fileName;
            File.Copy(urlold, dest, true);
            return dest;
        }
    }
}
