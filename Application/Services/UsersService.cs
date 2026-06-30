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

        public async Task Register(CreatedUserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Username))
                throw new ArgumentException($"Имя пользователя не может быть пустым.");

            User? findUser = await _repository.GetByUsernameAsymc(userDto.Username);

            if (findUser is null == false)
                throw new ArgumentException("Имя пользователя уже занято, придумайте другое.");

            Email email = Email.Create(userDto.Email);
            findUser = await _repository.GetByEmailAsync(email);

            if (findUser is null == false)
                throw new ArithmeticException("Email уже используется, укажите другой.");

            FullName fullName = FullName.Create(userDto.FirstName, userDto.LastName);
            string passwordHash = PasswordHasher.Hash(userDto.Password1, userDto.Password2);
            User user = new User(userDto.Username, email, fullName, userDto.AvatarUrl, passwordHash);
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

            await UpdateUser(user, updateUser);

            return true;
        }

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

        private async Task UpdateUser(User user, UpdateUserDto updateUser)
        {
            UpdateEmail(user, updateUser.Email);
            UpdateFullName(user, updateUser.FirstName, updateUser.LastName);
            user.UpdateAvatatUrl(updateUser.AvatarUrl);
            await _repository.SaveChangesAsync();
        }

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
