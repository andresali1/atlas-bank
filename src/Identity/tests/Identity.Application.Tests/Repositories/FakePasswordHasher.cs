using Identity.Application.Interfaces;

namespace Identity.Application.Tests.Repositories
{
    public class FakePasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return $"HASHED_{password}";
        }
    }
}
