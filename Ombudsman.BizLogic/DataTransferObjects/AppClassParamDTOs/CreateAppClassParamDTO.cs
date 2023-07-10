namespace Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;

public record CreateAppClassParamDTO 
{
    public int AppClassId { get; set; }
    public int ParamId { get; set; }
}
