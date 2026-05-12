using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void Create(int id, string name, string description)
        {
            User user = new User(id, name, description);
            _users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToArray();
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}
