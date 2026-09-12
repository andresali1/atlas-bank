using Identity.Infrastructure.Security;

namespace Identity.Infrastructure.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void Hash_ShouldReturnDifferentValueThanOriginalPassword()
        {
            // Arrange
            var hasher = new PasswordHasher();
            var password = "1234";

            // Act
            var hash = hasher.Hash(password);

            // Assert
            Assert.NotEqual(password, hash);
            Assert.False(string.IsNullOrWhiteSpace(hash));
        }
        [Fact]
        public void Hash_ShouldGenerateDifferentHashesForSamePassword()
        {
            // Arrange
            var hasher = new PasswordHasher();
            var password = "1234";

            // Act
            var hash1 = hasher.Hash(password);
            var hash2 = hasher.Hash(password);

            // Assert
            Assert.NotEqual(hash1, hash2);
        }
    }
}
