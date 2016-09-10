// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="CongViecService.cs" company="Thanh Dong University">
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
    ///     Class CongViecService.
    /// </summary>
    public class CongViecService : AbstractService, ICongViecService
    {
        private readonly IRepository<CongViec> repos;

        public CongViecService(IRepository<CongViec> repos, IDataProvider data, IDbContext db)
        {
            this.repos = repos;
            this.data = data;
            this.db = db;
        }

        public CongViec GetByMa(string ma)
        {
            var query = from a in repos.Table where a.MaCV == ma select a;
            return query.FirstOrDefault();
        }

        public CongViec GetById(int id)
        {
            return repos.GetById(id);
        }

        public IEnumerable<CongViec> GetListByPaging(string value, string index, int page, int size, string sort, out int total)
        {
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<CongViec>(sp.ToSpString("GetCongViecByPagingFilter"), sp.GetObject()).ToList<CongViec>();

            total = (int)sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<CongViec> GetList(int id)
        {
            //todo: need to optimize
            var query = from p in repos.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<CongViec> GetTop(int top)
        {
            var q = repos.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<CongViec> GetAll()
        {
            //todo: need to optimize
            return repos.Table.ToList();
        }

        public void Insert(CongViec entity)
        {
            repos.Insert(entity);
        }

        public void Insert(IEnumerable<CongViec> entities)
        {
            foreach (var entity in entities)
            {
                repos.Insert(entity);
            }
        }

        public void Update(CongViec entity)
        {
            repos.Update(entity);
        }

        public void Update(IEnumerable<CongViec> entities)
        {
            foreach (var entity in entities)
            {
                repos.Update(entity);
            }
        }

        public void Delete(CongViec entity)
        {
            repos.Delete(entity);
        }

        public void Delete(IEnumerable<CongViec> entities)
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
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteCongViecs"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<CongViec> GetCongViecByTeam(string MaCV)
        {
            var query = from a in repos.Table where a.MaCV != MaCV select a;
            var list = query.ToList();
            return list;
        }
    }
}
