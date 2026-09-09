using Identity.Application.Models;
using Identity.Application.Tests.Repositories;
using Identity.Domain;

namespace Identity.Application.Tests.Tests
{
    public class IdentityServiceTest
    {
        [Fact]
        public async Task RegisterUser_WhenEmailIsEmpty_ShouldRejectRegister()
        {
            // Arrange
            var repository = new FakeUserRepository();
            var hasher = new FakePasswordHasher();
            var useCase = new RegisterUser(repository, hasher);
            var user = new RegisterUserRequest()
            {
                Email = "",
                Password = "1234"
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(user));
            Assert.Equal("Email is required", exception.Message);
        }
        [Fact]
        public async Task RegisterUser_WhenPasswordIsEmpty_ShouldRejectRegister()
        {
            // Arrange
            var repository = new FakeUserRepository();
            var hasher = new FakePasswordHasher();
            var useCase = new RegisterUser(repository, hasher);
            var user = new RegisterUserRequest()
            {
                Email = "miuser@mail.com",
                Password = ""
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(user));
            Assert.Equal("Password is required", exception.Message);
        }
        [Fact]
        public async Task RegisterUser_WhenEmailAlreadyExists_ShouldRejectRegister()
        {
            // Arrange
            var repository = new FakeUserRepository();
            var hasher = new FakePasswordHasher();
            var useCase = new RegisterUser(repository, hasher);
            var user = new RegisterUserRequest()
            {
                Email = "user2@mail.com",
                Password = "1234"
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(user));
            Assert.Equal("Email already exists", exception.Message);
        }
        [Fact]
        public async Task RegisterUser_WithValidData_ShouldRegister()
        {
            // Arrange
            var repository = new FakeUserRepository();
            var hasher = new FakePasswordHasher();
            var useCase = new RegisterUser(repository, hasher);
            var user = new RegisterUserRequest()
            {
                Email = "good@mail.com",
                Password = "1234"
            };

            // Act
            User createdUser = await useCase.Execute(user);

            // Assert
            Assert.NotNull(createdUser);
            Assert.Equal(user.Email, createdUser.Email);
            Assert.Equal("HASHED_1234", createdUser.PasswordHash);
        }
    }
}
