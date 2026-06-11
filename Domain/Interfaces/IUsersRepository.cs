using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task InsertAsync(User user, string password);
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}
