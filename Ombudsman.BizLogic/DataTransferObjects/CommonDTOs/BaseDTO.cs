using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;

public record BaseDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}
