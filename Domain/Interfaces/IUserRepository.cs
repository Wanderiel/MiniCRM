using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(int id, string name, string description);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}
