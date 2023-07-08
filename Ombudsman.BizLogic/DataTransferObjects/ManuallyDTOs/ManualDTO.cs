using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ManuallyDTOs;

public record ManualDTO : BaseDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; } 
}
