using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationDTOs;
using Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Docs;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.ApplicantTypes;
using Ombudsman.DataAccessLayer.Repositories.Applications;

namespace Ombudsman.BizLogic.Services.ApplicationServices;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async ValueTask<GetApplicationDTO> CreateApplicationAsync(CreateApplicationDTO creationApplicationDTO)
    {
        var mapped = this._mapper.Map<CreateApplicationDTO, Application>(creationApplicationDTO);

        var createdApplication = await this._applicationRepository.CreateAsync(mapped);

        await this._applicationRepository.SaveChangeAsync();

        return this._mapper.Map<Application, GetApplicationDTO>(createdApplication);
    }

    public async ValueTask<GetApplicationDTO> ModifyApplicationAsync(int id, ModifyApplicationDTO modifyApplicationDTO)
    {
        var retrivedById = await this._applicationRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<Application>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyApplicationDTO, Application>(modifyApplicationDTO);
        mapped.Id = id;
        var modifiedApplication = this._applicationRepository.Update(mapped);

        await this._applicationRepository.SaveChangeAsync();

        return this._mapper.Map<Application, GetApplicationDTO>(modifiedApplication);
    }
    public async ValueTask<GetApplicationDTO> RetrieveApplicationByIdAsync(int id)
    {
        var retrivedById = await this._applicationRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "ApplicationClassification2", "ApplicationClassification3", "ApplicationClassification4", "ApplicationType", "BaseApplicationClassification", "BusinessSector" });

        ServiceValidation<Application>.CheckingEntityById(retrivedById);

        return _mapper.Map<Application, GetApplicationDTO>(retrivedById);
    }

    public IQueryable<GetApplicationDTO> RetrieveApplications()
    {
        var selectedList = this._applicationRepository.SelectAllEntity(
            new string[] { "ApplicationClassification2", "ApplicationClassification3", "ApplicationClassification4", "ApplicationType", "BaseApplicationClassification", "BusinessSector" });

        return selectedList.Select(sel => _mapper.Map<Application, GetApplicationDTO>(sel));
    }

    public GetApplicationDTO RetrieveAsync()
    {
        return new GetApplicationDTO();
        
    }
}
