using System.Linq.Expressions;

namespace Domain.Core.Entities.AbstractEntities;

public interface IExistable<TEntity>
{
    Expression<Func<TEntity, bool>> GetExistencePredicate();
}
