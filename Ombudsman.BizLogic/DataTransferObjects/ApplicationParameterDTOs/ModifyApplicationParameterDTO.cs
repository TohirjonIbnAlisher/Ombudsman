using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;

public record ModifyApplicationParameterDTO
{
    [JsonPropertyName("application_id")]
    public int DocId { get; set; }

    [JsonPropertyName("parameter_id")]
    public int ParamId { get; set; }

    [JsonPropertyName("parameter_value")]
    public string ParameterValue { get; set; }
}
