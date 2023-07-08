using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Mfys;

namespace Ombudsman.BizLogic.Services.MfyServices;

public class MfyService : IMfyService
{
    private readonly IMfyRepository _mfyRepository;
    private readonly IMapper _mapper;

    public MfyService(
        IMfyRepository mfyRepository,
        IMapper mapper)
    {
        _mfyRepository = mfyRepository;
        _mapper = mapper;
    }

    public async ValueTask<GetMfyDetailDTO> CreateMfyAsync(
        CreationMfyDTO creationMfyDTO)
    {
        var mapped = this._mapper.Map<CreationMfyDTO, Mfy>(creationMfyDTO);

        var createdMfy = await this._mfyRepository.CreateAsync(mapped);

        await this._mfyRepository.SaveChangeAsync();

        return this._mapper.Map<Mfy, GetMfyDetailDTO>(createdMfy);
    }

    public async ValueTask<GetMfyDetailDTO> ModifyMfyAsync(int id, ModifyMfyDTO modifyCountryDTO)
    {
        var retrivedById = await this._mfyRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<Mfy>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyMfyDTO, Mfy>(modifyCountryDTO);
        mapped.Id = id;
        mapped.StateId = 1;
        var modifiedMfy = this._mfyRepository.Update(mapped);

        await this._mfyRepository.SaveChangeAsync();

        return this._mapper.Map<Mfy, GetMfyDetailDTO>(modifiedMfy);
    }

    public async ValueTask<GetMfyDetailDTO> RemoveMfyAsync(int id)
    {
        var Mfy = await this._mfyRepository.SelectEntityByIdAsync(
            r => r.Id == id,
            new string[] { });

        ServiceValidation<Mfy>.CheckingEntityById(Mfy);

        Mfy.StateId = 2;
        var removedMfy = this._mfyRepository.Update(
            Mfy);

        await this._mfyRepository.SaveChangeAsync();

        return _mapper.Map<Mfy, GetMfyDetailDTO>(removedMfy);
    }

    public CreationMfyDTO RetrieveAsync()
    {
        return new CreationMfyDTO();
    }

    public async ValueTask<GetMfyDetailDTO> RetrieveMfyByIdAsync(int id)
    {
        var retrivedById = await this._mfyRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "State", "Region", "District" });

        ServiceValidation<Mfy>.CheckingEntityById(retrivedById);

        return _mapper.Map<Mfy, GetMfyDetailDTO>(retrivedById);
    }

    public IQueryable<GetMfyDTO> RetrieveMfys()
    {
        var selectedList = this._mfyRepository.SelectAllEntity(
            new string[] { "State", "Region","District" });

        return selectedList.Select(Mfy => _mapper.Map<Mfy, GetMfyDTO>(Mfy));
    }
}
