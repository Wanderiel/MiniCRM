using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task InsertAsync(User user, string password);
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
