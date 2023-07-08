using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.ApplicationTypes;

public class ApplicationTypeRepository 
	: RepositoryBase<ApplicationType>, IApplicationTypeRepository
{
	public ApplicationTypeRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
