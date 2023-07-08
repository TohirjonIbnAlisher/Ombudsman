using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.ApplicationClassifacitaions;

public class ApplicationClassificationRepository 
    : GenericRepository<ApplicationClassification>, IApplicationClassificationRepository
{
	public ApplicationClassificationRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
