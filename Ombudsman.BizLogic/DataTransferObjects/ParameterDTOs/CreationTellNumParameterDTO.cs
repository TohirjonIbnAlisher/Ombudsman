using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record CreationTellNumParameterDTO : CommonParameterDTO
{
    [JsonPropertyName("mask")]
    [MaxLength(15)]
    public string? Mask { get; set; }

    [JsonPropertyName("initial_value_tel_num")]
    [StringLength(15)]
    public string? InitialValueTelNum { get; set; }

    [JsonPropertyName("tell_num_length")]
    public short? TellNumLength { get; set; }

    [JsonPropertyName("regular_exp_digit_tell_num")]
    [MaxLength(500)]
    public string? RegularExpDigitTellNum { get; set; }
}
