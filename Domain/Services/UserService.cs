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
            _repository.Create(user);

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User Get(int id)
        {
            return _repository.GetById(id);
        }
    }
}
