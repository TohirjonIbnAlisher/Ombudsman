using Microsoft.AspNetCore.Authorization;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.BizLogic.Attributes.ControllerAttributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(PermissionEnums permission)
        : base(permission.ToString())
    {
    }
}
