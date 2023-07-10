using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record GetParameterDTO : BaseDTO
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

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("parameter_type")]
    public string ParameterType { get; set; }
}
