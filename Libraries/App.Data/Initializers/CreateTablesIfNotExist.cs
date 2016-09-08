// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="CreateTablesIfNotExist.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;

namespace App.Data.Initializers
{
    /// <summary>
    /// Class CreateTablesIfNotExist.
    /// </summary>
    /// <typeparam name="TContext">The type of the t context.</typeparam>
    public class CreateTablesIfNotExist<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        /// <summary>
        /// The tables to validate
        /// </summary>
        private readonly string[] tablesToValidate;
        /// <summary>
        /// The custom commands
        /// </summary>
        private readonly string[] customCommands;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="tablesToValidate">A list of existing table names to validate; null to don't validate table names</param>
        /// <param name="customCommands">A list of custom commands to execute</param>
        public CreateTablesIfNotExist(string[] tablesToValidate, string [] customCommands)
        {
            this.tablesToValidate = tablesToValidate;
            this.customCommands = customCommands;
        }
        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ApplicationException">No database instance</exception>
        public void InitializeDatabase(TContext context)
        {
            bool dbExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                dbExists = context.Database.Exists();
            }
            if (dbExists)
            {
                bool createTables;
                if (tablesToValidate != null && tablesToValidate.Length > 0)
                {
                    //we have some table names to validate
                    var existingTableNames = new List<string>(context.Database.SqlQuery<string>("SELECT table_name FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE'"));
                    createTables = !existingTableNames.Intersect(tablesToValidate, StringComparer.InvariantCultureIgnoreCase).Any();
                }
                else
                {
                    //check whether tables are already created
                    int numberOfTables = 0;
                    foreach (var t1 in context.Database.SqlQuery<int>("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE' "))
                        numberOfTables = t1;

                    createTables = numberOfTables == 0;
                }

                if (createTables)
                {
                    //create all tables
                    var dbCreationScript = ((IObjectContextAdapter
                        )context).ObjectContext.CreateDatabaseScript();
                    context.Database.ExecuteSqlCommand(dbCreationScript);

                    //Seed(context);
                    context.SaveChanges();

                    if (customCommands != null && customCommands.Length > 0)
                    {
                        foreach (var command in customCommands)
                            context.Database.ExecuteSqlCommand(command);
                    }
                }
            }
            else
            {
                throw new ApplicationException("No database instance");
            }
        }
    }
}
