namespace Identity.Api.Models
{
    public class RegisterUserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
    }
}
