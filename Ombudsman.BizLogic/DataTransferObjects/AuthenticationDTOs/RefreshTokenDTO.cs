using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.AuthenticationDTOs;

public record RefreshTokenDTO
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;
}
