using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.OrganizationDTOs;
using Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Parameters;

namespace Ombudsman.BizLogic.Services.Parameters;

public class ParameterService : IParameterService
{
    private readonly IParameterRepository _parameterRepository;
    private readonly IMapper mapper;

    public ParameterService(IParameterRepository parameterRepository, IMapper mapper)
    {
        this._parameterRepository = parameterRepository;
        this.mapper = mapper;
    }

    public async ValueTask<GetParameterDTO> CreateDigNumParameterAsync(CreationDigNumParameterDTO creationDigNumParameterDTO)
    {
        var mapped = this.mapper.Map<CreationDigNumParameterDTO, Parameter>(creationDigNumParameterDTO);

        var createdOrganization = await this._parameterRepository.CreateAsync(mapped);

        await this._parameterRepository.SaveChangeAsync();

        return this.mapper.Map<Parameter, GetParameterDTO>(createdOrganization);
    }

    public async ValueTask<GetParameterDTO> CreateSanaParameterAsync(CreationSanaParameterDTO creationSanaParameterDTO)
    {
        var mapped = this.mapper.Map<CreationSanaParameterDTO, Parameter>(creationSanaParameterDTO);

        var createdOrganization = await this._parameterRepository.CreateAsync(mapped);

        await this._parameterRepository.SaveChangeAsync();

        return this.mapper.Map<Parameter, GetParameterDTO>(createdOrganization);
    }

    public async ValueTask<GetParameterDTO> CreateSpravochnikParameterAsync(CreationSpravochnikParameterDTO creationSpravochnikParameterDTO)
    {
        var mapped = this.mapper.Map<CreationSpravochnikParameterDTO, Parameter>(creationSpravochnikParameterDTO);

        var createdOrganization = await this._parameterRepository.CreateAsync(mapped);

        await this._parameterRepository.SaveChangeAsync();

        return this.mapper.Map<Parameter, GetParameterDTO>(createdOrganization);
    }

    public async ValueTask<GetParameterDTO> CreateTellNumParameterAsync(CreationTellNumParameterDTO creationTellNumParameterDTO)
    {
        var mapped = this.mapper.Map<CreationTellNumParameterDTO, Parameter>(creationTellNumParameterDTO);

        var createdOrganization = await this._parameterRepository.CreateAsync(mapped);

        await this._parameterRepository.SaveChangeAsync();

        return this.mapper.Map<Parameter, GetParameterDTO>(createdOrganization);
    }

    public async ValueTask<GetParameterDTO> RemoveParameterAsync(int id)
    {
        var param = await this._parameterRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { });

        ServiceValidation<Parameter>.CheckingEntityById(param);

        param.StateId = 2;
        var removedParam = this._parameterRepository.Update(
            param);

        await this._parameterRepository.SaveChangeAsync();

        return mapper.Map<Parameter, GetParameterDTO>(removedParam);
    }

    public GetParameterDTO RetrieveAsync()
    {
        return new GetParameterDTO();
    }

    public async ValueTask<GetParameterDTO> RetrieveParameterByIdAsync(int id)
    {
        var retrivedById = await this._parameterRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "State", "ParameterType" });

        ServiceValidation<Parameter>.CheckingEntityById(retrivedById);

        return mapper.Map<Parameter, GetParameterDTO>(retrivedById);
    }

    public IQueryable<GetParameterDTO> RetrieveParameters()
    {
        var selectedList = this._parameterRepository.SelectAllEntity(
            new string[] { "State", "ParameterType" });

        return selectedList.Select(organization => mapper.Map<Parameter, GetParameterDTO>(organization));
    }
}
