using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class AppClassParamMapping : Profile
{
	public AppClassParamMapping()
	{
		CreateMap<CreateAppClassParamDTO, ApplicationClassificationParameter>();
		CreateMap<ModifyAppClassParamDTO, ApplicationClassificationParameter>();
		CreateMap< ApplicationClassificationParameter,GetAppClassParamDTO>();
	}
}
