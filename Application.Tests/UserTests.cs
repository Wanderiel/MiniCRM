using Application.Interfaces;
using Domain.Models.Users;
using Moq;

namespace Application.Tests;

public class UserTests
{
    [Fact]
    public void Register_Should_RegisterUser_When_EmailIsFree()
    {
        var repository = new Mock<IUsersRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var passwordHasher = new Mock<IPasswordHasher>();

        repository.Setup(x => x.HasUserByEmailAsync(It.IsAny<Email>()))
            .ReturnsAsync(false);

        passwordHasher.Setup(x => x.Hash(It.IsAny<string>()))
            .Returns("hash");
    }
}
