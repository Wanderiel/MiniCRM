using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IUsersRepository
    {
        Task InsertAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task SaveChangesAsync();
        Task<bool> DeleteAsync(int id);
    }
}
