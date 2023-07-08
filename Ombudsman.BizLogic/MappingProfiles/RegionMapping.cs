using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.RegionDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class RegionMapping : Profile
{
    public RegionMapping()
    {
        CreateMap<CreationRegionDTO, Region>();
        CreateMap<ModifyRegionDTO, Region>();
        CreateMap<Region, GetRegionDetailsDTO>()
            .ForMember(regDto => regDto.State, reg => reg.MapFrom(r => r.State.Name));
        CreateMap<Region, GetRegionDTO>()
            .ForMember(regDto => regDto.State, reg => reg.MapFrom(r => r.State.Name));
    }
}
