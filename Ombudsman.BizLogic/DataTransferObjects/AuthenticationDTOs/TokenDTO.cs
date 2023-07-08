using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.AuthenticationDTOs;
public record TokenDTO
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;

    [JsonPropertyName("access_token_expire_date")]
    public DateTime AccessTokenExpireDate { get; set; }
}
