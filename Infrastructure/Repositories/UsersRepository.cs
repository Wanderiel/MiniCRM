using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Infrastructure.DbModels;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private PostgresContext _context;

        public UsersRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user.ToDbModel());
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.Select(user => user.ToEntity()).ToListAsync();

        public async Task<User?> GetByIdAsync(int id)
        {
            UserDbModel? user = await _context.Users.FindAsync(id);
            return user?.ToEntity();
        }
    }
}
