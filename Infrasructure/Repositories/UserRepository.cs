using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private PostgresContext _context;

        public UserRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToArray();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }
    }
}
