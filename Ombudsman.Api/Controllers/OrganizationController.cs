using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.Services.OrganizationServices;

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
        public async ValueTask<IActionResult> PostOrganizationAsync(
            CreationOrganizationDTO creationOrganizationDTO)
            => Created("", await this.organizationServices.CreateOrganizationAsync(creationOrganizationDTO));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> PutOrganizationAsync(
            int id,
            ModifyOrganizationDTO modifyOrganizationDTO)
            => Ok(await this.organizationServices.ModifyOrganizationAsync(id, modifyOrganizationDTO));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetOrganizationByIdAsync(int id)
            => Ok(await this.organizationServices.RetrieveOrganizationByIdAsync(id));

        [HttpGet("selectedList")]
        public IActionResult GetAllOrganizations()
            => Ok(this.organizationServices.RetrieveOrganizations());

        [HttpGet]
        public IActionResult Get()
            => Ok(this.organizationServices.RetrieveAsync());

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteOrganizationAsync(int id)
            => Ok(await this.organizationServices.RemoveOrganizationAsync(id));
    }
}
