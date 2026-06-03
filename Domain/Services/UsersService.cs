using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(User user) =>
            await _repository.InsertAsync(user);

        public async Task<List<User>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<User?> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);
    }
}
