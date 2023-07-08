using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ombudsman.DataAccessLayer.Models.Enums;

[Table("enum_status", Schema = "ombudsman")]
public class Status
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;
}
