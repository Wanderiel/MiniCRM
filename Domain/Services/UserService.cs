using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
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
