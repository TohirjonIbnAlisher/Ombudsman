using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects;

public record ModifyOrganizationDTO
{
    [JsonPropertyName("ordinal_code")]
    [MaxLength(10)]
    public string? Code { get; set; } = null!;

    [JsonPropertyName("stir")]
    [MaxLength(20)]
    public string? Stir { get; set; } = null!;

    [JsonPropertyName("name")]
    [MaxLength(500)]
    public string? Name { get; set; } = null!;

    [JsonPropertyName("organization_type_id")]
    public int? OrganizationTypeId { get; set; }

    [JsonPropertyName("parent_organization_id")]
    public int? OrganizationId { get; set; }

    [JsonPropertyName("region_id")]
    public int? RegionId { get; set; }

    [JsonPropertyName("district_id")]
    public int? DistrictId { get; set; }

    [JsonPropertyName("organization_level_id")]
    public int? OrganizationLevelId { get; set; }

    [JsonPropertyName("address")]
    [MaxLength(500)]
    public string? Address { get; set; } = null!;
}
