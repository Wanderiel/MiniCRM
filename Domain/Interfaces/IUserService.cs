using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        bool Create(int id, string name, string description);

        User Get(int id);

        IEnumerable<User> GetAll();
    }
}