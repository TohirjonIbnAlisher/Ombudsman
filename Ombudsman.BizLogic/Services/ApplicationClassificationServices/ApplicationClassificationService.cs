using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.ApplicationClassifacitaions;

namespace Ombudsman.BizLogic.Services.ApplicationClassificationServices;

public class ApplicationClassificationService : IApplicationClassificationService
{
    private readonly IApplicationClassificationRepository _applicationClassificationRepository;
    private readonly IMapper _mapper;

    public ApplicationClassificationService(
        IApplicationClassificationRepository ApplicationClassificationRepository,
        IMapper mapper)
    {
        this._applicationClassificationRepository = ApplicationClassificationRepository;
        this._mapper = mapper;
    }

    public async ValueTask<GetApplicationClassificationDetailDTO> CreateApplicationClassificationAsync(
        CreationApplicationClassificationDTO creationApplicationClassificationDTO)
    {
        var mapped = this._mapper.Map<CreationApplicationClassificationDTO, ApplicationClassification>(creationApplicationClassificationDTO);

        var createdApplicationClassification = await this._applicationClassificationRepository.CreateAsync(mapped);

        await this._applicationClassificationRepository.SaveChangeAsync();

        return this._mapper.Map<ApplicationClassification, GetApplicationClassificationDetailDTO>(createdApplicationClassification);
    }

    public async ValueTask<GetApplicationClassificationDetailDTO> ModifyApplicationClassificationAsync(int id, ModifyApplicationClassificationDTO modifyCountryDTO)
    {
        var retrivedById = await this._applicationClassificationRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<ApplicationClassification>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyApplicationClassificationDTO, ApplicationClassification>(modifyCountryDTO);
        mapped.Id = id;
        mapped.StateId = 1;
        var modifiedApplicationClassification = this._applicationClassificationRepository.Update(mapped);

        await this._applicationClassificationRepository.SaveChangeAsync();

        return this._mapper.Map<ApplicationClassification, GetApplicationClassificationDetailDTO>(modifiedApplicationClassification);
    }

    public async ValueTask<GetApplicationClassificationDetailDTO> RemoveApplicationClassificationAsync(int id)
    {
        var ApplicationClassification = await this._applicationClassificationRepository.SelectEntityByIdAsync(
            r => r.Id == id,
            new string[] { });

        ServiceValidation<ApplicationClassification>.CheckingEntityById(ApplicationClassification);

        ApplicationClassification.StateId = 2;
        var removedApplicationClassification = this._applicationClassificationRepository.Update(
            ApplicationClassification);

        await this._applicationClassificationRepository.SaveChangeAsync();

        return _mapper.Map<ApplicationClassification, GetApplicationClassificationDetailDTO>(removedApplicationClassification);
    }

    public CreationApplicationClassificationDTO RetrieveAsync()
    {
        return new CreationApplicationClassificationDTO();
    }

    public async ValueTask<GetApplicationClassificationDetailDTO> RetrieveApplicationClassificationByIdAsync(int id)
    {
        var retrivedById = await this._applicationClassificationRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "State", "Organization", "OrganizationLevel", "ParentApplicationClassification" });

        ServiceValidation<ApplicationClassification>.CheckingEntityById(retrivedById);

        return _mapper.Map<ApplicationClassification, GetApplicationClassificationDetailDTO>(retrivedById);
    }

    public IQueryable<GetApplicationClassificationDTO> RetrieveApplicationClassifications()
    {
        var selectedList = this._applicationClassificationRepository.SelectAllEntity(
            new string[] { "State", "ParentApplicationClassification" });

        return selectedList.Select(ApplicationClassification => _mapper.Map<ApplicationClassification, GetApplicationClassificationDTO>(ApplicationClassification));
    }
}
