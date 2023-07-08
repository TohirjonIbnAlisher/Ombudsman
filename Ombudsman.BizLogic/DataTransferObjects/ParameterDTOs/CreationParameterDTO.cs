using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record CreationParameterDTO
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

    // 

    [JsonPropertyName("multiple_choice_directory")]
    public bool? MultipleChoiceDirectory { get; set; }

    [JsonPropertyName("directory_id")]
    public int? DirectoryId { get; set; }

    [JsonPropertyName("initial_value_date")]
    public DateOnly? InitialValueDate { get; set; }

    [JsonPropertyName("greatest_value_date")]
    public DateOnly? GreatestValueDate { get; set; }

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
