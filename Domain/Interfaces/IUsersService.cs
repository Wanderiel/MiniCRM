using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUsersService
    {
        Task AddAsync(User user, string password);
        Task<User?> GetAsync(int id);
        Task<List<User>> GetAllAsync();
    }
}