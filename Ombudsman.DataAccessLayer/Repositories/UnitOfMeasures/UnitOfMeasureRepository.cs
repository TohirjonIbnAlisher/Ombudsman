using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.UnitOfMeasures;

public class UnitOfMeasureRepository : RepositoryBase<UnitOfMeasure>, IUnitOfMeasureRepository
{
	public UnitOfMeasureRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
