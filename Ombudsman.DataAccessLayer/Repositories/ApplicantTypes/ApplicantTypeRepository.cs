using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.ApplicantTypes;

public class ApplicantTypeRepository : GenericRepository<ApplicantType>, IApplicantTypeRepository
{
	public ApplicantTypeRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
