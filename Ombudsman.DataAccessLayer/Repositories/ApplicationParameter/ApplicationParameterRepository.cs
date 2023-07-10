using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Models.Docs;
using Ombudsman.DataAccessLayer.Repositories.Bases;

namespace Ombudsman.DataAccessLayer.Repositories.ApplicationParameter;

public class ApplicationParameterRepository : GenericRepository<AppilcationParam>, IApplicationParameterRepository
{
    public ApplicationParameterRepository(OmbudsmanDBContext ombudsmanDBContext) : base(ombudsmanDBContext)
    {
    }
}
