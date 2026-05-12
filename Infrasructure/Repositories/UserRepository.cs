using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private PostgresContext _context;
        private readonly List<User> _users = new List<User>();

        public UserRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
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
