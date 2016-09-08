// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="SpHelper.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace App.Data {
    /// <summary>
    /// Class SpHelper.
    /// </summary>
    public class SpHelper {

        /// <summary>
        /// The list
        /// </summary>
        private readonly List<SqlParameter> list;
        /// <summary>
        /// Initializes a new instance of the <see cref="SpHelper"/> class.
        /// </summary>
        public SpHelper(List<SqlParameter> sqlParameters = null)
        {
            list = sqlParameters ?? new List<SqlParameter>();
        }

        /// <summary>
        /// SqlParameter the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="size">The size.</param>
        /// <param name="isout">if set to <c>true</c> [isout].</param>
        /// <returns>SqlParameter.</returns>
        public SpHelper Add<T>(string name, T value, int size = -1, bool isout = false) {
            var stype = SqlDbType.Structured;
            var k = typeof(T);
            if(k == typeof(int)) {
                stype = SqlDbType.Int;
            } else if(k == typeof(string)) {
                stype = SqlDbType.NVarChar;
            } else if(k == typeof(float)) {
                stype = SqlDbType.Float;
            } else if(k == typeof(bool)) {
                stype = SqlDbType.Bit;
            } else if(k == typeof(DateTime)) {
                stype = SqlDbType.Date;
            } else if(k == typeof(decimal)) {
                stype = SqlDbType.Decimal;
            }
            var m = new SqlParameter { ParameterName = name, SqlDbType = stype };
            if(value != null)
                m.Value = value;
            if(size != -1)
                m.Size = size;
            if(isout)
                m.Direction = ParameterDirection.Output;
            list.Add(m);
            return this;
        }
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public object[] GetObject(){
            var a = new object[list.Count];
            for (var i = 0; i < list.Count; i++){
                a[i] = list.ElementAt(i);
            }
            return a;
        }
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>SqlParameter.</returns>
        public SqlParameter GetParam(string name){
            return list.FirstOrDefault(a => a.ParameterName == name);
        }
        /// <summary>
        /// Calls the store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>System.String.</returns>
        public string ToSpString(string store) {
            return "exec "+store + " "+ ToString();
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() {
            var l = (from SqlParameter a in list select "@" + a.ParameterName + ((a.Direction == ParameterDirection.Output) ? " OUT" : "")).ToList();
            var combinedString = String.Join(",", l);
            return combinedString;
        }
    }
}
