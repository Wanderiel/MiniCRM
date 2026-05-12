using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}
