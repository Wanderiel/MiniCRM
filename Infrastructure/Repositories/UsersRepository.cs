using Application.Interfaces;
using Domain.Models.Users;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PostgresContext _context;

        public UsersRepository(PostgresContext context) => _context = context;

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users.FindAsync(id);

        public async Task<bool> HasUserByUsernameAsync(string username) =>
            await _context.Users.AnyAsync(u => u.Username == username);

        public async Task<bool> HasUserByEmailAsync(Email email) =>
            await _context.Users.AnyAsync(u => u.Email == email);

        public async Task<bool> DeleteAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
