using Ombudsman.BizLogic.DataTransferObjects.CommonDTOs;

namespace Ombudsman.BizLogic.DataTransferObjects.AppClassParamDTOs;

public record GetAppClassParamDTO : BaseDTO
{
    public int AppClassId { get; set; } 
    public int ParamId { get; set; }
}
