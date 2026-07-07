using Domain.Models.Users;

namespace Application.Interfaces;

public interface IUsersRepository
{
    Task InsertAsync(User user);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> HasUserByUsernameAsync(string username);
    Task<bool> HasUserByEmailAsync(Email email);
    Task<bool> DeleteAsync(int id);
}
