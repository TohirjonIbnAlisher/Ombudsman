using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;

public record ModifyUserAccountDTO
{
    [JsonPropertyName("fio")]
    [MaxLength(50)]
    public string? Fio { get; set; } = null!;

    [JsonPropertyName("email")]
    [MaxLength(25)]
    public string? Email { get; set; } = null!;

    [Column("login")]
    [StringLength(25)]
    public string? Login { get; set; } = null!;

    [JsonPropertyName("organization_id")]
    public int? OrganizationId { get; set; }

    [JsonPropertyName("position_id")]
    public int? PositionId { get; set; }

    [JsonPropertyName("role_id")]
    public int? RoleId { get; set; }
}
