using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.Permissions;

public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
{
	public PermissionRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
