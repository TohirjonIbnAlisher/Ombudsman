using Microsoft.EntityFrameworkCore;
using Ombudsman.DataAccessLayer.DBContext;

namespace Ombudsman.DataAccessLayer.Repositories.Bases;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> 
    where TEntity : class
{
    protected readonly OmbudsmanDBContext ombudsmanDBContext;

    public RepositoryBase(OmbudsmanDBContext ombudsmanDBContext)
    {
        this.ombudsmanDBContext = ombudsmanDBContext;
    }

    public IQueryable<TEntity> SelectAllEntity(string[] includes)
    {
        var allEntities = this.ombudsmanDBContext.Set<TEntity>().AsNoTracking();

        foreach(var include in includes)
        {
            allEntities = allEntities.Include(include);
        }

        return allEntities;
    }
}
