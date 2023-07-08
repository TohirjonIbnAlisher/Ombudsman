using Ombudsman.DataAccessLayer.Models.Infos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ombudsman.DataAccessLayer.Models.Docs;

[Table("doc_application", Schema = "ombudsman")]
public class Application
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("doc_number")]
    [StringLength(10)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateOnly DocDate { get; set; }

    [Column("application_type_id")]
    public int ApplicationTypeId { get; set; }

    [Column("business_sector_id")]
    public int BusinessSectorId { get; set; }

    [Column("base_application_classification_id")]
    public int BaseApplicationClassificationId { get; set; }

    [Column("application_classification_2_id")]
    public int ApplicationClassification2Id { get; set; }

    [Column("application_classification_3_id")]
    public int ApplicationClassification3Id { get; set; }

    [Column("application_classification_4_id")]
    public int ApplicationClassification4Id { get; set; }

    [Column("region_id")]
    public int? RegionId { get; set; }

    [Column("district_id")]
    public int? DistrictId { get; set; }

    [Column("mfy_id")]
    public int? MfyId { get; set; }

    [Column("address")]
    [StringLength(50)]
    public string? Address { get; set; }

    [Column("area_in_acres")]
    public int? AreaInAcres { get; set; }

    [Column("additional_information")]
    [StringLength(500)]
    public string? AdditionalInformation { get; set; }

    [Column("amount_of_credit")]
    public decimal? AmountOfCredit { get; set; }

    [Column("creadit_date")]
    public DateOnly? CreaditDate { get; set; }

    [Column("percentage_of_credit")]
    public decimal? PercentageOfCredit { get; set; }

    [Column("is_preferential")]
    public bool? IsPreferential { get; set; }

    [ForeignKey("ApplicationClassification2Id")]
    public virtual ApplicationClassification ApplicationClassification2 { get; set; } = null!;

    [ForeignKey("ApplicationClassification3Id")]
    public virtual ApplicationClassification ApplicationClassification3 { get; set; } = null!;

    [ForeignKey("ApplicationClassification4Id")]
    public virtual ApplicationClassification ApplicationClassification4 { get; set; } = null!;

    [ForeignKey("ApplicationTypeId")]
    public virtual ApplicationType ApplicationType { get; set; } = null!;

    [ForeignKey("BaseApplicationClassificationId")]
    public virtual ApplicationClassification BaseApplicationClassification { get; set; } = null!;

    [ForeignKey("BusinessSectorId")]
    public virtual BusinessSector BusinessSector { get; set; } = null!;

    [ForeignKey("DistrictId")]
    public virtual District? District { get; set; }

    [ForeignKey("MfyId")]
    public virtual Mfy? Mfy { get; set; }

    [ForeignKey("RegionId")]
    public virtual Region? Region { get; set; }
}

