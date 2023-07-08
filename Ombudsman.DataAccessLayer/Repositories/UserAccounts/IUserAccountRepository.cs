using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.UserAccounts;

public interface IUserAccountRepository : IGenericRepository<UserAccount>
{
    ValueTask<bool> HasPermissionAsync(string username, string permission);
}
