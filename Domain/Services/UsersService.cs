using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class UsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(User user, string password) =>
            await _repository.InsertAsync(user, password);

        public async Task<List<User>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<User?> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<User?> UpdateAsync(int id, User user) =>
            await _repository.UpdateAsync(id, user);

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
