using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Infos;

namespace Ombudsman.DataAccessLayer.Models.Enums;

[Table("enum_role", Schema = "ombudsman")]
public class Role
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    public virtual ICollection<UserAccount> InfoUserAccounts { get; set; } = new List<UserAccount>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}
