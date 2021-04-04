using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodingAssignment.Services.Repositories {
    /// <summary>
    /// Simple Generic interface that helps implement a simple repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T:class {
        /// <summary>
        /// Method returns all the records of a db set takes optional navigation properties for getting nested objects
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns>List of all the records of a database entity.</returns>
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Method takes a func delegate as filter condition and navigation properties for getting nested objects 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns>List of <T> Object depending on the where condition provided</returns>
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Method takes a func delegate as filter condition and navigation properties for getting nested objects 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns>Single Object depending on the where condition provided</returns>
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
       
        /// <summary>
        /// method takes one of more entities and adds them to database
        /// </summary>
        /// <param name="items"></param>
        void Create(params T[] items);

        /// <summary>
        /// method takes one of more entities and updates them in database
        /// </summary>
        /// <param name="items"></param>
        void Update(params T[] items);
       
        /// <summary>
        /// method takes one of more entities and removes them from database
        /// </summary>
        /// <param name="items"></param>
        void Remove(params T[] items);
    }
}
