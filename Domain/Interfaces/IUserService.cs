using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(User user);
        Task<User?> GetAsync(int id);
        Task<List<User>> GetAllAsync();
    }
}