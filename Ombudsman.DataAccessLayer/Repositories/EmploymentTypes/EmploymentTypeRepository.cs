using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.EmploymentTypes;

public class EmploymentTypeRepository : RepositoryBase<EmploymentType>, IEmploymentTypeRepository
{
	public EmploymentTypeRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
