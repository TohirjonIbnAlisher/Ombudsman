using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.ApplicationFormingTypes;

public class ApplicationFormingTypeRepository 
    : RepositoryBase<ApplicationFormingType>, IApplicationFormingTypeRepository
{
	public ApplicationFormingTypeRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
