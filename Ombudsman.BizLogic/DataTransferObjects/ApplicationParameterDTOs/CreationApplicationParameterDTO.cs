using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;

public record CreationApplicationParameterDTO 
{
    [JsonPropertyName("application_id")]
    public int DocId { get; set; }

    [JsonPropertyName("parameter_id")]
    public int ParamId { get; set; }

    [JsonPropertyName("parameter_value")]
    public string ParameterValue { get; set; }
}
