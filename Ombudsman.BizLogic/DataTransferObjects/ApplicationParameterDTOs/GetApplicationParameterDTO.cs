using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationParameterDTOs;

public record GetApplicationParameterDTO : BaseDTO
{
    [JsonPropertyName("application")]
    public string Doc { get; set; }

    [JsonPropertyName("parameter")]
    public string Param { get; set; }

    [JsonPropertyName("parameter_value")]
    public string ParameterValue { get; set; }
}
