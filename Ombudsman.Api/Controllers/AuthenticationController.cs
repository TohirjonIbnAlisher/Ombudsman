using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.DataTransferObjects.AuthenticationDTOs;
using Ombudsman.BizLogic.Services.AuthenticationServices;

namespace Ombudsman.Api.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost, AllowAnonymous]
    public async ValueTask<ActionResult<TokenDTO>> LoginAsync(LogInDTO authenticationDto)
    {
        return Ok(await this._authenticationService.LoginAsync(authenticationDto));
    }

    [HttpPost("refreshToken"), AllowAnonymous]
    public async ValueTask<ActionResult<TokenDTO>> RefreshTokenAsync(RefreshTokenDTO refreshTokenDto)
    {
        return Ok(await this._authenticationService.RefreshTokenAsync(refreshTokenDto));
    }
}
