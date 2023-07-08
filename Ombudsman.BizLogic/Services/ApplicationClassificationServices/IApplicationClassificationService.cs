using Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;

namespace Ombudsman.BizLogic.Services.ApplicationClassificationServices;

public interface IApplicationClassificationService
{
    ValueTask<GetApplicationClassificationDetailDTO> CreateApplicationClassificationAsync(
       CreationApplicationClassificationDTO creationApplicationClassificationDTO);

    IQueryable<GetApplicationClassificationDTO> RetrieveApplicationClassifications();

    ValueTask<GetApplicationClassificationDetailDTO> RetrieveApplicationClassificationByIdAsync(int id);

    ValueTask<GetApplicationClassificationDetailDTO> ModifyApplicationClassificationAsync(
        int id,
        ModifyApplicationClassificationDTO modifyApplicationClassificationDTO);

    ValueTask<GetApplicationClassificationDetailDTO> RemoveApplicationClassificationAsync(int id);
    CreationApplicationClassificationDTO RetrieveAsync();
}
