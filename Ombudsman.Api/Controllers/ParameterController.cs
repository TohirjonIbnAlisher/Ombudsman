using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;
using Ombudsman.BizLogic.Services.Parameters;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/parameter")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterService _parameterService;

        public ParameterController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpPost("spravochnik")]
        [HasPermission(PermissionEnums.PostParameterAsync)]
        public async ValueTask<IActionResult> PostParameterAsync(
            CreationSpravochnikParameterDTO creationParameterDTO)
            => Created("", await this._parameterService.CreateSpravochnikParameterAsync(creationParameterDTO));
        
        [HttpPost("sana")]
        [HasPermission(PermissionEnums.PostParameterAsync)]
        public async ValueTask<IActionResult> PostParameterAsync(
                    CreationSanaParameterDTO creationParameterDTO)
                    => Created("", await this._parameterService.CreateSanaParameterAsync(creationParameterDTO));
        
        [HttpPost("raqamliMaydon")]
        [HasPermission(PermissionEnums.PostParameterAsync)]
        public async ValueTask<IActionResult> PostParameterAsync(
                    CreationDigNumParameterDTO creationParameterDTO)
                    => Created("", await this._parameterService.CreateDigNumParameterAsync(creationParameterDTO));
        
        [HttpPost("TellNumber")]
        [HasPermission(PermissionEnums.PostParameterAsync)]
        public async ValueTask<IActionResult> PostParameterAsync(
                    CreationTellNumParameterDTO creationParameterDTO)
                    => Created("", await this._parameterService.CreateTellNumParameterAsync(creationParameterDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetParameterByIdAsync)]
        public async ValueTask<IActionResult> GetParameterByIdAsync(int id)
            => Ok(await this._parameterService.RetrieveParameterByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllParameters)]
        public IActionResult GetAllParameters()
            => Ok(this._parameterService.RetrieveParameters());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this._parameterService.RetrieveAsync());

        [HttpDelete("{id}")]
        [HasPermission(PermissionEnums.DeleteParameterAsync)]
        public async ValueTask<IActionResult> DeleteParameterAsync(int id)
            => Ok(await this._parameterService.RemoveParameterAsync(id));
    }
}
