using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;
using Ombudsman.BizLogic.Services.ApplicationClassificationServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/applicationClassification")]
    [ApiController]
    public class ApplicationClassificationController : ControllerBase
    {
        private readonly IApplicationClassificationService _applicationClassificationService;

        public ApplicationClassificationController(IApplicationClassificationService ApplicationClassificationService)
        {
            this._applicationClassificationService = ApplicationClassificationService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostApplicationClassificationAsync)]
        public async ValueTask<IActionResult> PostApplicationClassificationAsync(
            CreationApplicationClassificationDTO creationApplicationClassificationDTO)
            => Created("", await this._applicationClassificationService.CreateApplicationClassificationAsync(creationApplicationClassificationDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutApplicationClassificationAsync)]
        public async ValueTask<IActionResult> PutApplicationClassificationAsync(
            int id,
            ModifyApplicationClassificationDTO modifyApplicationClassificationDTO)
            => Ok(await this._applicationClassificationService.ModifyApplicationClassificationAsync(id, modifyApplicationClassificationDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetApplicationClassificationByIdAsync)]
        public async ValueTask<IActionResult> GetApplicationClassificationByIdAsync(int id)
            => Ok(await this._applicationClassificationService.RetrieveApplicationClassificationByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllApplicationClassifications)]
        public IActionResult GetAllApplicationClassifications()
            => Ok(this._applicationClassificationService.RetrieveApplicationClassifications());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._applicationClassificationService.RetrieveAsync());

        [HttpDelete("{id}")]
        [HasPermission(PermissionEnums.DeleteApplicationClassificationAsync)]
        public async ValueTask<IActionResult> DeleteApplicationClassificationAsync(int id)
            => Ok(await this._applicationClassificationService.RemoveApplicationClassificationAsync(id));
    }
}

