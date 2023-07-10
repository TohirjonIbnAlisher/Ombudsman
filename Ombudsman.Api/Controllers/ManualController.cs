using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Services.ManualServices;

namespace Ombudsman.Api.Controllers
{
    [Route("api/manual")]
    [ApiController]
    public class ManualController : ControllerBase
    {
        private readonly IManualService _manualService;

        public ManualController(IManualService manualService)
        {
            _manualService = manualService;
        }

        [HttpGet("employmentTypesSelectList")]
        [Authorize]
        public IActionResult GetEmploymentTypes()
           => Ok(this._manualService.RetrieveEmploymentTypes());

        [HttpGet("businessSectorSelectList")]
        [Authorize]
        public IActionResult GetBusinessSectors()
           => Ok(this._manualService.RetrieveBusinessSector());

        [HttpGet("applicantTypesSelectList")]
        [Authorize]
        public IActionResult GetApplicantTypes()
           => Ok(this._manualService.RetrieveApplicantTypes());

        [HttpGet("applicationFormingTypesSelectList")]
        [Authorize]
        public IActionResult GetApplicationFormingTypes()
           => Ok(this._manualService.RetrieveApplicationFormingTypes());

        [HttpGet("applicationFormsSelectList")]
        [Authorize]
        public IActionResult GetApplicationForms()
           => Ok(this._manualService.RetrieveApplicationForms());

        [HttpGet("applicationTypesSelectList")]
        [Authorize]
        public IActionResult GetApplicationTypes()
           => Ok(this._manualService.RetrieveApplicationTypes());

        [HttpGet("organizationLevelsSelectList")]
        [Authorize]
        public IActionResult GetOrganizationLevels()
           => Ok(this._manualService.RetrieveOrganizationLevels());

        [HttpGet("organizationTypesSelectList")]
        [Authorize]
        public IActionResult GetOrganizationTypes()
           => Ok(this._manualService.RetrieveOrganizationTypes());

        [HttpGet("parameterTypesSelectList")]
        [Authorize]
        public IActionResult GetParameterTypes()
           => Ok(this._manualService.RetrieveParameterTypes());
        
        [HttpGet("statesSelectList")]
        [Authorize]
        public IActionResult GetStates()
           => Ok(this._manualService.RetrieveStates());
        
        [HttpGet("unitOfMeasuresSelectList")]
        [Authorize]
        public IActionResult GetUnitOfMeasures()
           => Ok(this._manualService.RetrieveUnitOfMeasures()); 
        
        [HttpGet("permissionsSelectList")]
        [Authorize]
        public IActionResult GetPermissions()
           => Ok(this._manualService.RetrievePermissions());
        
        [HttpGet("rolesSelectList")]
        [Authorize]
        public IActionResult GetRoles()
           => Ok(this._manualService.RetrieveRoles());
        
        [HttpGet("positionsSelectList")]
        [Authorize]
        public IActionResult GetPositions()
           => Ok(this._manualService.RetrievePositions());
    }
}
