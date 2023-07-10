using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.AssigningPermissionDTOs;

public record ModifyAssigningPermissionDTO
{
    [JsonPropertyName("permission_id")]
    public int PermissionId { get; set; }

    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }
}
