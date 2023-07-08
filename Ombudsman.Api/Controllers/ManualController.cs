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

        [HttpGet("employmentTypes")]
        public IActionResult GetEmploymentTypes()
           => Ok(this._manualService.RetrieveEmploymentTypes());

        [HttpGet("businessSector")]
        public IActionResult GetBusinessSectors()
           => Ok(this._manualService.RetrieveBusinessSector());

        [HttpGet("applicantTypes")]
        public IActionResult GetApplicantTypes()
           => Ok(this._manualService.RetrieveApplicantTypes());

        [HttpGet("applicationFormingTypes")]
        public IActionResult GetApplicationFormingTypes()
           => Ok(this._manualService.RetrieveApplicationFormingTypes());

        [HttpGet("applicationForms")]
        public IActionResult GetApplicationForms()
           => Ok(this._manualService.RetrieveApplicationForms());

        [HttpGet("applicationTypes")]
        public IActionResult GetApplicationTypes()
           => Ok(this._manualService.RetrieveApplicationTypes());

        [HttpGet("organizationLevels")]
        public IActionResult GetOrganizationLevels()
           => Ok(this._manualService.RetrieveOrganizationLevels());

        [HttpGet("organizationTypes")]
        public IActionResult GetOrganizationTypes()
           => Ok(this._manualService.RetrieveOrganizationTypes());

        [HttpGet("parameterTypes")]
        public IActionResult GetParameterTypes()
           => Ok(this._manualService.RetrieveParameterTypes());
        
        [HttpGet("states")]
        public IActionResult GetStates()
           => Ok(this._manualService.RetrieveStates());
        
        [HttpGet("unitOfMeasures")]
        public IActionResult GetUnitOfMeasures()
           => Ok(this._manualService.RetrieveUnitOfMeasures());
    }
}
