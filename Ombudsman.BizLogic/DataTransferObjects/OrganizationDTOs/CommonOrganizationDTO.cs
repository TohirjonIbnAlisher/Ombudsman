using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.OrganizationDTOs;

public record CommonOrganizationDTO : BaseDTO
{
    [JsonPropertyName("ordinal_code")]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    [JsonPropertyName("stir")]
    [MaxLength(20)]
    public string Stir { get; set; } = null!;

    [JsonPropertyName("name")]
    [MaxLength(500)]
    public string Name { get; set; } = null!;

    [JsonPropertyName("district")]
    public string District { get; set; } = null!;

    [JsonPropertyName("parent_organization")]
    public string? ParentOrganizationName { get; set; }

    [JsonPropertyName("organization_level")]
    public string OrganizationLevel { get; set; } = null!;

    [JsonPropertyName("organization_type")]
    public string OrganizationType { get; set; } = null!;

    [JsonPropertyName("region")]
    public string Region { get; set; } = null!;

    [JsonPropertyName("state")]
    public string State { get; set; } = null!;
}
