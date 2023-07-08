using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.BizLogic.MappingProfiles;

public class UserAccountMapping : Profile
{
	public UserAccountMapping()
	{
		CreateMap<CreationUserAccountDTO, UserAccount>();
		CreateMap<ModifyUserAccountDTO, UserAccount>();
		CreateMap<UserAccount, GetUserAccountDetailsDTO>()
			.ForMember(getUser => getUser.Organization, user => user.MapFrom(u => u.Organization.Name))
			.ForMember(getUser => getUser.Role, user => user.MapFrom(u => u.Role.FullName))
			.ForMember(getUser => getUser.Position, user => user.MapFrom(u => u.Position.FullName))
			.ForMember(getUser => getUser.State, user => user.MapFrom(u => u.State.Name));
            
		CreateMap<UserAccount, GetUserAccountDTO>()
            .ForMember(getUser => getUser.Organization, user => user.MapFrom(u => u.Organization.Name))
            .ForMember(getUser => getUser.Role, user => user.MapFrom(u => u.Role.FullName))
            .ForMember(getUser => getUser.State, user => user.MapFrom(u => u.State.Name));
    }
}
