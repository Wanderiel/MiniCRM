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
            _repository.Create(id, name, description);

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
