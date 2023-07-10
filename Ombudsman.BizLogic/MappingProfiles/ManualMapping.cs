using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ManuallyDTOs;
using Ombudsman.DataAccessLayer.Models;
using Ombudsman.DataAccessLayer.Models.Enums;

namespace Ombudsman.BizLogic.MappingProfiles;

public class ManualMapping : Profile
{
	public ManualMapping()
	{
		CreateMap<ApplicantType, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));

		CreateMap<ApplicationForm, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<ApplicationFormingType, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<ApplicationType, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<BusinessSector, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<EmploymentType, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<OrganizationLevel, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<OrganizationType, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<ParameterType, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));
		
		CreateMap<State, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.Name));
		
		CreateMap<UnitOfMeasure, ManualDTO>()
			.ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));

        CreateMap<Role, ManualDTO>()
            .ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));

        CreateMap<Position, ManualDTO>()
            .ForMember(apT => apT.Name, ap => ap.MapFrom(a => a.FullName));

        CreateMap<Permission, ManualDTO>()
            .ForMember(apT => apT.Name, ap => ap.MapFrom(a => $"{a.PermissionRouteName} {a.PermissionInterfaceName}"));
    }
}
