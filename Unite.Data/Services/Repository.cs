using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Unite.Data.Services
{
    public abstract class Repository<T>
        where T : class, new()
    {
        protected readonly DbContext _database;


        protected DbSet<T> Entities => _database.Set<T>();


        protected Repository(DbContext database)
        {
            _database = database;
        }


        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            var query = Entities.AsQueryable();

            query = Include(query);

            var entity = query.FirstOrDefault(predicate);

            return entity;
        }

        public virtual T Add(in T model)
        {
            var entity = Entities.Add(model).Entity;

            _database.SaveChanges();

            return entity;
        }

        public virtual void AddRange(in IEnumerable<T> models)
        {
            Entities.AddRange(models);

            _database.SaveChanges();
        }

        public virtual void Update(ref T entity, in T model)
        {
            Map(model, ref entity);

            entity = Entities.Update(entity).Entity;

            _database.SaveChanges();
        }

        public virtual void Delete(ref T entity)
        {
            Entities.Remove(entity);

            _database.SaveChanges();
        }

        public virtual void DeleteRange(ref IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);

            _database.SaveChanges();
        }

        public virtual void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            var query = Entities.AsQueryable();

            query = Include(query);

            var entities = query.Where(predicate);

            Entities.RemoveRange(entities);

            _database.SaveChanges();
        }


        protected virtual IQueryable<T> Include(IQueryable<T> query)
        {
            return query;
        }

        protected abstract void Map(in T source, ref T target);
    }
}
