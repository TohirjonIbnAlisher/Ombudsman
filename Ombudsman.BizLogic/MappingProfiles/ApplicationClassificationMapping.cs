using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class ApplicationClassificationMapping : Profile
{
	public ApplicationClassificationMapping()
	{
		CreateMap<CreationApplicationClassificationDTO, ApplicationClassification>();
		CreateMap<ModifyApplicationClassificationDTO, ApplicationClassification>();
        CreateMap<ApplicationClassification, GetApplicationClassificationDetailDTO>()
            .ForMember(gac => gac.ApplicationClassification, ac => ac.MapFrom(a => a.ParentApplicationClassification.FullName))
            .ForMember(gac => gac.Organization, ac => ac.MapFrom(a => a.Organization.Name))
            .ForMember(gac => gac.OrganizationLevel, ac => ac.MapFrom(a => a.OrganizationLevel.FullName))
            .ForMember(gac => gac.State, ac => ac.MapFrom(a => a.State.Name));
        CreateMap<ApplicationClassification, GetApplicationClassificationDTO>()
            .ForMember(gac => gac.ApplicationClassification, ac => ac.MapFrom(a => a.ParentApplicationClassification.FullName))
            .ForMember(gac => gac.State, ac => ac.MapFrom(a => a.State.Name));


    }
}
