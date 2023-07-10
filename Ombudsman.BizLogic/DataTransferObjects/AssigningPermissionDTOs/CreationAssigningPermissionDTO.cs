using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;

public record CreationAssigningPermissionDTO
{
    [JsonPropertyName("permission_id")]
    public int PermissionId { get; set; }

    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }
    
    [JsonPropertyName("state_id")]
    public int StateId { get; set; }
}
