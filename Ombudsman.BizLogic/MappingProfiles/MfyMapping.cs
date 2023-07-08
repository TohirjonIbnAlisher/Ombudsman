using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class MfyMapping : Profile
{
	public MfyMapping()
	{
        CreateMap<CreationMfyDTO, Mfy>();
        CreateMap<ModifyMfyDTO, Mfy>();
        CreateMap<Mfy, GetMfyDetailDTO>()
            .ForMember(distr => distr.Region, dis => dis.MapFrom(d => d.Region.FullName))
            .ForMember(distr => distr.District, dis => dis.MapFrom(d => d.District.FullName))
            .ForMember(distr => distr.State, dis => dis.MapFrom(d => d.State.Name));

        CreateMap<Mfy, GetMfyDTO>()
            .ForMember(distr => distr.Region, dis => dis.MapFrom(d => d.Region.FullName))
            .ForMember(distr => distr.District, dis => dis.MapFrom(d => d.District.FullName))
            .ForMember(distr => distr.State, dis => dis.MapFrom(d => d.State.Name));
    }
}
