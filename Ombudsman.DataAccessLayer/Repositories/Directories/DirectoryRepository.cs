using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.Directories;

public class DirectoryRepository : RepositoryBase<SysTable>, IDirectoryRepository
{
	public DirectoryRepository(OmbudsmanDBContext ombudsmanDBContext)
		: base(ombudsmanDBContext)
	{

	}
}
