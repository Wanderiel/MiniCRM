using Domain.Models.Users;
using FluentAssertions;

namespace Domain.Tests
{
    public class EmailTests
    {
        [Fact]
        public void Create_Should_CreateEmail_WhenValidData()
        {
            string emailString = "valid@email.com";
            Email email = Email.Create(emailString);
            email.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("invalidemail.com")]
        [InlineData("@invalidemail.com")]
        [InlineData("invalidemail@.com")]
        [InlineData("invalid@email")]
        public void Create_Should_Throw_WhenInvalidData(string emailString)
        {
            Action action = () => Email.Create(emailString);
            action.Should().Throw<ArgumentException>();
        }
    }
}
