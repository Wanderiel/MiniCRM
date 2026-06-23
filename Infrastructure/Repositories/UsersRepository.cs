using Application.Interfaces;
using Domain.HashGenerators;
using Domain.Models.Users;
using Infrastructure.Contexts;
using Infrastructure.DbModels;
using Infrastructure.Extentions;
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

        public async Task InsertAsync(User user, string password)
        {
            UserDbModel dbModel = user.ToDbModel();
            dbModel.PasswordHash = SHA256HashGenerator.Compute(password);

            await _context.Users.AddAsync(dbModel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.Select(user => user.ToEntity()).ToListAsync();

        public async Task<User?> GetByIdAsync(int id)
        {
            UserDbModel? user = await _context.Users.FindAsync(id);
            return user?.ToEntity();
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            UserDbModel? dbModel = await _context.Users.FindAsync(id);

            if (dbModel == null)
                return null;

            dbModel.Update(user);
            _context.SaveChanges();

            return dbModel.ToEntity();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            UserDbModel? dbModel = await _context.Users.FindAsync(id);

            if (dbModel == null)
                return false;

            _context.Users.Remove(dbModel);
            _context.SaveChanges();

            return true;
        }
    }
}
