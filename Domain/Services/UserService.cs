using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool Create(int id, string name, string description)
        {
            User user = new User(id, name, description);
            _repository.CreateAsync(user);

            return true;
        }

        public async Task<List<User>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<User> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);
    }
}
