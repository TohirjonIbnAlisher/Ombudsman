using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;

public record GetUserAccountDetailsDTO : CommonUserAccountDTO
{
    [JsonPropertyName("login")]
    public string Login { get; set; } = null!;

    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;

    [JsonPropertyName("position")]
    public string Position { get; set; }

}
