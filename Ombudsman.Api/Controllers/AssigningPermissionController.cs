using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;
using Ombudsman.BizLogic.Services.AssigningPermissionServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/assigningPermission")]
    [ApiController]
    public class AssigningPermissionController : ControllerBase
    {
        private readonly IAssigningPermissionService _assigningPermissionService;

        public AssigningPermissionController(IAssigningPermissionService assigningPermissionService)
        {
            this._assigningPermissionService = assigningPermissionService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostAssigningPermissionAsync)]
        public async ValueTask<IActionResult> PostAssigningPermissionAsync(
            CreationAssigningPermissionDTO creationAssigningPermissionDTO)
            => Created("", await this._assigningPermissionService.CreateAssigningPermissionAsync(creationAssigningPermissionDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutAssigningPermissionAsync)]
        public async ValueTask<IActionResult> PutAssigningPermissionAsync(
            int id,
            ModifyAssigningPermissionDTO modifyAssigningPermissionDTO)
            => Ok(await this._assigningPermissionService.ModifyAssigningPermissionAsync(id, modifyAssigningPermissionDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetAssigningPermissionByIdAsync)]
        public async ValueTask<IActionResult> GetAssigningPermissionByIdAsync(int id)
            => Ok(await this._assigningPermissionService.RetrieveAssigningPermissionByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllAssigningPermissions)]
        public IActionResult GetAllAssigningPermissions()
            => Ok(this._assigningPermissionService.RetrieveAssigningPermissions());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._assigningPermissionService.RetrieveAsync());

        [HttpDelete("{id}")]
        [HasPermission(PermissionEnums.DeleteAssigningPermissionAsync)]
        public async ValueTask<IActionResult> DeleteAssigningPermissionAsync(int id)
            => Ok(await this._assigningPermissionService.RemoveAssigningPermissionAsync(id));
    }
}
