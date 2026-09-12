using Identity.Application;
using Identity.Application.Models;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Repositories;
using Identity.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Tests
{
    public class IdentityInfrastructureTests
    {
        [Fact]
        public async Task AddUser_ShouldPersistUser()
        {
            // Arrange
            var connectionString =
                "Host=localhost;Port=5433;Database=atlas_identity;Username=identity;Password=identity";

            var options = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseNpgsql(connectionString)
                .Options;
            await using var context = new IdentityDbContext(options);

            var repository = new UserRepository(context);
            var user = new User()
            {
                Email = $"integration-{Guid.NewGuid()}@test.com",
                PasswordHash = "HASH_TEST"
            };

            // Act
            User createdUser = await repository.Add(user);

            // Assert
            Assert.NotEqual(0, createdUser.Id);

            var userInDatabase = await context.Users
                .FirstOrDefaultAsync(x => x.Email == createdUser.Email);

            Assert.NotNull(userInDatabase);
            Assert.Equal(user.Email, userInDatabase.Email);
            Assert.Equal(user.PasswordHash, userInDatabase.PasswordHash);

            context.Users.Remove(userInDatabase);
            await context.SaveChangesAsync();
        }
    }
}
