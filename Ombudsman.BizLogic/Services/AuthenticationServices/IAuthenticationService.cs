using Ombudsman.BizLogic.DataTransferObjects.AuthenticationDTOs;

namespace Ombudsman.BizLogic.Services.AuthenticationServices;

public interface IAuthenticationService
{
    Task<TokenDTO> LoginAsync(LogInDTO authenticationDto);

    Task<TokenDTO> RefreshTokenAsync(RefreshTokenDTO refreshTokenDto);
}