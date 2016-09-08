// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="DoiTuongService.cs" company="Thanh Dong University">
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
    ///     Class DoiTuongService.
    /// </summary>
    public class DoiTuongService : AbstractService, IDoiTuongService
    {
        private readonly IRepository<DoiTuong> product;

        public DoiTuongService(IRepository<DoiTuong> product, IDataProvider data, IDbContext db)
        {
            this.product = product;
            this.data = data;
            this.db = db;
        }

        public DoiTuong GetById(int id)
        {
            return product.GetById(id);
        }

        public IEnumerable<DoiTuong> GetListByPaging(string value, string index, int page, int size, string sort, out int total)
        {
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<DoiTuong>(sp.ToSpString("GetDoiTuongByPagingFilter"), sp.GetObject()).ToList<DoiTuong>();

            total = (int)sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<DoiTuong> GetList(int id)
        {
            //todo: need to optimize
            var query = from p in product.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<DoiTuong> GetTop(int top)
        {
            var q = product.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<DoiTuong> GetAll()
        {
            //todo: need to optimize
            return product.Table.ToList();
        }

        public void Insert(DoiTuong entity)
        {
            product.Insert(entity);
        }

        public void Insert(IEnumerable<DoiTuong> entities)
        {
            foreach (var entity in entities)
            {
                product.Insert(entity);
            }
        }

        public void Update(DoiTuong entity)
        {
            product.Update(entity);
        }

        public void Update(IEnumerable<DoiTuong> entities)
        {
            foreach (var entity in entities)
            {
                product.Update(entity);
            }
        }

        public void Delete(DoiTuong entity)
        {
            product.Delete(entity);
        }

        public void Delete(IEnumerable<DoiTuong> entities)
        {
            foreach (var entity in entities)
            {
                product.Delete(entity);
            }
        }

        public bool Delete(IList<int> entities)
        {
            if (entities.Count == 0)
                return false;
            var list = String.Join(",", entities);
            var sp = new SpHelper().Add("ids", list, 1000);
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteDoiTuongs"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<DoiTuong> GetDoiTuongByTeam(string MaDoiTuong)
        {
            var query = from a in product.Table where a.MaDoiTuong != MaDoiTuong select a;
            var list = query.ToList();
            return list;
        }
    }
}
