using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Docs;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.Applications;

public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
{
	public ApplicationRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
