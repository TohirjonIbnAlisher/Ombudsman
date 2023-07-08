using Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;

namespace Ombudsman.BizLogic.Services.UserAccountservices;

public interface IUserAccountService
{
    ValueTask<GetUserAccountDetailsDTO> CreateUserAccountAsync(
        CreationUserAccountDTO creationUserAccountDTO);

    IQueryable<GetUserAccountDTO> RetrieveUserAccounts();

    ValueTask<GetUserAccountDetailsDTO> RetrieveUserAccountByIdAsync(int id);

    ValueTask<GetUserAccountDetailsDTO> ModifyUserAccountAsync(int id, ModifyUserAccountDTO modifyCountryDTO);

    ValueTask<GetUserAccountDetailsDTO> RemoveUserAccountAsync(int id);
    CreationUserAccountDTO RetrieveAsync();
}
