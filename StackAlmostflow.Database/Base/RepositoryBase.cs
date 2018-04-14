using StackAlmostflow.Database.Common.Interfaces;
using StackAlmostflow.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StackAlmostflow.Database.Common.Base
{
    public abstract class RepositoryBase<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new() 
        where TDbContext : DbContext
    {
        protected RepositoryBase(IDbContextFactory<TDbContext> contextFactory)
        {
            DbContextFactory = contextFactory;
        }

        public virtual TEntity GetById(long id)
        {
            return Set.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public TEntity Create()
        {
            var entity = Set.Create();
            if (entity is IObservableEntity)
            {
                (entity as IObservableEntity).CreatedAt = DateTime.UtcNow;
                (entity as IObservableEntity).UpdatedAt = DateTime.UtcNow;
            }

            if (entity is IRemovableEntity)
                (entity as IRemovableEntity).IsRemoved = false;
            return entity;
        }

        public TEntity Attach(long id)
        {
            return Attach(new TEntity { Id = id });
        }

        public TEntity Attach(TEntity entity)
        {
            var entry = Set.Local.FirstOrDefault(x => x.Id == entity.Id) ??
                        Set.Attach(entity);
            return entry;
        }

        public IEnumerable<TEntity> Attach(IEnumerable<TEntity> entities)
        {
            return entities.Select(Attach).ToArray();
        }

        public TEntity Add(TEntity entity)
        {
            if (entity is IObservableEntity)
            {
                (entity as IObservableEntity).CreatedAt = DateTime.UtcNow;
                (entity as IObservableEntity).UpdatedAt = DateTime.UtcNow;
            }

            if (entity is IRemovableEntity)
                (entity as IRemovableEntity).IsRemoved = false;

            return Set.Add(entity);
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is IObservableEntity)
                {
                    (entity as IObservableEntity).CreatedAt = DateTime.UtcNow;
                    (entity as IObservableEntity).UpdatedAt = DateTime.UtcNow;
                }

                if (entity is IRemovableEntity)
                    (entity as IRemovableEntity).IsRemoved = false;

            }
            return Set.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            if (entity is IObservableEntity)
                (entity as IObservableEntity).UpdatedAt = DateTime.UtcNow;

            Attach(entity);
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is IObservableEntity)
                    (entity as IObservableEntity).UpdatedAt = DateTime.UtcNow;

            }

            return entities.Select(Update).ToArray();
        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            return entity.Id == 0 ? Add(entity) : Update(entity);
        }

        public IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities)
        {
            return entities.Select(AddOrUpdate).ToArray();
        }

        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry(TEntity entity)
        {
            return DbContext.Entry(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity is IRemovableEntity)
            {
                (entity as IRemovableEntity).IsRemoved = true;
                return entity;
            }
            else
                return Set.Remove(entity);
        }

        public TEntity Delete(long id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                entity = Delete(entity);

            return entity;
        }

        public IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities)
        {
            return entities.Select(Delete).ToArray();
        }

        public IQueryable<TEntity> Query()
        {
            return Set;
        }


        protected DbSet<TEntity> Set => DbContext.Set<TEntity>();
        protected DbContext DbContext => DbContextFactory.GetDbContext();
        protected IDbContextFactory<TDbContext> DbContextFactory { get; }
    }
}
