using Ombudsman.BizLogic.DataTransferObjects;

namespace Ombudsman.BizLogic.Services.MfyServices;

public interface IMfyService
{
    ValueTask<GetMfyDetailDTO> CreateMfyAsync(
       CreationMfyDTO creationMfyDTO);

    IQueryable<GetMfyDTO> RetrieveMfys();

    ValueTask<GetMfyDetailDTO> RetrieveMfyByIdAsync(int id);

    ValueTask<GetMfyDetailDTO> ModifyMfyAsync(
        int id,
        ModifyMfyDTO modifyCountryDTO);

    ValueTask<GetMfyDetailDTO> RemoveMfyAsync(int id);
    CreationMfyDTO RetrieveAsync();
}
