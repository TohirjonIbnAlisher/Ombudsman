using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.Services.OrganizationServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationServices organizationServices;

        public OrganizationController(IOrganizationServices organizationServices)
        {
            this.organizationServices = organizationServices;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostOrganizationAsync)]
        public async ValueTask<IActionResult> PostOrganizationAsync(
            CreationOrganizationDTO creationOrganizationDTO)
            => Created("", await this.organizationServices.CreateOrganizationAsync(creationOrganizationDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutOrganizationAsync)]
        public async ValueTask<IActionResult> PutOrganizationAsync(
            int id,
            ModifyOrganizationDTO modifyOrganizationDTO)
            => Ok(await this.organizationServices.ModifyOrganizationAsync(id, modifyOrganizationDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetOrganizationByIdAsync)]
        public async ValueTask<IActionResult> GetOrganizationByIdAsync(int id)
            => Ok(await this.organizationServices.RetrieveOrganizationByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllOrganizations)]
        public IActionResult GetAllOrganizations()
            => Ok(this.organizationServices.RetrieveOrganizations());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this.organizationServices.RetrieveAsync());

        [HttpDelete("{id}")]
        [HasPermission(PermissionEnums.DeleteOrganizationAsync)]
        public async ValueTask<IActionResult> DeleteOrganizationAsync(int id)
            => Ok(await this.organizationServices.RemoveOrganizationAsync(id));
    }
}
