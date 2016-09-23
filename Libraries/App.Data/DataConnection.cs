using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using App.Core.Domain;
using Dapper;

namespace App.Data {
    // move to IRespository in ICore
    //public partial interface IRepository {
    //    T GetById<T>(object id) where T : BaseEntity, new();
    //    IEnumerable<T> GetWhere<T>(object filters) where T : BaseEntity, new();
    //    IQueryable<T> Table<T>() where T : BaseEntity, new();
    //    IEnumerable<TElement> SqlQuery<TElement>(string sql, DynamicParameters parameters = null);
    //    void Insert<T>(T instance) where T : BaseEntity, new();
    //    void Update<T>(T instance) where T : BaseEntity, new();
    //    void Delete<T>(T instance) where T : BaseEntity, new();
    //    void ExecuteSqlCommand(string sql, DynamicParameters parameters = null, bool doNotEnsureTransaction = false, int? timeout = null);
    //    IEnumerable<T> ExecuteStoredProcedureList<T>(string commandText, DynamicParameters parameters = null) where T : BaseEntity, new();
    //    Tuple<IEnumerable<T1>, IEnumerable<T2>> MultiResults<T1, T2>(string sql, DynamicParameters parameters = null);
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DataConnection : IDisposable {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        private IDbConnection _connection;

        /// <summary>
        /// 
        /// </summary>
        protected IDbConnection Connection {
            get {
                if (_connection.State != ConnectionState.Open && _connection.State != ConnectionState.Connecting)
                    _connection.Open();

                return _connection;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public DataConnection(IDbConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// Close the connection if this is open
        /// </summary>
        public void Dispose() {
            if (_connection != null && _connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }

}
