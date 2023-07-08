using Ombudsman.BizLogic.DataTransferObjects.DistrictDTOs;

namespace Ombudsman.BizLogic.Services.DistrictServices;

public interface IDistrictService
{
    ValueTask<GetDistrictDetailDTO> CreateDistrictAsync(
        CreationDistrictDTO creationDistrictDTO);

    IQueryable<GetDistrictDTO> RetrieveDistricts();

    ValueTask<GetDistrictDetailDTO> RetrieveDistrictByIdAsync(int id);

    ValueTask<GetDistrictDetailDTO> ModifyDistrictAsync(
        int id,
        ModifyDistrictDTO modifyCountryDTO);

    ValueTask<GetDistrictDetailDTO> RemoveDistrictAsync(int id);
    CreationDistrictDTO RetrieveAsync();
}
