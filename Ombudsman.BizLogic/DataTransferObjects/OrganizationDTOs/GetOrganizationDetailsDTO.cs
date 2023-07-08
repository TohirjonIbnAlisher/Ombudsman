using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.OrganizationDTOs;

public record GetOrganizationDetailsDTO : CommonOrganizationDTO
{
    [JsonPropertyName("address")]
    public string Address { get; set; } = null!;
}
