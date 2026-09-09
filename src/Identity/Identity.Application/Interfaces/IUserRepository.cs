using Identity.Application.Models;
using Identity.Domain;

namespace Identity.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByEmail(string email);
        Task<User> Add(User user);
    }
}
