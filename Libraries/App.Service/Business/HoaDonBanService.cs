﻿// ***********************************************************************
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
        private readonly IRepository<HoaDonBan> product;

        public HoaDonBanService(IRepository<HoaDonBan> product, IDataProvider data, IDbContext db)
        {
            this.product = product;
            this.data = data;
            this.db = db;
        }

        public HoaDonBan GetById(int id)
        {
            return product.GetById(id);
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
            var query = from p in product.Table
                        where p.ID == id
                        select p;
            return query.ToList();
        }

        public IEnumerable<HoaDonBan> GetTop(int top)
        {
            var q = product.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<HoaDonBan> GetAll()
        {
            //todo: need to optimize
            return product.Table.ToList();
        }

        public void Insert(HoaDonBan entity)
        {
            product.Insert(entity);
        }

        public void Insert(IEnumerable<HoaDonBan> entities)
        {
            foreach (var entity in entities)
            {
                product.Insert(entity);
            }
        }

        public void Update(HoaDonBan entity)
        {
            product.Update(entity);
        }

        public void Update(IEnumerable<HoaDonBan> entities)
        {
            foreach (var entity in entities)
            {
                product.Update(entity);
            }
        }

        public void Delete(HoaDonBan entity)
        {
            product.Delete(entity);
        }

        public void Delete(IEnumerable<HoaDonBan> entities)
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
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteHoaDonBans"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<HoaDonBan> GetHoaDonBanByTeam(string SoHDB)
        {
            var query = from a in product.Table where a.SoHDB != SoHDB select a;
            var list = query.ToList();
            return list;
        }
    }
}
