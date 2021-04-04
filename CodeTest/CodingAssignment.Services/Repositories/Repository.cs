using CodingAssignment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CodingAssignment.Services.Repositories {
    /// <summary>
    /// Internal Generic Implementation of a repository for db operations
    /// this implementation can be replaced with a mock one if required
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Repository<T> : IRepository<T> where T : class {

        private readonly AppDbContext _db;
        public Repository(AppDbContext db) {
            _db = db;
        }

        public virtual void Create(params T[] items) {
            using (var commit = _db.Database.BeginTransaction()) {
                try {
                    foreach (T item in items) {
                        _db.Entry(item).State = EntityState.Added;
                    }
                    _db.SaveChanges();
                    commit.Commit();
                }
                catch (Exception ex) {
                    commit.Rollback();
                    throw ex;
                }
            }
        }

        public virtual void Update(params T[] items) {
            using (var commit = _db.Database.BeginTransaction()) {
                try {
                    foreach (T item in items) {
                        _db.Entry(item).State = EntityState.Modified;
                    }
                    _db.SaveChanges();
                    commit.Commit();
                }
                catch (Exception ex) {
                    commit.Rollback();
                    throw ex;
                }
            }
        }

        public virtual void Remove(params T[] items) {
            using (var commit = _db.Database.BeginTransaction()) {
                try {
                    foreach (T item in items) {
                        _db.Entry(item).State = EntityState.Deleted;
                    }
                    _db.SaveChanges();
                    commit.Commit();
                }
                catch (Exception ex) {
                    commit.Rollback();
                    throw ex;
                }
            }
        }
       
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties) {
            List<T> list;
            IQueryable<T> dbQuery = _db.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<T>();

            return list;
        }

        public virtual IQueryable<T> GetAllQueryable(params Expression<Func<T, object>>[] navigationProperties) {
            IQueryable<T> dbQuery = _db.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            return dbQuery;
        }

        public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties) {
            List<T> list;
            IQueryable<T> dbQuery = _db.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<T>();
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties) {
            T item = null;
            IQueryable<T> dbQuery = _db.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery.AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause
            return item;
        }

    }
}
