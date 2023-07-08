using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.Services.MfyServices;

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
    public async ValueTask<IActionResult> PostMfyAsync(
        CreationMfyDTO creationMfyDTO)
        => Created("", await this._mfyService.CreateMfyAsync(creationMfyDTO));

    [HttpPut("{id}")]
    public async ValueTask<IActionResult> PutMfyAsync(
        int id,
        ModifyMfyDTO modifyMfyDTO)
        => Ok(await this._mfyService.ModifyMfyAsync(id, modifyMfyDTO));

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetMfyByIdAsync(int id)
        => Ok(await this._mfyService.RetrieveMfyByIdAsync(id));

    [HttpGet("selectedList")]
    public IActionResult GetAllMfys()
        => Ok(this._mfyService.RetrieveMfys());

    [HttpGet]
    public IActionResult Get()
        => Ok(this._mfyService.RetrieveAsync());

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteMfyAsync(int id)
        => Ok(await this._mfyService.RemoveMfyAsync(id));
}
