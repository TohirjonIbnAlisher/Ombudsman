using Ombudsman.DataAccessLayer.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_permission_role", Schema = "ombudsman")]
public class PermissionRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("permission_id")]
    public int PermissionId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }
    
    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("PermissionId")]
    public virtual Permission Permission { get; set; } = null!;

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;
    
    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}
