using GuestSide.Core.Data;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace GuestSide.Infrastructure.Repositories.AbstractRepository
{
    public abstract class GenericRepository<T>(GuestSideDb context) : IGenericRepository<T> where T : class
    {
        protected readonly GuestSideDb Context = context ?? throw new ArgumentNullException(nameof(context));
        protected readonly DbSet<T> DbSet = context.Set<T>();

        #region GetAllAsync
        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }
        #endregion

        public virtual async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await DbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            return entity;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                await DbSet.AddAsync(entity, cancellationToken);
            }

            if ((await Context.SaveChangesAsync(cancellationToken)) > 0)
            {
                return entity;
            }
            return null;
        }

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            if ((await Context.SaveChangesAsync(cancellationToken)) > 0)
            {
                return entity;
            }
            return null;
        }

        public virtual async Task<T> DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entityToDelete = await DbSet.FindAsync(id, cancellationToken);
 
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            await Delete(entityToDelete);
            if ((await Context.SaveChangesAsync(cancellationToken)) > 0)
            {
                return entityToDelete;
            }
            return null;
        }

        public async virtual Task<T> Delete(T entityToDelete, CancellationToken cancellationToken = default)
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

            if ((await Context.SaveChangesAsync(cancellationToken)) > 0)
            {
                return entityToDelete;
            }
            return null;
        }
    }
}
