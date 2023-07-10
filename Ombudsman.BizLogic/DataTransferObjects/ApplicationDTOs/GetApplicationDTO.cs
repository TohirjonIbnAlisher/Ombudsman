using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ApplicationDTOs;

public record GetApplicationDTO : BaseDTO
{
    [JsonPropertyName("doc_number")]
    [MaxLength(10)]
    public string DocNumber { get; set; } = null!;

    [JsonPropertyName("doc_date")]
    public DateOnly DocDate { get; set; }

    [JsonPropertyName("application_type")]
    public string ApplicationType { get; set; }

    [JsonPropertyName("business_sector")]
    public string BusinessSector { get; set; }

    [JsonPropertyName("base_application_classification")]
    public string BaseApplicationClassification { get; set; }

    [JsonPropertyName("application_classification_2")]
    public string ApplicationClassification2 { get; set; }

    [JsonPropertyName("application_classification_3")]
    public string ApplicationClassification3 { get; set; }

    [JsonPropertyName("application_classification_4_id")]
    public string ApplicationClassification4 { get; set; }
}
