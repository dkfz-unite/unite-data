using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Unite.Data.Services.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Query
        /// </summary>
        IQueryable<T> Entities { get; }


        /// <summary>
        /// Adds new entity to the database.
        /// </summary>
        /// <param name="model">Entity model to add</param>
        /// <returns>Newly created entity.</returns>
        T Add(in T model);

        /// <summary>
        /// Updates existing entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="model">Entity model to map updates from</param>
        void Update(ref T entity, in T model);

        /// <summary>
        /// Deletes existing entity from the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(ref T entity);


        /// <summary>
        /// Adds multiple new entities to the database.
        /// </summary>
        /// <param name="models">Entity models to add</param>
        IEnumerable<T> AddRange(in IEnumerable<T> models);

        /// <summary>
        /// Deletes multiple existing entities from the database.
        /// </summary>
        /// <param name="entities">Entities to delete</param>
        void DeleteRange(ref IEnumerable<T> entities);

        /// <summary>
        /// Deletes all entities from the database corresponding given search predicate.
        /// </summary>
        /// <param name="predicate">Predicate</param>
        void DeleteRange(Expression<Func<T, bool>> predicate);
    }
}
