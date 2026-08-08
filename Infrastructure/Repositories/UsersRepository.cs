using Application.Interfaces;
using Domain.Models.Users;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly PostgresContext _context;

    public UsersRepository(PostgresContext context) =>
        _context = context;

    public void Insert(User user) =>
        _context.Users.Add(user);

    public async Task<List<User>> GetAllAsync() =>
        await _context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await _context.Users.FindAsync(id);

    public async Task<User?> GetByUsernameAsync(string username) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<bool> HasUserByUsernameAsync(string username) =>
        await _context.Users.AnyAsync(u => u.Username == username);

    public async Task<bool> HasUserByEmailAsync(Email email) =>
        await _context.Users.AnyAsync(u => u.Email == email);

    public void Delete(User user) =>
        _context.Users.Remove(user);
}
