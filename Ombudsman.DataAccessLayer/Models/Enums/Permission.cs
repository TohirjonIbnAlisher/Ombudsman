using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ombudsman.DataAccessLayer.Models.Enums;

[Table("enum_permission", Schema = "ombudsman")]
public class Permission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("permission_name")]
    public string PermissionName { get; set; }

    [Column("permission_interface")]
    public string PermissionInterfaceName { get; set; }

    [Column("permission_route_name")]
    public string PermissionRouteName { get; set; }
}
