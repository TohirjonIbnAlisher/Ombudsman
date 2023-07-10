using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.ApplicationClassificationParameters;

public class ApplicationClassificationParameterRepository : GenericRepository<ApplicationClassificationParameter>, IApplicationClassificationParameterRepository
{
	public ApplicationClassificationParameterRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
