namespace Ombudsman.DataAccessLayer.Repositories.Bases;

public interface IRepositoryBase<TEntity>
{
    IQueryable<TEntity> SelectAllEntity(string[] includes);
}
