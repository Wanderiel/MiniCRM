using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        bool Create(int id, string name, string description);

        Task<User> GetAsync(int id);

        Task<List<User>> GetAllAsync();
    }
}