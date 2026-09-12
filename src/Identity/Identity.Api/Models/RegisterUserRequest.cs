namespace Identity.Api.Models
{
    public class RegisterUserRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
