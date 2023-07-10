using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationDTOs;

public record CreateApplicationDTO
{
    [JsonPropertyName("doc_number")]
    [MaxLength(10)]
    public string DocNumber { get; set; } = null!;

    [JsonPropertyName("doc_date")]
    public string DocDate { get; set; }

    [JsonPropertyName("application_type_id")]
    public int ApplicationTypeId { get; set; }

    [JsonPropertyName("business_sector_id")]
    public int BusinessSectorId { get; set; }

    [JsonPropertyName("base_application_classification_id")]
    public int BaseApplicationClassificationId { get; set; }

    [JsonPropertyName("application_classification_2_id")]
    public int ApplicationClassification2Id { get; set; }

    [JsonPropertyName("application_classification_3_id")]
    public int ApplicationClassification3Id { get; set; }

    [JsonPropertyName("application_classification_4_id")]
    public int ApplicationClassification4Id { get; set; }
}
