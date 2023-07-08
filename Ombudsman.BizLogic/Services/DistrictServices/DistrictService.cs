using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.DistrictDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Districts;

namespace Ombudsman.BizLogic.Services.DistrictServices;

public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;
    private readonly IMapper _mapper;

    public DistrictService(
        IDistrictRepository DistrictRepository,
        IMapper mapper)
    {
        _districtRepository = DistrictRepository;
        _mapper = mapper;
    }

    public async ValueTask<GetDistrictDetailDTO> CreateDistrictAsync(
        CreationDistrictDTO creationDistrictDTO)
    {
        var mapped = this._mapper.Map<CreationDistrictDTO, District>(creationDistrictDTO);

        var createdDistrict = await this._districtRepository.CreateAsync(mapped);

        await this._districtRepository.SaveChangeAsync();

        return this._mapper.Map<District, GetDistrictDetailDTO>(createdDistrict);
    }

    public async ValueTask<GetDistrictDetailDTO> ModifyDistrictAsync(int id, ModifyDistrictDTO modifyCountryDTO)
    {
        var retrivedById = await this._districtRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<District>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyDistrictDTO, District>(modifyCountryDTO);
        mapped.Id = id;
        mapped.StateId = 1;
        var modifiedDistrict = this._districtRepository.Update(mapped);

        await this._districtRepository.SaveChangeAsync();

        return this._mapper.Map<District, GetDistrictDetailDTO>(modifiedDistrict);
    }

    public async ValueTask<GetDistrictDetailDTO> RemoveDistrictAsync(int id)
    {
        var District = await this._districtRepository.SelectEntityByIdAsync(
            r => r.Id == id,
            new string[] { });

        ServiceValidation<District>.CheckingEntityById(District);

        District.StateId = 2;
        var removedDistrict = this._districtRepository.Update(
            District);

        await this._districtRepository.SaveChangeAsync();

        return _mapper.Map<District, GetDistrictDetailDTO>(removedDistrict);
    }

    public CreationDistrictDTO RetrieveAsync()
    {
        return new CreationDistrictDTO();
    }

    public async ValueTask<GetDistrictDetailDTO> RetrieveDistrictByIdAsync(int id)
    {
        var retrivedById = await this._districtRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] { "State", "Region" });

        ServiceValidation<District>.CheckingEntityById(retrivedById);

        return _mapper.Map<District, GetDistrictDetailDTO>(retrivedById);
    }

    public IQueryable<GetDistrictDTO> RetrieveDistricts()
    {
        var selectedList = this._districtRepository.SelectAllEntity(
            new string[] { "State", "Region" });

        return selectedList.Select(District => _mapper.Map<District, GetDistrictDTO>(District));
    }
}
