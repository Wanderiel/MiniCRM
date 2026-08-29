using Domain.Models.Users;

namespace Application.Interfaces;

public interface IUserLookup
{
    Task<bool> HasUserByUsernameAsync(string username);

    Task<bool> HasUserByEmail(Email email);
}
