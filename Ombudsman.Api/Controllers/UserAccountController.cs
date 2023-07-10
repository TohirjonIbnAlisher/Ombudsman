using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;
using Ombudsman.BizLogic.Services.UserAccountservices;
using Ombudsman.DataAccessLayer.Models.SystemEnums;

namespace Ombudsman.Api.Controllers
{
    [Route("api/userAccount")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        [HttpPost]
        [HasPermission(PermissionEnums.PostUserAccountAsync)]
        public async ValueTask<IActionResult> PostUserAccountAsync(
            CreationUserAccountDTO creationUserAccountDTO)
            => Created("", await this.userAccountService.CreateUserAccountAsync(creationUserAccountDTO));

        [HttpPut("{id}")]
        [HasPermission(PermissionEnums.PutUserAccountAsync)]
        public async ValueTask<IActionResult> PutUserAccountAsync(
            int id,
            ModifyUserAccountDTO modifyUserAccountDTO)
            => Ok(await this.userAccountService.ModifyUserAccountAsync(id, modifyUserAccountDTO));

        [HttpGet("{id}")]
        [HasPermission(PermissionEnums.GetUserAccountByIdAsync)]
        public async ValueTask<IActionResult> GetUserAccountByIdAsync(int id)
            => Ok(await this.userAccountService.RetrieveUserAccountByIdAsync(id));

        [HttpGet("selectedList")]
        [HasPermission(PermissionEnums.GetAllUserAccounts)]
        public IActionResult GetAllUserAccounts()
            => Ok(this.userAccountService.RetrieveUserAccounts());

        [HttpGet]
        [HasPermission(PermissionEnums.Get)]
        public IActionResult Get()
            => Ok(this.userAccountService.RetrieveAsync());

        [HttpDelete("{id}")]
        [HasPermission(PermissionEnums.DeleteUserAccountAsync)]
        public async ValueTask<IActionResult> DeleteUserAccountAsync(int id)
            => Ok(await this.userAccountService.RemoveUserAccountAsync(id));
    }
}
