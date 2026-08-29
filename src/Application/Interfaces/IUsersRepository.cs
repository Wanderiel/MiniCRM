using Domain.Models.Users;

namespace Application.Interfaces;

public interface IUsersRepository
{
    void Insert(User user);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> HasUserByUsernameAsync(string username);
    Task<bool> HasUserByEmailAsync(Email email);
    void Delete(User user);
}
