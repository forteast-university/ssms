// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-19-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-19-2016
// ***********************************************************************
// <copyright file="SqlCeInitializer.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using System.Data.SqlServerCe;
using System.IO;

namespace App.Data.Initializers
{
    /// <summary>
    /// Class SqlCeInitializer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>odcup.com</remarks>
    public abstract class SqlCeInitializer<T> : IDatabaseInitializer<T> where T : DbContext
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="context">The context.</param>
        public abstract void InitializeDatabase(T context);

        #region Helpers

        /// <summary>
        /// Returns a new DbContext with the same SqlCe connection string, but with the |DataDirectory| expanded
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>DbContext.</returns>
        protected static DbContext ReplaceSqlCeConnection(DbContext context)
        {
            if (context.Database.Connection is SqlCeConnection)
            {
                var builder = new SqlCeConnectionStringBuilder(context.Database.Connection.ConnectionString);
                if (!String.IsNullOrWhiteSpace(builder.DataSource))
                {
                    builder.DataSource = ReplaceDataDirectory(builder.DataSource);
                    return new DbContext(builder.ConnectionString);
                }
            }
            return context;
        }

        /// <summary>
        /// Replaces the data directory.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>System.String.</returns>
        private static string ReplaceDataDirectory(string inputString)
        {
            string str = inputString.Trim();
            if (string.IsNullOrEmpty(inputString) || !inputString.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
            {
                return str;
            }
            var data = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (string.IsNullOrEmpty(data))
            {
                data = AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory;
            }
            if (string.IsNullOrEmpty(data))
            {
                data = string.Empty;
            }
            int length = "|DataDirectory|".Length;
            if ((inputString.Length > "|DataDirectory|".Length) && ('\\' == inputString["|DataDirectory|".Length]))
            {
                length++;
            }
            return Path.Combine(data, inputString.Substring(length));
        }

        #endregion
    }

}
