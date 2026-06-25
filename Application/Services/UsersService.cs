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
            User user = userDto.ToEntity();
            await _repository.InsertAsync(user);
        }

        public async Task<List<UserDto>> GetAllAsync() =>
            (await _repository.GetAllAsync()).Select(user => user.ToDto()).ToList();

        public async Task<UserDto?> GetAsync(int id) =>
            (await _repository.GetByIdAsync(id))?.ToDto();

        public async Task<bool> UpdateAsync(int id, UpdateUserDto updateUser)
        {
            User? user = await _repository.GetByIdAsync(id);

            if (user == null)
                return false;

            UpdateEmail(user, updateUser.Email);
            UpdateFullName(user, updateUser.FirstName, updateUser.LastName);
            user.UpdateAvatatUrl(updateUser.AvatarUrl);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

        private void UpdateEmail(User user, string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                return;

            Email email = Email.Create(newEmail);
            user.UpdateEmail(email);
        }

        private void UpdateFullName(User user, string newFirstName, string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName) && string.IsNullOrWhiteSpace(newLastName))
                return;

            string firstname = string.IsNullOrWhiteSpace(newFirstName) ? user.FullName.FirstName : newFirstName;
            string lastName = string.IsNullOrWhiteSpace(newLastName) ? user.FullName.LastName : newLastName;

            FullName fullName = FullName.Create(firstname, lastName);
            user.UpdateFullName(fullName);
        }
    }
}
