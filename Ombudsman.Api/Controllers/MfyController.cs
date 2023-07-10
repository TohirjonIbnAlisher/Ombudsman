using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.Services.MfyServices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers;

[Route("api/mfy")]
[ApiController]
public class MfyController : ControllerBase
{
    private readonly IMfyService _mfyService;

    public MfyController(IMfyService mfyService)
    {
        this._mfyService = mfyService;
    }

    [HttpPost]
    [HasPermission(PermissionEnums.PostMfyAsync)]
    public async ValueTask<IActionResult> PostMfyAsync(
        CreationMfyDTO creationMfyDTO)
        => Created("", await this._mfyService.CreateMfyAsync(creationMfyDTO));

    [HttpPut("{id}")]
    [HasPermission(PermissionEnums.PutMfyAsync)]
    public async ValueTask<IActionResult> PutMfyAsync(
        int id,
        ModifyMfyDTO modifyMfyDTO)
        => Ok(await this._mfyService.ModifyMfyAsync(id, modifyMfyDTO));

    [HttpGet("{id}")]
    [HasPermission(PermissionEnums.GetMfyByIdAsync)]
    public async ValueTask<IActionResult> GetMfyByIdAsync(int id)
        => Ok(await this._mfyService.RetrieveMfyByIdAsync(id));

    [HttpGet("selectedList")]
    [HasPermission(PermissionEnums.GetAllMfys)]
    public IActionResult GetAllMfys()
        => Ok(this._mfyService.RetrieveMfys());

    [HttpGet]
    [HasPermission(PermissionEnums.Get)]
    public IActionResult Get()
        => Ok(this._mfyService.RetrieveAsync());

    [HttpDelete("{id}")]
    [HasPermission(PermissionEnums.DeleteMfyAsync)]
    public async ValueTask<IActionResult> DeleteMfyAsync(int id)
        => Ok(await this._mfyService.RemoveMfyAsync(id));
}
