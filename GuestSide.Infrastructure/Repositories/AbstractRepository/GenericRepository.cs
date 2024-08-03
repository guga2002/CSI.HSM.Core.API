using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GuestSide.Infrastructure.Repositories.AbstractRepository
{
    public abstract class GenericRepository<T>(DbContext context) : IGenericRepository<T> where T : class
    {
        protected readonly DbContext Context = context ?? throw new ArgumentNullException(nameof(context));
        protected readonly DbSet<T> DbSet = context.Set<T>();

        #region GetAllAsync

        #endregion
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            return entity;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await DbSet.AddAsync(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entityToDelete = await DbSet.FindAsync(id);
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            await Delete(entityToDelete);
            return await Context.SaveChangesAsync() > 0;
        }

        public async virtual Task<bool> Delete(T entityToDelete)
        {
            if (entityToDelete == null)
            {
                throw new ArgumentNullException(nameof(entityToDelete));
            }

            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}
