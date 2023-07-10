using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.PermissionRoles;

namespace Ombudsman.BizLogic.Services.AssigningPermissionServices;

public class AssigningPermissionService : IAssigningPermissionService
{
    private readonly IPermissionRoleRepository _permissionRoleRepository;
    private readonly IMapper _mapper;

    public AssigningPermissionService(
        IPermissionRoleRepository permissionRoleRepository,
        IMapper mapper)
    {
        this._permissionRoleRepository = permissionRoleRepository;
        this._mapper = mapper;
    }

    public async ValueTask<GetAssigningPermissionWithDetailDTO> CreateAssigningPermissionAsync(
        CreationAssigningPermissionDTO creationAssigningPermissionDTO)
    {
        var mapped = this._mapper.Map<CreationAssigningPermissionDTO, PermissionRole>(creationAssigningPermissionDTO);

        var createdAssigningPermission = await this._permissionRoleRepository.CreateAsync(mapped);

        await this._permissionRoleRepository.SaveChangeAsync();

        return this._mapper.Map<PermissionRole, GetAssigningPermissionWithDetailDTO>(createdAssigningPermission);
    }

    public async ValueTask<GetAssigningPermissionWithDetailDTO> ModifyAssigningPermissionAsync(
        int id,
        ModifyAssigningPermissionDTO modifyAssigningPermissionDTO)
    {
        var retrivedById = await this._permissionRoleRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<PermissionRole>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyAssigningPermissionDTO, PermissionRole>(modifyAssigningPermissionDTO);
        mapped.Id = id;
        mapped.StateId = 2;
        var modifiedAssigningPermission = this._permissionRoleRepository.Update(mapped);

        await this._permissionRoleRepository.SaveChangeAsync();

        return this._mapper.Map<PermissionRole, GetAssigningPermissionWithDetailDTO>(modifiedAssigningPermission);
    }

    public async ValueTask<GetAssigningPermissionWithDetailDTO> RemoveAssigningPermissionAsync(int id)
    {
        var perRole = await this._permissionRoleRepository.SelectEntityByIdAsync(
            r => r.Id == id,
            new string[] { });

        ServiceValidation<PermissionRole>.CheckingEntityById(perRole);

        perRole.StateId = 2;
        var removedPerRole = this._permissionRoleRepository.Update(
            perRole);

        await this._permissionRoleRepository.SaveChangeAsync();

        return _mapper.Map<PermissionRole, GetAssigningPermissionWithDetailDTO>(perRole);
    }

    public CreationAssigningPermissionDTO RetrieveAsync()
    {
        return new CreationAssigningPermissionDTO();
    }

    public async ValueTask<GetAssigningPermissionWithDetailDTO> RetrieveAssigningPermissionByIdAsync(int id)
    {
        var retrivedById = await this._permissionRoleRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "State", "Role", "Permission" });

        ServiceValidation<PermissionRole>.CheckingEntityById(retrivedById);

        return _mapper.Map<PermissionRole, GetAssigningPermissionWithDetailDTO>(retrivedById);
    }

    public IQueryable<GetAssigningPermissionDTO> RetrieveAssigningPermissions()
    {
        var selectedList = this._permissionRoleRepository.SelectAllEntity(
            new string[] { "State", "Role","Permission" });

        return selectedList.Select(sel => _mapper.Map<PermissionRole, GetAssigningPermissionDTO>(sel));
    }
}
