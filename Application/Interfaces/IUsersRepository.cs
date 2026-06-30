using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IUsersRepository
    {
        Task InsertAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> HasUserByUsernameAsync(string username);
        Task<bool> HasUserByEmailAsync(Email email);
        Task SaveChangesAsync();
        Task<bool> DeleteAsync(int id);
    }
}
