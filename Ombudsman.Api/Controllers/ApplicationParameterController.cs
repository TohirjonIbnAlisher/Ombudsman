using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;
using Ombudsman.BizLogic.Services.ApplicationParameterServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/applicationParameter")]
    [ApiController]
    public class ApplicationParameterController : ControllerBase
    {
        private readonly IApplicationParameterService _applicationParameterService;

        public ApplicationParameterController(IApplicationParameterService _applicationParameterService)
        {
            this._applicationParameterService = _applicationParameterService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostApplicationParameterAsync)]
        public async ValueTask<IActionResult> PostApplicationParameterAsync(
            CreationApplicationParameterDTO creationApplicationParameterDTO)
            => Created("", await this._applicationParameterService.CreateApplicationParameterAsync(creationApplicationParameterDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutApplicationParameterAsync)]
        public async ValueTask<IActionResult> PutApplicationParameterAsync(
            int id,
            ModifyApplicationParameterDTO modifyApplicationParameterDTO)
            => Ok(await this._applicationParameterService.ModifyApplicationParameterAsync(id, modifyApplicationParameterDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetApplicationParameterByIdAsync)]
        public async ValueTask<IActionResult> GetApplicationParameterByIdAsync(int id)
            => Ok(await this._applicationParameterService.RetrieveApplicationParameterByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllApplicationParameters)]
        public IActionResult GetAllApplicationParameters()
        {
            var res = this._applicationParameterService.RetrieveApplicationParameters().ToList();
            return Ok(res);
        }

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._applicationParameterService.RetrieveAsync());
    }
}
