using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Docs;
using Ombudsman.DataAccessLayer.Repositories.ApplicationParameter;

namespace Ombudsman.BizLogic.Services.ApplicationParameterServices;

public class ApplicationParameterService : IApplicationParameterService
{
    private readonly IApplicationParameterRepository _applicationParameterRepository;
    private readonly IMapper _mapper;

    public ApplicationParameterService(
        IApplicationParameterRepository permissionRoleRepository,
        IMapper mapper)
    {
        this._applicationParameterRepository = permissionRoleRepository;
        this._mapper = mapper;
    }

    public async ValueTask<GetApplicationParameterDTO> CreateApplicationParameterAsync(
        CreationApplicationParameterDTO creationApplicationParameterDTO)
    {
        var mapped = this._mapper.Map<CreationApplicationParameterDTO, AppilcationParam>(creationApplicationParameterDTO);

        var createdApplicationParameter = await this._applicationParameterRepository.CreateAsync(mapped);

        await this._applicationParameterRepository.SaveChangeAsync();

        return this._mapper.Map<AppilcationParam, GetApplicationParameterDTO>(createdApplicationParameter);
    }

    public async ValueTask<GetApplicationParameterDTO> ModifyApplicationParameterAsync(
        int id,
        ModifyApplicationParameterDTO modifyApplicationParameterDTO)
    {
        var retrivedById = await this._applicationParameterRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<AppilcationParam>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyApplicationParameterDTO, AppilcationParam>(modifyApplicationParameterDTO);
        mapped.Id = id;
        var modifiedApplicationParameter = this._applicationParameterRepository.Update(mapped);

        await this._applicationParameterRepository.SaveChangeAsync();

        return this._mapper.Map<AppilcationParam, GetApplicationParameterDTO>(modifiedApplicationParameter);
    }
    public CreationApplicationParameterDTO RetrieveAsync()
    {
        return new CreationApplicationParameterDTO();
    }

    public async ValueTask<GetApplicationParameterDTO> RetrieveApplicationParameterByIdAsync(int id)
    {
        var retrivedById = await this._applicationParameterRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "Application", "Parameter"});

        ServiceValidation<AppilcationParam>.CheckingEntityById(retrivedById);

        return _mapper.Map<AppilcationParam, GetApplicationParameterDTO>(retrivedById);
    }

    public IQueryable<GetApplicationParameterDTO> RetrieveApplicationParameters()
    {
        var selectedList = this._applicationParameterRepository.SelectAllEntity(
            new string[] { "Parameter", "Application" });

        return selectedList.Select(sel => _mapper.Map<AppilcationParam, GetApplicationParameterDTO>(sel));
    }
}
