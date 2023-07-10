using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationDTOs;
using Ombudsman.DataAccessLayer.Models.Docs;

namespace Ombudsman.BizLogic.MappingProfiles;

public class ApplicationMapping : Profile
{
	public ApplicationMapping()
	{
        CreateMap<CreateApplicationDTO, Application>()
            .ForMember(gac => gac.DocDate, ac => ac.MapFrom(a => DateOnly.Parse(a.DocDate)));

		CreateMap<ModifyApplicationDTO, Application>()
            .ForMember(gac => gac.DocDate, ac => ac.MapFrom(a => DateOnly.Parse(a.DocDate)));

		CreateMap<Application, GetApplicationDTO>()
            .ForMember(gac => gac.BusinessSector, ac => ac.MapFrom(a => a.BusinessSector.FullName))
            .ForMember(gac => gac.ApplicationType, ac => ac.MapFrom(a => a.ApplicationType.FullName))
            .ForMember(gac => gac.BaseApplicationClassification, ac => ac.MapFrom(a => a.BaseApplicationClassification.FullName))
            .ForMember(gac => gac.ApplicationClassification3, ac => ac.MapFrom(a => a.ApplicationClassification3.FullName))
            .ForMember(gac => gac.ApplicationClassification4, ac => ac.MapFrom(a => a.ApplicationClassification4.FullName))
            .ForMember(gac => gac.ApplicationClassification2, ac => ac.MapFrom(a => a.ApplicationClassification2.FullName));
    }
}
