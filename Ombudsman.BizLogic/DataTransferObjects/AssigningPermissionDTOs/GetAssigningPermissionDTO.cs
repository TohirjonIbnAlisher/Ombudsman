using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;

public record GetAssigningPermissionDTO : BaseDTO
{
    [JsonPropertyName("permission")]
    public string Permission { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }
}
