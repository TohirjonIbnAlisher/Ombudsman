using Ombudsman.BizLogic.DataTransferObjects.ApplicationDTOs;

namespace Ombudsman.BizLogic.Services.ApplicationServices;

public interface IApplicationService
{
    ValueTask<GetApplicationDTO> CreateApplicationAsync(
       CreateApplicationDTO creationApplicationDTO);

    IQueryable<GetApplicationDTO> RetrieveApplications();

    ValueTask<GetApplicationDTO> RetrieveApplicationByIdAsync(int id);

    ValueTask<GetApplicationDTO> ModifyApplicationAsync(
        int id,
        ModifyApplicationDTO modifyApplicationDTO);
    GetApplicationDTO RetrieveAsync();
}
