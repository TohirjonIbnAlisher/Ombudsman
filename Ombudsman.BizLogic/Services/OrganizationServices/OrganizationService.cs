using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.DataTransferObjects.OrganizationDTOs;
using Ombudsman.BizLogic.Exceptions;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Organizations;

namespace Ombudsman.BizLogic.Services.OrganizationServices;

public class OrganizationService : IOrganizationServices
{
    private readonly IOrganizationRepository organizationRepository;
    private readonly IMapper mapper;

    public OrganizationService(IOrganizationRepository organizationRepository, IMapper mapper)
    {
        this.organizationRepository = organizationRepository;
        this.mapper = mapper;
    }

    public async ValueTask<GetOrganizationDetailsDTO> CreateOrganizationAsync(
        CreationOrganizationDTO creationOrganizationDTO)
    {
        var mapped = this.mapper.Map<CreationOrganizationDTO, Organization>(creationOrganizationDTO);

        var createdOrganization = await this.organizationRepository.CreateAsync(mapped);

        await this.organizationRepository.SaveChangeAsync();

        return this.mapper.Map<Organization, GetOrganizationDetailsDTO>(createdOrganization);
    }

    public CreationOrganizationDTO RetrieveAsync()
    {
        return new CreationOrganizationDTO();
    }

    public async ValueTask<GetOrganizationDetailsDTO> ModifyOrganizationAsync(
        int id, ModifyOrganizationDTO modifyCountryDTO)
    {
        var retrivedById = await this.organizationRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] {});

        ServiceValidation<Organization>.CheckingEntityById(retrivedById);

        var mapped = this.mapper.Map<ModifyOrganizationDTO, Organization>(modifyCountryDTO);
        mapped.Id = id;
        mapped.StateId = 1;
        var modifiedOrganization = this.organizationRepository.Update(mapped);

        await this.organizationRepository.SaveChangeAsync();

        return this.mapper.Map<Organization, GetOrganizationDetailsDTO>(modifiedOrganization);
    }

    public async ValueTask<GetOrganizationDetailsDTO> RemoveOrganizationAsync(int id)
    {
        var organization = await this.organizationRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { });

        ServiceValidation<Organization>.CheckingEntityById(organization);

        organization.StateId = 2;
        var removedOrganization = this.organizationRepository.Update(
            organization);

        await this.organizationRepository.SaveChangeAsync();

        return mapper.Map<Organization, GetOrganizationDetailsDTO>(removedOrganization);
    }

    public async ValueTask<GetOrganizationDetailsDTO> RetrieveOrganizationByIdAsync(int id)
    {
        var retrivedById = await this.organizationRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "District", "ParentOrganization", "OrganizationLevel", "OrganizationType", "Region", "State" });

        ServiceValidation<Organization>.CheckingEntityById(retrivedById);

        return mapper.Map<Organization, GetOrganizationDetailsDTO> (retrivedById);
    }

    public IQueryable<GetOrganizationDTO> RetrieveOrganizations()
    {
        var selectedList = this.organizationRepository.SelectAllEntity(
            new string[] { "District", "ParentOrganization", "OrganizationLevel", "OrganizationType", "Region", "State" });

        return selectedList.Select(organization => mapper.Map<Organization, GetOrganizationDTO>(organization));
    }
}
