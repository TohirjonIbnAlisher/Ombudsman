using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ombudsman.DataAccessLayer.Models.Enums;

[Table("enum_state", Schema = "ombudsman")]
public class State
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(10)]
    public string Name { get; set; } = null!;
}
