using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.RegionDTOs;
using Ombudsman.BizLogic.Validations;
using Ombudsman.DataAccessLayer.Models.Infos;
using Ombudsman.DataAccessLayer.Repositories.Regions;

namespace Ombudsman.BizLogic.Services.RegionServices;

public class RegionService : IRegionService
{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;

    public RegionService(
        IRegionRepository regionRepository,
        IMapper mapper)
    {
        _regionRepository = regionRepository;
        _mapper = mapper;
    }

    public async ValueTask<GetRegionDetailsDTO> CreateRegionAsync(
        CreationRegionDTO creationRegionDTO)
    {
        var mapped = this._mapper.Map<CreationRegionDTO, Region>(creationRegionDTO);

        var createdRegion = await this._regionRepository.CreateAsync(mapped);

        await this._regionRepository.SaveChangeAsync();

        return this._mapper.Map<Region, GetRegionDetailsDTO>(createdRegion);
    }

    public async ValueTask<GetRegionDetailsDTO> ModifyRegionAsync(int id, ModifyRegionDTO modifyCountryDTO)
    {
        var retrivedById = await this._regionRepository.SelectEntityByIdAsync(
            rg => rg.Id == id,
            new string[] { });

        ServiceValidation<Region>.CheckingEntityById(retrivedById);

        var mapped = this._mapper.Map<ModifyRegionDTO, Region>(modifyCountryDTO);
        mapped.Id = id;
        mapped.StateId = 1;
        var modifiedRegion = this._regionRepository.Update(mapped);

        await this._regionRepository.SaveChangeAsync();

        return this._mapper.Map<Region, GetRegionDetailsDTO>(modifiedRegion);
    }

    public async ValueTask<GetRegionDetailsDTO> RemoveRegionAsync(int id)
    {
        var region = await this._regionRepository.SelectEntityByIdAsync(
            r => r.Id == id,
            new string[] {});

        ServiceValidation<Region>.CheckingEntityById(region);

        region.StateId = 2;
        var removedRegion = this._regionRepository.Update(
            region);

        await this._regionRepository.SaveChangeAsync();

        return _mapper.Map<Region, GetRegionDetailsDTO>(removedRegion);
    }

    public CreationRegionDTO RetrieveAsync()
    {
        return new CreationRegionDTO();
    }

    public async ValueTask<GetRegionDetailsDTO> RetrieveRegionByIdAsync(int id)
    {
        var retrivedById = await this._regionRepository.SelectEntityByIdAsync(
            org => org.Id == id,
            new string[] {"State" });

        ServiceValidation<Region>.CheckingEntityById(retrivedById);
        
        return _mapper.Map<Region, GetRegionDetailsDTO>(retrivedById);
    }

    public IQueryable<GetRegionDTO> RetrieveRegions()
    {
        var selectedList = this._regionRepository.SelectAllEntity(
            new string[] {"State" });

        return selectedList.Select(Region => _mapper.Map<Region, GetRegionDTO>(Region));
    }
}
