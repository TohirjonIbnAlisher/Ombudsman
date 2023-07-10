using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.DistrictDTOs;
using Ombudsman.BizLogic.Services.DistrictServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/district")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            this._districtService = districtService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostDistrictAsync)]
        public async ValueTask<IActionResult> PostDistrictAsync(
            CreationDistrictDTO creationDistrictDTO)
            => Created("", await this._districtService.CreateDistrictAsync(creationDistrictDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutDistrictAsync)]
        public async ValueTask<IActionResult> PutDistrictAsync(
            int id,
            ModifyDistrictDTO modifyDistrictDTO)
            => Ok(await this._districtService.ModifyDistrictAsync(id, modifyDistrictDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetDistrictByIdAsync)]
        public async ValueTask<IActionResult> GetDistrictByIdAsync(int id)
            => Ok(await this._districtService.RetrieveDistrictByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllDistricts)]
        public IActionResult GetAllDistricts()
            => Ok(this._districtService.RetrieveDistricts());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._districtService.RetrieveAsync());

        [HttpDelete("{id}")]
        [HasPermission(PermissionEnums.DeleteDistrictAsync)]
        public async ValueTask<IActionResult> DeleteDistrictAsync(int id)
            => Ok(await this._districtService.RemoveDistrictAsync(id));
    }
}

