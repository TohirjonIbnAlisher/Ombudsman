using Microsoft.EntityFrameworkCore;
using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.UserAccounts;

public class UserAccountRepository : GenericRepository<UserAccount>, IUserAccountRepository
{
    private readonly OmbudsmanDBContext _dbContext;
    public UserAccountRepository(OmbudsmanDBContext ombudsmanDBContext)
        : base(ombudsmanDBContext)
    {
        _dbContext = ombudsmanDBContext;
    }

    public async ValueTask<bool> HasPermissionAsync(string username, string permission)
    {
        var query = from i in _dbContext.UserAccounts
                    join r in _dbContext.Roles on i.RoleId equals r.Id
                    join rp in _dbContext.PermissionRoles on r.Id equals rp.RoleId
                    join p in _dbContext.Permission on rp.PermissionId equals p.Id
                    where i.Login == username && p.PermissionName == permission
                    select new { Id = p.Id, PermissionName = p.PermissionName };

        var storagePermission = await query.Distinct().ToListAsync();

        return storagePermission.Any();
    }
}
