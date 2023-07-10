using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_application_classification_parameter", Schema = "ombudsman")]
public class ApplicationClassificationParameter
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("application_classification_id")]
    public int AppClassId { get; set; }

    [Column("parameter_id")]
    public int ParamId { get; set; }

    [ForeignKey("AppClassId")]
    public virtual ApplicationClassification? ParentApplicationClassification { get; set; }

    [ForeignKey("ParamId")]
    public virtual Parameter Parameter { get; set; }
}
