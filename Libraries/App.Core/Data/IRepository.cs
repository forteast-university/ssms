using System.Collections.Generic;
using System.Linq;
using App.Core.Domain;
using Dapper;

using System;

namespace App.Core.Data {
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T> where T : BaseEntity {

        T GetById(object id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        
        IQueryable<T> Table { get; }
        
        IQueryable<T> TableNoTracking { get; }

        //------------------------------------------

        //T GetById<T>(object id) where T : BaseEntity, new();
        //IEnumerable<T> GetWhere<T>(object filters) where T : BaseEntity, new();
        //IQueryable<T> Table<T>() where T : BaseEntity, new();
        //IEnumerable<TElement> SqlQuery<TElement>(string sql, DynamicParameters parameters = null);
        //void Insert<T>(T instance) where T : BaseEntity, new();
        //void Update<T>(T instance) where T : BaseEntity, new();
        //void Delete<T>(T instance) where T : BaseEntity, new();
        //void ExecuteSqlCommand(string sql, DynamicParameters parameters = null, bool doNotEnsureTransaction = false, int? timeout = null);
        //IEnumerable<T> ExecuteStoredProcedureList<T>(string commandText, DynamicParameters parameters = null) where T : BaseEntity, new();
        //Tuple<IEnumerable<T1>, IEnumerable<T2>> MultiResults<T1, T2>(string sql, DynamicParameters parameters = null);

    }
}
