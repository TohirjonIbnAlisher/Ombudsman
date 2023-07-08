using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects;

public record CreationMfyDTO
{
    [JsonPropertyName("code")]
    [MaxLength(5)]
    public string Code { get; set; } = null!;

    [JsonPropertyName("full_name")]
    [MaxLength(500)]
    public string FullName { get; set; } = null!;

    [JsonPropertyName("short_name")]
    [MaxLength(250)]
    public string ShortName { get; set; } = null!;

    [JsonPropertyName("region_id")]
    public int RegionId { get; set; }

    [JsonPropertyName("district_id")]
    public int DistrictId { get; set; }

    [JsonPropertyName("state_id")]
    public int StateId { get; set; }
}
