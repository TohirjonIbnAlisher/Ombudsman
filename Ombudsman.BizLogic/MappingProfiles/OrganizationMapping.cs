using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.DataTransferObjects.OrganizationDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class OrganizationMapping : Profile
{
	public OrganizationMapping()
	{
		CreateMap<CreationOrganizationDTO, Organization>();
		CreateMap<ModifyOrganizationDTO, Organization>();
		CreateMap<Organization, GetOrganizationDTO>()
			.ForMember(getOrg => getOrg.District, org => org.MapFrom(o => o.District.FullName))
			.ForMember(getOrg => getOrg.OrganizationLevel, org => org.MapFrom(o => o.OrganizationLevel.FullName))
			.ForMember(getOrg => getOrg.OrganizationType, org => org.MapFrom(o => o.OrganizationType.FullName))
			.ForMember(getOrg => getOrg.ParentOrganizationName, org => org.MapFrom(o => o.ParentOrganization.Name))
			.ForMember(getOrg => getOrg.Region, org => org.MapFrom(o => o.Region.FullName))
			.ForMember(getOrg => getOrg.State, org => org.MapFrom(o => o.State.Name));

		CreateMap<Organization, GetOrganizationDetailsDTO>()
            .ForMember(getOrg => getOrg.District, org => org.MapFrom(o => o.District.FullName))
            .ForMember(getOrg => getOrg.OrganizationLevel, org => org.MapFrom(o => o.OrganizationLevel.FullName))
            .ForMember(getOrg => getOrg.OrganizationType, org => org.MapFrom(o => o.OrganizationType.FullName))
            .ForMember(getOrg => getOrg.ParentOrganizationName, org => org.MapFrom(o => o.ParentOrganization.Name))
            .ForMember(getOrg => getOrg.Region, org => org.MapFrom(o => o.Region.FullName))
            .ForMember(getOrg => getOrg.State, org => org.MapFrom(o => o.State.Name));
    }
}
