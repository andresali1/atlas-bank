using Identity.Application.Interfaces;
using Identity.Application.Models;
using Identity.Domain;

namespace Identity.Application
{
    public class RegisterUser
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        public RegisterUser(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<User> Execute(RegisterUserRequest user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("Email is required");
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("Password is required");
            }
            if (await userRepository.ExistsByEmail(user.Email))
            {
                throw new ArgumentException("Email already exists");
            }

            return await userRepository.Add(
                new User
                {
                    Email = user.Email,
                    PasswordHash = passwordHasher.Hash(user.Password)
                }
            );
        }
    }
}
