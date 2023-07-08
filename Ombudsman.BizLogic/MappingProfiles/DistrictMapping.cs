using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.DistrictDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class DistrictMapping : Profile
{
	public DistrictMapping()
	{
		CreateMap<CreationDistrictDTO, District>();
		CreateMap<ModifyDistrictDTO, District>();
		CreateMap<District, GetDistrictDetailDTO>()
			.ForMember(distr => distr.Region, dis => dis.MapFrom(d => d.Region.FullName))
			.ForMember(distr => distr.State, dis => dis.MapFrom(d => d.State.Name));

		CreateMap<District, GetDistrictDTO>()
            .ForMember(distr => distr.Region, dis => dis.MapFrom(d => d.Region.FullName))
            .ForMember(distr => distr.State, dis => dis.MapFrom(d => d.State.Name));

    }
}
