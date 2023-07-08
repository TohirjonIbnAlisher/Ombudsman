using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;

public record CommonUserAccountDTO : BaseDTO
{
    [JsonPropertyName("fio")]
    public string Fio { get; set; } = null!;

    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("organization")]
    public string Organization { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }
}
