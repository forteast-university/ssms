// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="DbContextExtensions.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.EntityClient;
using System.Linq;
using App.Core.Domain;

namespace App.Data 
{
    /// <summary>
    /// Class DbContextExtensions.
    /// </summary>
    public static class DbContextExtensions
    {
        #region Utilities

        /// <summary>
        /// Inners the get copy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="currentCopy">The current copy.</param>
        /// <param name="func">The function.</param>
        /// <returns>T.</returns>
        private static T InnerGetCopy<T>(IDbContext context, T currentCopy, Func<DbEntityEntry<T>, DbPropertyValues> func) where T : BaseEntity
        {
            //Get the database context
            DbContext dbContext = CastOrThrow(context);

            //Get the entity tracking object
            DbEntityEntry<T> entry = GetEntityOrReturnNull(currentCopy, dbContext);

            //The output 
            T output = null;

            //Try and get the values
            if (entry != null)
            {
                DbPropertyValues dbPropertyValues = func(entry);
                if (dbPropertyValues != null)
                {
                    output = dbPropertyValues.ToObject() as T;
                }
            }

            return output;
        }

        /// <summary>
        /// Gets the entity or return null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentCopy">The current copy.</param>
        /// <param name="dbContext">The db context.</param>
        /// <returns>DbEntityEntry&lt;T&gt;.</returns>
        private static DbEntityEntry<T> GetEntityOrReturnNull<T>(T currentCopy, DbContext dbContext) where T : BaseEntity
        {
            return dbContext.ChangeTracker.Entries<T>().FirstOrDefault(e => e.Entity == currentCopy);
        }

        /// <summary>
        /// Casts the or throw.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>DbContext.</returns>
        /// <exception cref="System.InvalidOperationException">Context does not support operation.</exception>
        private static DbContext CastOrThrow(IDbContext context)
        {
            var output = context as DbContext;

            if (output == null)
            {
                throw new InvalidOperationException("Context does not support operation.");
            }

            return output;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the original copy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="currentCopy">The current copy.</param>
        /// <returns>T.</returns>
        public static T LoadOriginalCopy<T>(this IDbContext context, T currentCopy) where T : BaseEntity
        {
            return InnerGetCopy(context, currentCopy, e => e.OriginalValues);
        }

        /// <summary>
        /// Loads the database copy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="currentCopy">The current copy.</param>
        /// <returns>T.</returns>
        public static T LoadDatabaseCopy<T>(this IDbContext context, T currentCopy) where T : BaseEntity
        {
            return InnerGetCopy(context, currentCopy, e => e.GetDatabaseValues());
        }

        /// <summary>
        /// Drop a plugin table
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="tableName">Table name</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// tableName
        /// </exception>
        public static void DropPluginTable(this DbContext context, string tableName)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (String.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            //drop the table
            if (context.Database.SqlQuery<int>("SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = {0}", tableName).Any<int>())
            {
                var dbScript = "DROP TABLE [" + tableName + "]";
                context.Database.ExecuteSqlCommand(dbScript);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Get table name of entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="context">Context</param>
        /// <returns>Table name</returns>
        public static string GetTableName<T>(this IDbContext context) where T : BaseEntity
        {
            //var tableName = typeof(T).Name;
            //return tableName;

            //this code works only with Entity Framework.
            //If you want to support other database, then use the code above (commented)

            var Apppter = ((IObjectContextAdapter)context).ObjectContext;
            var storageModel = (StoreItemCollection)Apppter.MetadataWorkspace.GetItemCollection(DataSpace.SSpace);
            var containers = storageModel.GetItems<EntityContainer>();
            var entitySetBase = containers.SelectMany(c => c.BaseEntitySets.Where(bes => bes.Name == typeof(T).Name)).First();

            // Here are variables that will hold table and schema name
            string tableName = entitySetBase.MetadataProperties.First(p => p.Name == "Table").Value.ToString();
            //string schemaName = productEntitySetBase.MetApptaProperties.First(p => p.Name == "Schema").Value.ToString();
            return tableName;
        }

        /// <summary>
        /// Get column maximum length
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="entityTypeName">Entity type name</param>
        /// <param name="columnName">Column name</param>
        /// <returns>Maximum length. Null if such rule does not exist</returns>
        public static int? GetColumnMaxLength(this IDbContext context, string entityTypeName, string columnName)
        {
            var rez = GetColumnsMaxLength(context, entityTypeName, columnName);
            return rez.ContainsKey(columnName) ? rez[columnName] as int? : null;
        }

        /// <summary>
        /// Get columns maximum length
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="entityTypeName">Entity type name</param>
        /// <param name="columnNames">Column names</param>
        /// <returns>IDictionary&lt;System.String, System.Int32&gt;.</returns>
        public static IDictionary<string, int> GetColumnsMaxLength(this IDbContext context, string entityTypeName, params string[] columnNames)
        {
            //original: http://stackoverflow.com/questions/5081109/entity-framework-4-0-automatically-truncate-trim-string-before-insert
           
            var entType = Type.GetType(entityTypeName);
            var Apppter = ((IObjectContextAdapter)context).ObjectContext;
            var metApptaWorkspace = Apppter.MetadataWorkspace;
            var q = from meta in metApptaWorkspace.GetItems(DataSpace.CSpace).Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                    from p in (meta as EntityType).Properties.Where(p => columnNames.Contains(p.Name) && p.TypeUsage.EdmType.Name == "String")
                    select p;

            int temp;

            var queryResult = q.Where(p =>
            {
                var match = p.DeclaringType.Name == entityTypeName;
                if (!match && entType != null)
                {
                    //Is a fully qualified name....
                    match = entType.Name == p.DeclaringType.Name;
                }

                return match;

            }).Select(sel => new {sel.Name, MaxLength = sel.TypeUsage.Facets["MaxLength"].Value}).Where(p=>Int32.TryParse(p.MaxLength.ToString(), out temp)).ToDictionary(p=>p.Name,p=>Convert.ToInt32(p.MaxLength));
            
            return queryResult;
        }

        /// <summary>
        /// Databases the name.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        public static string DbName(this IDbContext context)
        {
            var connection = ((IObjectContextAdapter)context).ObjectContext.Connection as EntityConnection;
            if(connection==null)
                return string.Empty;

            return connection.StoreConnection.Database; 
        }

        #endregion
    }
}