using Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;

namespace Ombudsman.BizLogic.Services.ApplicationParameterServices;

public interface IApplicationParameterService
{
    ValueTask<GetApplicationParameterDTO> CreateApplicationParameterAsync(
       CreationApplicationParameterDTO creationApplicationParameterDTO);

    IQueryable<GetApplicationParameterDTO> RetrieveApplicationParameters();

    ValueTask<GetApplicationParameterDTO> RetrieveApplicationParameterByIdAsync(int id);

    ValueTask<GetApplicationParameterDTO> ModifyApplicationParameterAsync(
        int id,
        ModifyApplicationParameterDTO modifyApplicationParameterDTO);
    CreationApplicationParameterDTO RetrieveAsync();
}
