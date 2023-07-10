using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;
using Ombudsman.DataAccessLayer.Models.Docs;

namespace Ombudsman.BizLogic.MappingProfiles;

public class ApplicationParameterMapping : Profile
{
	public ApplicationParameterMapping()
	{
		CreateMap<CreationApplicationParameterDTO, AppilcationParam>();
		CreateMap<ModifyApplicationParameterDTO, AppilcationParam>();
		CreateMap<AppilcationParam, GetApplicationParameterDTO>()
            .ForMember(gac => gac.Param, ac => ac.MapFrom(a => a.Parameter.FullName))
            .ForMember(gac => gac.Doc, ac => ac.MapFrom(a => a.Application.DocNumber))
;

    }
}
