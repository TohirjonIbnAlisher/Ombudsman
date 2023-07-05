using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_user_account", Schema = "ombudsman")]
public partial class InfoUserAccount
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fio")]
    [StringLength(50)]
    public string Fio { get; set; } = null!;

    [Column("email")]
    [StringLength(25)]
    public string Email { get; set; } = null!;

    [Column("login")]
    [StringLength(25)]
    public string Login { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("position_id")]
    public int PositionId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("InfoUserAccounts")]
    public virtual InfoOrganization Organization { get; set; } = null!;

    [ForeignKey("PositionId")]
    [InverseProperty("InfoUserAccounts")]
    public virtual EnumPosition Position { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("InfoUserAccounts")]
    public virtual EnumRole Role { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoUserAccounts")]
    public virtual EnumState State { get; set; } = null!;
}
