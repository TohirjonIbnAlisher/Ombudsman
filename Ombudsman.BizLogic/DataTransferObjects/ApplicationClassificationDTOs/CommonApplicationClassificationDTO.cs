using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;

public record CommonApplicationClassificationDTO : BaseDTO
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

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("application_classification")]
    public string? ApplicationClassification { get; set; }

}
