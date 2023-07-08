using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;
using Ombudsman.BizLogic.Exceptions;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.UserAccounts;

namespace Ombudsman.BizLogic.Services.UserAccountservices;

public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository userAccountRepository;
    private readonly IMapper mapper;

    public UserAccountService(IUserAccountRepository userAccountRepository, IMapper mapper)
    {
        this.userAccountRepository = userAccountRepository;
        this.mapper = mapper;
    }

    public async ValueTask<GetUserAccountDetailsDTO> CreateUserAccountAsync(CreationUserAccountDTO creationUserAccountDTO)
    {
        var mapped = mapper.Map<CreationUserAccountDTO, UserAccount>(creationUserAccountDTO);

        var created = await this.userAccountRepository.CreateAsync(mapped);

        await this.userAccountRepository.SaveChangeAsync();

        return mapper.Map<GetUserAccountDetailsDTO>(created);
    }

    public async ValueTask<GetUserAccountDetailsDTO> ModifyUserAccountAsync(int id, ModifyUserAccountDTO modifyUserAccount)
    {
        var storageUserAccount = await this.userAccountRepository.SelectEntityByIdAsync(
            ua => ua.Id == id,
            new string[] {});

        ServiceValidation<UserAccount>.CheckingEntityById(storageUserAccount);

        var mapped = this.mapper.Map<ModifyUserAccountDTO, UserAccount>(modifyUserAccount);
        mapped.Id = id;
        mapped.StateId = 1;
        mapped.Password = storageUserAccount.Password;
        var modifiedUserAccount = this.userAccountRepository.Update(mapped);

        await this.userAccountRepository.SaveChangeAsync();

        return this.mapper.Map<UserAccount, GetUserAccountDetailsDTO>(modifiedUserAccount);
    }

    public async ValueTask<GetUserAccountDetailsDTO> RemoveUserAccountAsync(int id)
    {
        var userAccount = await this.userAccountRepository.SelectEntityByIdAsync(
            ua => ua.Id == id,
            new string[] { });

        ServiceValidation<UserAccount>.CheckingEntityById(userAccount);

        userAccount.StateId = 2;
        var removedUserAccount = this.userAccountRepository.Update(
            userAccount);

        await this.userAccountRepository.SaveChangeAsync();

        return mapper.Map<UserAccount, GetUserAccountDetailsDTO>(removedUserAccount);
    }

    public CreationUserAccountDTO RetrieveAsync()
    {
        return new CreationUserAccountDTO();
    }

    public async ValueTask<GetUserAccountDetailsDTO> RetrieveUserAccountByIdAsync(int id)
    {
        var retrivedById = await this.userAccountRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "Organization", "Position", "Role", "State" });

        ServiceValidation<UserAccount>.CheckingEntityById(retrivedById);

        return mapper.Map<UserAccount, GetUserAccountDetailsDTO>(retrivedById);
    }

    public IQueryable<GetUserAccountDTO> RetrieveUserAccounts()
    {
        var selectedList = this.userAccountRepository.SelectAllEntity(
            new string[] { "Organization", "Position", "Role", "State" });

        return selectedList.Select(userAccount => mapper.Map<UserAccount, GetUserAccountDTO>(userAccount));
    }
}
