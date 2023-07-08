using Microsoft.AspNetCore.Authorization;

namespace Ombudsman.BizLogic.Attributes.ControllerAttributes;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission { get; private set; }
}
