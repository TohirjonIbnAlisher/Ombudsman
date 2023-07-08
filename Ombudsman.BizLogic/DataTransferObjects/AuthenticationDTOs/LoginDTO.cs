using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.AuthenticationDTOs;

public record LogInDTO
{
    [JsonPropertyName("login")]
    public string Login { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
