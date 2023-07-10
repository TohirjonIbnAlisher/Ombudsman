using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record CreationSanaParameterDTO : CommonParameterDTO
{
    [JsonPropertyName("initial_value_date")]
    public string? InitialValueDate { get; set; }

    [JsonPropertyName("greatest_value_date")]
    public string? GreatestValueDate { get; set; }
}
