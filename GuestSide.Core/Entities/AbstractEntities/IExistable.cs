using System.Linq.Expressions;

namespace Core.Core.Entities.AbstractEntities
{
    public interface IExistable<TEntity>
    {
        Expression<Func<TEntity, bool>> GetExistencePredicate();
    }
}
