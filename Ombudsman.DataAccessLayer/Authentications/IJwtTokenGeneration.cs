using Ombudsman.DataAccessLayer.Models.Infos;
using System.IdentityModel.Tokens.Jwt;

namespace Ombudsman.DataAccessLayer.Authentications;

public interface IJwtTokenGeneration
{
    JwtSecurityToken GenerateAccessToken(
        UserAccount individual);
    string GenerateRefreshToken();
}