using Ombudsman.DataAccessLayer.Models.Infos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ombudsman.DataAccessLayer.Models.Docs;

[Table("doc_application_param", Schema = "ombudsman")]
public class AppilcationParam
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("application_id")]
    public int DocId { get; set; }
    
    [Column("parameter_id")]
    public int ParamId { get; set; }

    [Column("parameter_value")]
    public string ParameterValue { get; set; }

    [ForeignKey("DocId")]
    public virtual Application Application { get; set; } = null!;
    
    [ForeignKey("ParamId")]
    public virtual Parameter Parameter { get; set; } = null!;

}
