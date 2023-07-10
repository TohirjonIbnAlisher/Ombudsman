using Ombudsman.DataAccessLayer.Models.Infos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ombudsman.DataAccessLayer.Models.Enums;

[Table("enum_sys_table", Schema = "ombudsman")]
public class SysTable
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("interface_name")]
    [StringLength(500)]
    public string InterFaceName { get; set; } = null!;

    [Column("sys_table_name")]
    [StringLength(250)]
    public string SysTableName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    public virtual ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}
