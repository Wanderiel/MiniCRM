using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        bool Create(string name);
        Task<User> GetAsync(int id);
        Task<List<User>> GetAllAsync();
    }
}