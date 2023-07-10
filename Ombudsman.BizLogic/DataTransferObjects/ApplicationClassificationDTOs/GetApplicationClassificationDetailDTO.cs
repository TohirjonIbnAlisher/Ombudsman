using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationClassificationDTOs;

public record GetApplicationClassificationDetailDTO : CommonApplicationClassificationDTO
{
    [JsonPropertyName("organization")]
    public string Organization { get; set; }

    [JsonPropertyName("organization_level")]
    public string OrganizationLevel { get; set; }
}
