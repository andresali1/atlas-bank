using Identity.Api.Models;
using Identity.Application;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly RegisterUser registerUserUseCase;

        public IdentityController(RegisterUser registerUser)
        {
            registerUserUseCase = registerUser;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var applicationRequest = new Application.Models.RegisterUserRequest
            {
                Email = request.Email,
                Password = request.Password
            };

            var user = await registerUserUseCase.Execute(applicationRequest);

            return Created(
                $"/identity/{user.Id}",
                new RegisterUserResponse { Id = user.Id, Email = user.Email }
            );
        }
    }
}
