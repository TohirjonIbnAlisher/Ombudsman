using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record CommonParameterDTO
{
    [JsonPropertyName("code")]
    [MaxLength(15)]
    public string Code { get; set; } = null!;

    [JsonPropertyName("full_name")]
    [MaxLength(500)]
    public string FullName { get; set; } = null!;

    [JsonPropertyName("short_name")]
    [MaxLength(250)]
    public string ShortName { get; set; } = null!;

    [JsonPropertyName("required_field")]
    public bool RequiredField { get; set; }

    [JsonPropertyName("state_id")]
    public int StateId { get; set; }

    [JsonPropertyName("parameter_type_id")]
    public int ParameterTypeId { get; set; }
}
