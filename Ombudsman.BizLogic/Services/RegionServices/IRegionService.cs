using Ombudsman.BizLogic.DataTransferObjects.RegionDTOs;
using Ombudsman.BizLogic.DataTransferObjects;

namespace Ombudsman.BizLogic.Services.RegionServices;

public interface IRegionService
{
    ValueTask<GetRegionDetailsDTO> CreateRegionAsync(CreationRegionDTO creationRegionDTO);

    IQueryable<GetRegionDTO> RetrieveRegions();

    ValueTask<GetRegionDetailsDTO> RetrieveRegionByIdAsync(int id);

    ValueTask<GetRegionDetailsDTO> ModifyRegionAsync(int id, ModifyRegionDTO modifyCountryDTO);

    ValueTask<GetRegionDetailsDTO> RemoveRegionAsync(int id);
    CreationRegionDTO RetrieveAsync();
}
