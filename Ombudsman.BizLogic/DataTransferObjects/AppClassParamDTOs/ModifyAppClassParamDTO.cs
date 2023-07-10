namespace Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;

public record ModifyAppClassParamDTO
{
    public int AppClassId { get; set; }
    public int ParamId { get; set; }
}
