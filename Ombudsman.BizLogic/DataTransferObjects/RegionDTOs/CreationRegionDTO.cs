using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.RegionDTOs;

public record CreationRegionDTO
{
    [JsonPropertyName("code")]
    [MaxLength(3)]
    public string Code { get; set; } = null!;

    [JsonPropertyName("full_name")]
    [MaxLength(500)]
    public string FullName { get; set; } = null!;

    [JsonPropertyName("short_name")]
    [MaxLength(250)]
    public string ShortName { get; set; } = null!;

    [JsonPropertyName("state_id")]
    public int StateId { get; set; }
}
