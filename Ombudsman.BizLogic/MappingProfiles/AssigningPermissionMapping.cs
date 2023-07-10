using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class AssigningPermissionMapping : Profile
{
	public AssigningPermissionMapping()
	{
        CreateMap<CreationAssigningPermissionDTO, PermissionRole>();
        CreateMap<ModifyAssigningPermissionDTO, PermissionRole>();
        CreateMap<PermissionRole, GetAssigningPermissionWithDetailDTO>()
            .ForMember(gac => gac.Permission, ac => ac.MapFrom(a => $"{a.Permission.PermissionInterfaceName} {a.Permission.PermissionRouteName}"))
            .ForMember(gac => gac.State, ac => ac.MapFrom(a => a.State.Name))
            .ForMember(gac => gac.Role, ac => ac.MapFrom(a => a.Role.FullName));
           
        CreateMap<PermissionRole, GetAssigningPermissionDTO>()
            .ForMember(gac => gac.Permission, ac => ac.MapFrom(a => $"{a.Permission.PermissionInterfaceName} {a.Permission.PermissionRouteName}"))
            .ForMember(gac => gac.Role, ac => ac.MapFrom(a => a.Role.FullName))
            .ForMember(gac => gac.State, ac => ac.MapFrom(a => a.State.Name));
    }
}
