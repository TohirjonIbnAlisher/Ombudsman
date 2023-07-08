using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ombudsman.DataAccessLayer.Models.Infos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ombudsman.DataAccessLayer.Authentications;

public class JwtTokenGeneration : IJwtTokenGeneration
{
    private readonly JwtOption jwtOption;

    public JwtTokenGeneration(IOptions<JwtOption> options)
    {
        this.jwtOption = options.Value;
    }

    public JwtSecurityToken GenerateAccessToken(
        UserAccount individual)
    {
        var claims = new[]
        {
            new Claim(CustomClaimNames.Id, individual.Id.ToString()),
            new Claim(CustomClaimNames.Login, individual.Login),
        };

        var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOption.SecretKey));

        var token = new JwtSecurityToken(
            issuer: this.jwtOption.Issuer,
            audience: this.jwtOption.Audience,
            expires: DateTime.UtcNow.AddMinutes(this.jwtOption.AcessTokenExpirationInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(
                key: authSigningKey,
                algorithm: SecurityAlgorithms.HmacSha256)
            );

        return token;
    }

    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        using var randomGenerator =
            RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}
