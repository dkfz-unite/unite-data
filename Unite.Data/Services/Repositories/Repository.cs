using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Unite.Data.Services.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, new()
    {
        protected readonly DbContext _dbContext;

        protected DbSet<T> Set => _dbContext.Set<T>();

        public IQueryable<T> Entities => Set.AsQueryable();


        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual T Add(in T model)
        {
            var entity = new T();

            Map(model, ref entity);

            entity = Set.Add(entity).Entity;

            _dbContext.SaveChanges();

            return entity;
        }

        public virtual void Update(ref T entity, in T model)
        {
            Map(model, ref entity);

            entity = Set.Update(entity).Entity;

            _dbContext.SaveChanges();
        }

        public virtual void Delete(ref T entity)
        {
            Set.Remove(entity);

            _dbContext.SaveChanges();
        }


        public virtual IEnumerable<T> AddRange(in IEnumerable<T> models)
        {
            var entities = models.Select(model =>
            {
                var entity = new T();

                Map(model, ref entity);

                return entity;

            }).ToArray();

            Set.AddRange(entities);

            _dbContext.SaveChanges();

            return entities;
        }

        public virtual void DeleteRange(ref IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);

            _dbContext.SaveChanges();
        }

        public virtual void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            var entities = Entities.Where(predicate);

            Set.RemoveRange(entities);

            _dbContext.SaveChanges();
        }


        protected abstract void Map(in T source, ref T target);
    }
}
