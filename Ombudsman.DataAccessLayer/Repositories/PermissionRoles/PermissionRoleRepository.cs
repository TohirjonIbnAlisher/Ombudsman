using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.PermissionRoles;

public class PermissionRoleRepository : GenericRepository<PermissionRole>, IPermissionRoleRepository
{
    public PermissionRoleRepository(OmbudsmanDBContext ombudsmanDBContext)
        : base(ombudsmanDBContext)
    {
    }
}
