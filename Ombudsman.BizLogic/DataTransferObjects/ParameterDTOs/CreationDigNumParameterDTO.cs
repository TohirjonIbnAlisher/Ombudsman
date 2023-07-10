using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record CreationDigNumParameterDTO : CommonParameterDTO
{
    [JsonPropertyName("unit_of_measure_id")]
    public int? UnitOfMeasureId { get; set; }

    [JsonPropertyName("regular_exp_digit_field")]
    [MaxLength(500)]
    public string? RegularExpDigitField { get; set; }

    [JsonPropertyName("after_digit")]
    public short? AfterDigit { get; set; }

    [JsonPropertyName("number_digit")]
    public short? NumberDigit { get; set; }

    [JsonPropertyName("initial_value_digit_field")]
    public int? InitialValueDigitField { get; set; }
}
