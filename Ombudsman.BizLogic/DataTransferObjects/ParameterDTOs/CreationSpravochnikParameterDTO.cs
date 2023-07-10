using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

public record CreationSpravochnikParameterDTO : CommonParameterDTO
{
    [JsonPropertyName("multiple_choice_directory")]
    public bool? MultipleChoiceDirectory { get; set; }

    [JsonPropertyName("sys_table_id")]
    public int? SysTableId { get; set; }



    

    

    
}
