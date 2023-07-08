using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.DataTransferObjects.OrganizationDTOs;

namespace Ombudsman.BizLogic.Services.OrganizationServices;

public interface IOrganizationServices
{
    ValueTask<GetOrganizationDetailsDTO> CreateOrganizationAsync(CreationOrganizationDTO creationOrganizationDTO);

    IQueryable<GetOrganizationDTO> RetrieveOrganizations();

    ValueTask<GetOrganizationDetailsDTO> RetrieveOrganizationByIdAsync(int id);

    ValueTask<GetOrganizationDetailsDTO> ModifyOrganizationAsync(int id, ModifyOrganizationDTO modifyCountryDTO);

    ValueTask<GetOrganizationDetailsDTO> RemoveOrganizationAsync(int id);
    CreationOrganizationDTO RetrieveAsync();
}
