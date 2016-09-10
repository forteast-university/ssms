// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="ChatLieuService.cs" company="Thanh Dong University">
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

namespace App.Service.Business{
    /// <summary>
    ///     Class ChatLieuService.
    /// </summary>
    public class ChatLieuService : AbstractService, IChatLieuService{
        private readonly IRepository<ChatLieu> chatlieu;

        public ChatLieuService(IRepository<ChatLieu> chatlieu, IDataProvider data, IDbContext db){
            this.chatlieu = chatlieu;
            this.data = data;
            this.db = db;
        }

        public ChatLieu GetByMa(string ma)
        {
            var query = from a in chatlieu.Table where a.MaChatLieu == ma select a;
            return query.FirstOrDefault();
        }

        public ChatLieu GetById(int id){
            return chatlieu.GetById(id);
        }

        public IEnumerable<ChatLieu> GetListByPaging(string value, string index, int page, int size, string sort, out int total){
            var sp = new SpHelper()
                .Add("value", value)
                .Add("index", index)
                .Add("page", page)
                .Add("size", size)
                .Add("sort", sort, 50)
                .Add("totalrow", 0, -1, true);

            var list =
                db.SqlQuery<ChatLieu>(sp.ToSpString("GetChatLieuByPagingFilter"), sp.GetObject()).ToList<ChatLieu>();

            total = (int) sp.GetParam("totalrow").Value;
            return list;
        }

        public IEnumerable<ChatLieu> GetList(int id){
            //todo: need to optimize
            var query = from p in chatlieu.Table
                where p.ID == id
                select p;
            return query.ToList();
        }

        public IEnumerable<ChatLieu> GetTop(int top){
            var q = chatlieu.Table.Take(top);
            return q.ToList();
        }

        public IEnumerable<ChatLieu> GetAll(){
            //todo: need to optimize
            return chatlieu.Table.ToList();
        }

        public void Insert(ChatLieu entity){
            chatlieu.Insert(entity);
        }

        public void Insert(IEnumerable<ChatLieu> entities){
            foreach (var entity in entities){
                chatlieu.Insert(entity);
            }
        }

        public void Update(ChatLieu entity){
            chatlieu.Update(entity);
        }

        public void Update(IEnumerable<ChatLieu> entities){
            foreach (var entity in entities){
                chatlieu.Update(entity);
            }
        }

        public void Delete(ChatLieu entity){
            chatlieu.Delete(entity);
        }

        public void Delete(IEnumerable<ChatLieu> entities){
            foreach (var entity in entities){
                chatlieu.Delete(entity);
            }
        }

        public bool Delete(IList<int> entities){
            if (entities.Count == 0)
                return false;
            var list = String.Join(",", entities);
            var sp = new SpHelper().Add("ids", list, 1000);
            var a = db.SqlQuery<int>(sp.ToSpString("DeleteChatLieus"), sp.GetObject()).ToList().FirstOrDefault();
            return (a == 1);
        }

        public List<ChatLieu> GetChatLieuByTeam(string maChatLieu){
            var query = from a in chatlieu.Table where a.MaChatLieu != maChatLieu select a;
            var list = query.ToList();
            return list;
        }
    }
}