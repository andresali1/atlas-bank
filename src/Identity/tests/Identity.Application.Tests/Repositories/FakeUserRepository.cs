using Identity.Application.Interfaces;
using Identity.Application.Models;
using Identity.Domain;

namespace Identity.Application.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> existentUsers = new List<User>() {
            new User() { Email="user1@mail.com", PasswordHash = "HASH_123" },
            new User() { Email="user2@mail.com", PasswordHash = "HASH_456" },
            new User() { Email="user3@mail.com", PasswordHash = "HASH_789" },
        };
        public Task<bool> ExistsByEmail(string email)
        {
            bool userExists = existentUsers.Any(x => x.Email == email);
            return Task.FromResult(userExists);
        }
        public Task<User> Add(User user)
        {
            existentUsers.Add(user);

            return Task.FromResult(user);
        }
    }
}
