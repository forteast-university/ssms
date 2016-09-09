// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="TheLoaiService.cs" company="Thanh Dong University">
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
    ///     Class TheLoaiService.
    /// </summary>
    public class TheLoaiService : AbstractService, ITheLoaiService
    {
        private readonly IRepository<TheLoai> repos;

        public TheLoaiService(IRepository<TheLoai> repos, IDataProvider data, IDbContext db)
        {
            this.repos = repos;
            this.data = data;
            this.db = db;
        }

        public TheLoai GetById(int id)
        {
            return repos.GetById(id);
        }

        public IEnumerable<TheLoai> GetListByPaging(string value, string index, int page, int size, string sort, out int total)
        {
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<TheLoai>(sp.ToSpString("GetTheLoaiByPagingFilter"), sp.GetObject()).ToList<TheLoai>();

            total = (int)sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<TheLoai> GetList(int id)
        {
            //todo: need to optimize
            var query = from p in repos.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<TheLoai> GetTop(int top)
        {
            var q = repos.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<TheLoai> GetAll()
        {
            //todo: need to optimize
            return repos.Table.ToList();
        }

        public void Insert(TheLoai entity)
        {
            repos.Insert(entity);
        }

        public void Insert(IEnumerable<TheLoai> entities)
        {
            foreach (var entity in entities)
            {
                repos.Insert(entity);
            }
        }

        public void Update(TheLoai entity)
        {
            repos.Update(entity);
        }

        public void Update(IEnumerable<TheLoai> entities)
        {
            foreach (var entity in entities)
            {
                repos.Update(entity);
            }
        }

        public void Delete(TheLoai entity)
        {
            repos.Delete(entity);
        }

        public void Delete(IEnumerable<TheLoai> entities)
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
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteTheLoais"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<TheLoai> GetTheLoaiByTeam(string MaLoai)
        {
            var query = from a in repos.Table where a.MaLoai != MaLoai select a;
            var list = query.ToList();
            return list;
        }
    }
}
