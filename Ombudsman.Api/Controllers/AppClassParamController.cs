using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;
using Ombudsman.BizLogic.Services.ApplicationClassificationParamsServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/appClassParam")]
    [ApiController]
    public class AppClassParamController : ControllerBase
    {
        private readonly IApplicationClassificationParamService _applicationClassificationParamService;

        public AppClassParamController(IApplicationClassificationParamService applicationClassificationService)
        {
            this._applicationClassificationParamService = applicationClassificationService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostApplicationClassificationParamAsync)]
        public async ValueTask<IActionResult> PostApplicationClassificationParamAsync(
            CreateAppClassParamDTO creationApplicationClassificationParamDTO)
            => Created("", await this._applicationClassificationParamService.CreateApplicationClassificationParamAsync(creationApplicationClassificationParamDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutApplicationClassificationParamAsync)]
        public async ValueTask<IActionResult> PutApplicationClassificationParamAsync(
            int id,
            ModifyAppClassParamDTO modifyApplicationClassificationParamDTO)
            => Ok(await this._applicationClassificationParamService.ModifyApplicationClassificationParamAsync(id, modifyApplicationClassificationParamDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetApplicationClassificationParamByIdAsync)]
        public async ValueTask<IActionResult> GetApplicationClassificationParamByIdAsync(int id)
            => Ok(await this._applicationClassificationParamService.RetrieveApplicationClassificationParamByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllApplicationClassificationParams)]
        public IActionResult GetAllApplicationClassificationParams()
            => Ok(this._applicationClassificationParamService.RetrieveApplicationClassificationParams());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._applicationClassificationParamService.RetrieveAsync());

    }
}
