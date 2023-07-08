using Microsoft.EntityFrameworkCore;
using Ombudsman.DataAccessLayer.DBContext;
using System.Linq.Expressions;

namespace Ombudsman.DataAccessLayer.Repositories.Bases;

public class GenericRepository<TEntity> : RepositoryBase<TEntity>, IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly OmbudsmanDBContext ombudsmanDBContext;

    public GenericRepository(OmbudsmanDBContext ombudsmanDBContext)
        : base(ombudsmanDBContext)
    {
        this.ombudsmanDBContext = ombudsmanDBContext;
    }

    public async ValueTask<TEntity> CreateAsync(TEntity entity)
    {
        var addedEntity = await this.ombudsmanDBContext.AddAsync(entity);
        return addedEntity.Entity;
    }
    public async ValueTask<IQueryable<TEntity>> GetByExpression(
        Expression<Func<TEntity, bool>> expression, string[] includes)
    {
        var entities = this.ombudsmanDBContext
            .Set<TEntity>()
            .Where(expression).AsNoTracking();

        return entities;
    }

    public async ValueTask<TEntity> SelectEntityByIdAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes)
    {
        var selectedEntityById = this.ombudsmanDBContext.Set<TEntity>().AsNoTracking();

        foreach (var include in includes)
        {
            selectedEntityById = selectedEntityById.Include(include);
        }

        return await selectedEntityById.FirstOrDefaultAsync(expression);
    }

    public TEntity Update(TEntity entity)
    {
        var updatedEntity = this.ombudsmanDBContext.Update(entity);
        

        return updatedEntity.Entity;
    }

    public async ValueTask SaveChangeAsync()
    {
        await this.ombudsmanDBContext.SaveChangesAsync();
    }
}

