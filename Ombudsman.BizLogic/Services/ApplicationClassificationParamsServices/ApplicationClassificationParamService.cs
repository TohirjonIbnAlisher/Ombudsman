using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.ApplicationClassificationParameters;

namespace Ombudsman.BizLogic.Services.ApplicationClassificationParamsServices;

public class ApplicationClassificationParamService : IApplicationClassificationParamService
{
    private readonly IMapper _mapper;
    private readonly IApplicationClassificationParameterRepository _applicationClassificationParameterRepository;

    public ApplicationClassificationParamService(
        IMapper mapper,
        IApplicationClassificationParameterRepository applicationClassificationParameterRepository)
    {
        _mapper = mapper;
        _applicationClassificationParameterRepository = applicationClassificationParameterRepository;
    }

    public async ValueTask<GetAppClassParamDTO> CreateApplicationClassificationParamAsync(CreateAppClassParamDTO creationApplicationClassificationParamDTO)
    {
        var mapped = this._mapper.Map<CreateAppClassParamDTO, ApplicationClassificationParameter>(creationApplicationClassificationParamDTO);

        var createdApplicationClassification = await this._applicationClassificationParameterRepository.CreateAsync(mapped);

        await this._applicationClassificationParameterRepository.SaveChangeAsync();

        return this._mapper.Map<ApplicationClassificationParameter, GetAppClassParamDTO>(createdApplicationClassification);
    }

    public async ValueTask<GetAppClassParamDTO> ModifyApplicationClassificationParamAsync(int id, ModifyAppClassParamDTO modifyApplicationClassificationParamDTO)
    {
        var retrivedById = await this._applicationClassificationParameterRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<ApplicationClassificationParameter>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyAppClassParamDTO, ApplicationClassificationParameter>(modifyApplicationClassificationParamDTO);
        mapped.Id = id;
        var modifiedApplicationClassification = this._applicationClassificationParameterRepository.Update(mapped);

        await this._applicationClassificationParameterRepository.SaveChangeAsync();

        return this._mapper.Map<ApplicationClassificationParameter, GetAppClassParamDTO>(modifiedApplicationClassification);
    }

    public async ValueTask<GetAppClassParamDTO> RetrieveApplicationClassificationParamByIdAsync(int id)
    {
        var retrivedById = await this._applicationClassificationParameterRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { });

        ServiceValidation<ApplicationClassificationParameter>.CheckingEntityById(retrivedById);

        return _mapper.Map<ApplicationClassificationParameter, GetAppClassParamDTO>(retrivedById);
    }

    public IQueryable<GetAppClassParamDTO> RetrieveApplicationClassificationParams()
    {
        var selectedList = this._applicationClassificationParameterRepository.SelectAllEntity(
            new string[] { });

        return selectedList.Select(applicationClassification => _mapper.Map<ApplicationClassificationParameter, GetAppClassParamDTO>(applicationClassification));
    }

    public GetAppClassParamDTO RetrieveAsync()
    {
        return new GetAppClassParamDTO();
    }
}
