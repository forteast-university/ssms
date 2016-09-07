// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-19-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-19-2016
// ***********************************************************************
// <copyright file="DropCreateCeDatabaseAlways.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Entity;

namespace App.Data.Initializers
{
    /// <summary>
    /// An implementation of IDatabaseInitializer that will always recreate and optionally re-seed the
    /// database the first time that a context is used in the app domain.
    /// To seed the database, create a derived class and override the Seed method.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public class DropCreateCeDatabaseAlways<TContext> : SqlCeInitializer<TContext> where TContext : DbContext
    {
        #region Strategy implementation

        /// <summary>
        /// Executes the strategy to initialize the database for the given context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var replacedContext = ReplaceSqlCeConnection(context);

            if (replacedContext.Database.Exists())
            {
                replacedContext.Database.Delete();
            }
            context.Database.Create();
            Seed(context);
            context.SaveChanges();
        }

        #endregion

        #region Seeding methods

        /// <summary>
        /// A that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected virtual void Seed(TContext context)
        {
        }

        #endregion
    }
}
