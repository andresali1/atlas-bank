using Identity.Application.Interfaces;
using Identity.Domain;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<User> hasher = new();

        public string Hash(string password)
        {
            var user = new User();

            return hasher.HashPassword(user, password);
        }
    }
}
