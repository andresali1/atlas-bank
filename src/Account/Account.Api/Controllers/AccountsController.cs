using Account.Api.Models;
using Account.Application;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly CreateAccount createAccount;

        public AccountsController(CreateAccount createAccount)
        {
            this.createAccount = createAccount;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountRequest request)
        {
            var account = await createAccount.Execute(
                request.CustomerId,
                request.InitialBalance);

            var response = new CreateAccountResponse
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountType = account.AccountType,
                AccountStatus = account.AccountStatus
            };

            return Created(
                $"/accounts/{account.Id}",
                response);
        }
    }
}
