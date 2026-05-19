using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User> GetByIdAsync(int id);

        Task<List<User>> GetAllAsync();
    }
}
