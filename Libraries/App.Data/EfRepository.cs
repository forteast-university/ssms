// ***********************************************************************
// Assembly         : App.Data
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="EfRepository.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using App.Core.Data;
using App.Core.Domain;
using Dapper;

namespace App.Data {
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity {
        #region Fields

        /// <summary>
        /// The context
        /// </summary>
        private readonly IDbContext context;
        /// <summary>
        /// The entities
        /// </summary>
        private IDbSet<T> entities;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context) {
            this.context = context;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(DbEntityValidationException exc) {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id) {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return this.Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void Insert(T entity) {
            try {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);

                context.SaveChanges();
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <exception cref="System.ArgumentNullException">entities</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void Insert(IEnumerable<T> entities) {
            try {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Add(entity);

                context.SaveChanges();
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void Update(T entity) {
            try {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                context.SaveChanges();
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void AddOrUpdate(T entity) {
            try {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.Entities.AddOrUpdate(entity);
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <exception cref="System.ArgumentNullException">entities</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void Update(IEnumerable<T> entities) {
            try {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                context.SaveChanges();
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void Delete(T entity) {
            try {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);

                context.SaveChanges();
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <exception cref="System.ArgumentNullException">entities</exception>
        /// <exception cref="System.Exception"></exception>
        public virtual void Delete(IEnumerable<T> entities) {
            try {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Remove(entity);

                context.SaveChanges();
            } catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        /// <value>The table.</value>
        public virtual IQueryable<T> Table {
            get {
                return Entities;
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        /// <value>The table no tracking.</value>
        public virtual IQueryable<T> TableNoTracking {
            get {
                return Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        /// <value>The entities.</value>
        protected virtual IDbSet<T> Entities {
            get {
                if (entities == null)
                    entities = context.Set<T>();
                return entities;
            }
        }

        #endregion

       


    }
}