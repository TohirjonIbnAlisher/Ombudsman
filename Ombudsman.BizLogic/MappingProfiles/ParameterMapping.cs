using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class ParameterMapping : Profile
{
	public ParameterMapping()
	{
		CreateMap<CreationDigNumParameterDTO, Parameter>();
        CreateMap<CreationSanaParameterDTO, Parameter>()
                .ForMember(getOrg => getOrg.InitialValueDate, org => org.MapFrom(o => DateOnly.Parse(o.InitialValueDate)))
                .ForMember(getOrg => getOrg.GreatestValueDate, org => org.MapFrom(o => DateOnly.Parse(o.GreatestValueDate)));
        
        CreateMap<CreationSpravochnikParameterDTO, Parameter>();
		CreateMap<CreationTellNumParameterDTO, Parameter>();

		CreateMap<Parameter, GetParameterDTO>()
                .ForMember(getOrg => getOrg.State, org => org.MapFrom(o => o.State.Name))
               .ForMember(getOrg => getOrg.ParameterType, org => org.MapFrom(o => o.ParameterType.FullName));

        
    }
}
