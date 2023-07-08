using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;

public record CreationApplicationClassificationDTO
{
    [JsonPropertyName("grouper")]
    public bool Grouper { get; set; }

    [JsonPropertyName("code")]
    [MaxLength(15)]
    public string Code { get; set; } = null!;

    [JsonPropertyName("full_name")]
    [MaxLength(500)]
    public string FullName { get; set; } = null!;

    [JsonPropertyName("short_name")]
    [MaxLength(250)]
    public string ShortName { get; set; } = null!;

    [JsonPropertyName("state_id")]
    public int StateId { get; set; }

    [JsonPropertyName("organization_id")]
    public int OrganizationId { get; set; }

    [JsonPropertyName("application_classification_id")]
    public int? ApplicationClassificationId { get; set; }

    [JsonPropertyName("organization_level_id")]
    public int OrganizationLevelId { get; set; }
}
