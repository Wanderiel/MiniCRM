using Application.Dtos.Users;
using Application.Extentions;
using Application.Interfaces;
using Domain.Models;
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
            Email email = Email.Create(userDto.Email);
            FullName fullName = FullName.Create(userDto.FirstName, userDto.LastName);
            PasswordHash passwordHash = PasswordHash.Create(userDto.Password1, userDto.Password2);
            User user = new User(userDto.Username, email, fullName, userDto.AvatarUrl, passwordHash);

            await _repository.InsertAsync(user);
        }

        public async Task<List<UserDto>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<UserDto?> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<bool?> UpdateAsync(int id, User user) =>
            await _repository.UpdateAsync(id, user);

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
