using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.BusinessSectors;

public class BusinessSectorRepository : RepositoryBase<BusinessSector>, IBusinessSectorRepository
{
	public BusinessSectorRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
