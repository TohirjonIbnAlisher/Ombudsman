using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.OrganizationLevels;

public class OrganizationLevelRepository 
    : RepositoryBase<OrganizationLevel>, IOrganizationLevelRepository
{
	public OrganizationLevelRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
