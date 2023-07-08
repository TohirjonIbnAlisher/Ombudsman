using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.DataTransferObjects.RegionDTOs;
using Ombudsman.BizLogic.Services.RegionServices;

namespace Ombudsman.Api.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostRegionAsync(
            CreationRegionDTO creationRegionDTO)
            => Created("", await this._regionService.CreateRegionAsync(creationRegionDTO));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> PutRegionAsync(
            int id,
            ModifyRegionDTO modifyRegionDTO)
            => Ok(await this._regionService.ModifyRegionAsync(id, modifyRegionDTO));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetRegionByIdAsync(int id)
            => Ok(await this._regionService.RetrieveRegionByIdAsync(id));

        [HttpGet("selectedList")]
        public IActionResult GetAllRegions()
            => Ok(this._regionService.RetrieveRegions());

        [HttpGet]
        public IActionResult Get()
            => Ok(this._regionService.RetrieveAsync());

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteRegionAsync(int id)
            => Ok(await this._regionService.RemoveRegionAsync(id));
    }
}
