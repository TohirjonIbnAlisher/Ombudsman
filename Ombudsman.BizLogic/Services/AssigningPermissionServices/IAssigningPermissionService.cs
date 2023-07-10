using Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;

namespace Ombudsman.BizLogic.Services.AssigningPermissionServices;

public interface IAssigningPermissionService
{
    ValueTask<GetAssigningPermissionWithDetailDTO> CreateAssigningPermissionAsync(
       CreationAssigningPermissionDTO creationAssigningPermissionDTO);

    IQueryable<GetAssigningPermissionDTO> RetrieveAssigningPermissions();

    ValueTask<GetAssigningPermissionWithDetailDTO> RetrieveAssigningPermissionByIdAsync(int id);

    ValueTask<GetAssigningPermissionWithDetailDTO> ModifyAssigningPermissionAsync(
        int id,
        ModifyAssigningPermissionDTO modifyAssigningPermissionDTO);

    ValueTask<GetAssigningPermissionWithDetailDTO> RemoveAssigningPermissionAsync(int id);
    CreationAssigningPermissionDTO RetrieveAsync();
}
