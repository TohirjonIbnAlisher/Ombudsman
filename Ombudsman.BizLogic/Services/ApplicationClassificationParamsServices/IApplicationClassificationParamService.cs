using Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;

namespace Ombudsman.BizLogic.Services.ApplicationClassificationParamsServices;

public interface IApplicationClassificationParamService
{
    ValueTask<GetAppClassParamDTO> CreateApplicationClassificationParamAsync(
       CreateAppClassParamDTO creationApplicationClassificationParamDTO);

    IQueryable<GetAppClassParamDTO> RetrieveApplicationClassificationParams();

    ValueTask<GetAppClassParamDTO> RetrieveApplicationClassificationParamByIdAsync(int id);

    ValueTask<GetAppClassParamDTO> ModifyApplicationClassificationParamAsync(
        int id,
        ModifyAppClassParamDTO modifyApplicationClassificationParamDTO);
    GetAppClassParamDTO RetrieveAsync();
}
