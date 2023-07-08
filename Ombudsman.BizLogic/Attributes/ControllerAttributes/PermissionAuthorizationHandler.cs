using Microsoft.AspNetCore.Authorization;
using Ombudsman.DataAccessLayer.Authentications;
using Ombudsman.DataAccessLayer.Repositories.UserAccounts;

namespace Ombudsman.BizLogic.Attributes.ControllerAttributes;

public class PermissionAuthorizationHandler
    : AuthorizationHandler<PermissionRequirement>
{
    private readonly IUserAccountRepository individualRepository;

    public PermissionAuthorizationHandler(IUserAccountRepository individualRepository)
    {
        this.individualRepository = individualRepository;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var userEmailClaim = context
            .User
            .Claims
            .Where(x => x.Type == CustomClaimNames.Login)
            .FirstOrDefault();

        if (userEmailClaim is null)
        {
            context.Fail();

            return;
        }

        bool hasAccess = await individualRepository.HasPermissionAsync(
            userEmailClaim.Value,
            requirement.Permission);

        if (!hasAccess)
        {
            context.Fail();

            return;
        }

        context.Succeed(requirement);
    }
}
