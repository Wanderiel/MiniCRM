using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task InsertAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
    }
}
