using Application.Dtos.Users;
using Application.Extentions;
using Application.Interfaces;
using Domain.Models.Users;

namespace Application.Services
{
    public class UsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CreatedUserDto userDto)
        {
            User user = userDto.ToEntity();
            await _repository.InsertAsync(user);
        }

        public async Task<List<UserDto>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<UserDto?> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(int id, UpdateUserDto user) =>
            await _repository.UpdateAsync(id, user);

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
