using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationDTOs;
using Ombudsman.BizLogic.Services.ApplicationServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostApplicationAsync)]
        public async ValueTask<IActionResult> PostApplicationAsync(
            CreateApplicationDTO creationApplicationDTO)
            => Created("", await this._applicationService.CreateApplicationAsync(creationApplicationDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutApplicationAsync)]
        public async ValueTask<IActionResult> PutApplicationAsync(
            int id,
            ModifyApplicationDTO modifyApplicationDTO)
            => Ok(await this._applicationService.ModifyApplicationAsync(id, modifyApplicationDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetApplicationByIdAsync)]
        public async ValueTask<IActionResult> GetApplicationByIdAsync(int id)
            => Ok(await this._applicationService.RetrieveApplicationByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllApplications)]
        public IActionResult GetAllApplications()
            => Ok(this._applicationService.RetrieveApplications());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._applicationService.RetrieveAsync());
    }
}
