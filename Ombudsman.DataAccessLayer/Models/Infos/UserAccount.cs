using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_user_account", Schema = "ombudsman")]
public class UserAccount
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

    [Column("salt")]
    public string Salt { get; set; } = null!;

    [Column("refresh_token")]
    [StringLength(50)]
    public string? RefreshToken { get; private set; }

    [Column("refresh_token_expire_date")]
    public DateTime? RefreshTokenExpireDate { get; private set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("position_id")]
    public int PositionId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [ForeignKey("OrganizationId")]
    public virtual Organization Organization { get; set; } = null!;

    [ForeignKey("PositionId")]
    public virtual Position Position { get; set; } = null!;

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;

    public void UpdateRefreshToken(
        string refreshToken,
        int expireDateInMinutes = 1440)
    {
        RefreshToken = refreshToken;

        RefreshTokenExpireDate = DateTime.UtcNow
            .AddMinutes(expireDateInMinutes);
    }
}

