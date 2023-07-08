using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ombudsman.BizLogic.DataTransferObjects.AuthenticationDTOs;
using Ombudsman.BizLogic.Exceptions;
using Ombudsman.BizLogic.Services.UserAccountservices;
using Ombudsman.DataAccessLayer.Authentications;
using Ombudsman.DataAccessLayer.Repositories.UserAccounts;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Ombudsman.BizLogic.Services.AuthenticationServices;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserAccountService individualService;
    private readonly IUserAccountRepository individualRepository;
    private readonly IJwtTokenGeneration jwtTokenHandler;
    private readonly IPasswordGeneration passwordHasher;
    private readonly JwtOption jwtOptions;

    public AuthenticationService(
        IUserAccountService individualService,
        IUserAccountRepository individualRepository,
        IJwtTokenGeneration jwtTokenHandler,
        IPasswordGeneration passwordHasher,
        IOptions<JwtOption> options)
    {
        this.individualService = individualService;
        this.individualRepository = individualRepository;
        this.jwtTokenHandler = jwtTokenHandler;
        this.passwordHasher = passwordHasher;
        this.jwtOptions = options.Value;
    }

    public async Task<TokenDTO> LoginAsync(
       LogInDTO authenticationDto)
    {
        var user = await this.individualRepository
            .SelectEntityByIdAsync(
                expression: user => user.Login == authenticationDto.Login,
                includes: Array.Empty<string>());

        if (user is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with given credentials not found");
        }

        if (!this.passwordHasher.Verify(
            hash: user.Password,
            password: authenticationDto.Password,
            salt: user.Salt))
        {
            throw new ValidationException("Username or password is not valid");
        }

        string refreshToken = this.jwtTokenHandler
            .GenerateRefreshToken();

        user.UpdateRefreshToken(refreshToken);

        var updatedUser = this.individualRepository
            .Update(user);

        await this.individualRepository.SaveChangeAsync();

        var accessToken = this.jwtTokenHandler
            .GenerateAccessToken(updatedUser);

        return new TokenDTO
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = user.RefreshToken,
            AccessTokenExpireDate = accessToken.ValidTo
        }; 
    }

    public async Task<TokenDTO> RefreshTokenAsync(
        RefreshTokenDTO refreshTokenDto)
    {
        var claimsPrincipal = GetPrincipalFromExpiredToken(
            refreshTokenDto.AccessToken);

        var userId = claimsPrincipal.FindFirst(CustomClaimNames.Id).Value;

        var storageUser = await this.individualRepository
            .SelectEntityByIdAsync( i => i.Id == int.Parse(userId), new string[] { });

        if (!storageUser.RefreshToken.Equals(refreshTokenDto.RefreshToken))
        {
            throw new ValidationException("Refresh token is not valid");
        }

        if (storageUser.RefreshTokenExpireDate <= DateTime.UtcNow)
        {
            throw new ValidationException("Refresh token has already been expired");
        }

        var newAccessToken = this.jwtTokenHandler
            .GenerateAccessToken(storageUser);

        return new TokenDTO
        {
            AccessToken = new JwtSecurityTokenHandler()
                .WriteToken(newAccessToken),

            RefreshToken = storageUser.RefreshToken,
            AccessTokenExpireDate = newAccessToken.ValidTo

        };
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(
        string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = this.jwtOptions.Audience,
            ValidateIssuer = true,
            ValidIssuer = this.jwtOptions.Issuer,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(
            token: accessToken,
            validationParameters: tokenValidationParameters,
            validatedToken: out SecurityToken securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
            SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ValidationException("Invalid token");
        }

        return principal;
    }

}
