using System.Linq.Expressions;

namespace Ombudsman.DataAccessLayer.Repositories.Bases;

public interface IGenericRepository<TEntity> : IRepositoryBase<TEntity>
{
    ValueTask<IQueryable<TEntity>> GetByExpression(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);
    ValueTask<TEntity> CreateAsync(TEntity entity);
    TEntity Update(TEntity entity);

    ValueTask<TEntity> SelectEntityByIdAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);

    ValueTask SaveChangeAsync();
}
