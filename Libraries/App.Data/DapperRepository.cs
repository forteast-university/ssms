using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using App.Core.Data;
using App.Core.Domain;
using App.Core.Infrastructure;
using Dapper;

namespace App.Data {
    public partial class DapperRepository<T> : IRepository<T> where T : BaseEntity {

        private readonly IDbContext _context;

        public DapperRepository(IDbContext context) {
            this._context = context;
        }

        public virtual T GetById(object id) {
            T item = default(T);
            //using (IDbConnection cn = _context.Connection()) {
            //    cn.Open();

            //    item = cn.Get<T>(id);
            //}
            return item;
        }

        public void Insert(T entity) {
            //using (IDbConnection cn = _context.Connection()) {
            //    cn.Open();
            //    cn.Insert(entity);
            //}
        }

        public void Update(T entity) {
            //using (IDbConnection cn = _context.Connection()) {
            //    cn.Open();
            //    cn.Update(entity);
            //}
        }
        public void Delete(T entity) {
            //using (IDbConnection cn = _context.Connection()) {
            //    cn.Open();
            //    cn.Delete(entity);
            //}
        }
        public IQueryable<T> Table {
            get {
                IEnumerable<T> items = null;

                //using (IDbConnection cn = _context.Connection()) {
                //    cn.Open();
                //    items = cn.GetList<T>();
                //}

                return items.AsQueryable();
            }
        }

        public IQueryable<T> TableNoTracking { get; private set; }

        public void Insert(IEnumerable<T> entities) {
            //throw new NotImplementedException();
        }
        public void Update(IEnumerable<T> entities) {
            //throw new NotImplementedException();
        }
        public void Delete(IEnumerable<T> entities) {
            //throw new NotImplementedException();
        }

    }



}
