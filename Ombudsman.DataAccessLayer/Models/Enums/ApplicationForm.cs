using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ombudsman.DataAccessLayer.Models.Enums;

[Table("enum_application_form", Schema = "ombudsman")]
public class ApplicationForm
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(500)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}

