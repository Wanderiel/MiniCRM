using Application.Dtos.Users;
using Application.Extentions;
using Application.Interfaces;
using Domain.Models.Exceptions;
using Domain.Models.Users;

namespace Application.Services;

public class UsersService
{
    private readonly IUsersRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public UsersService(IUsersRepository repository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task Register(CreatedUserDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Username))
            throw new ArgumentException($"Имя пользователя не может быть пустым.");

        if (await _repository.HasUserByUsernameAsync(userDto.Username))
            throw new ArgumentException("Имя пользователя уже занято, придумайте другое.");

        Email email = Email.Create(userDto.Email);

        if (await _repository.HasUserByEmailAsync(email))
            throw new ArithmeticException("Email уже используется, укажите другой.");

        FullName fullName = FullName.Create(userDto.FirstName, userDto.LastName);

        if (userDto.Password1 == userDto.Password2 == false)
            throw new InvalidPasswordException("Пароли должны совпадать.");

        string passwordHash = _passwordHasher.Hash(userDto.Password1);
        User user = new User(userDto.Username, email, fullName, userDto.AvatarUrl, passwordHash);
        await _repository.InsertAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> Login(LoginUserDto loginUser)
    {
        if (string.IsNullOrWhiteSpace(loginUser.Login))
            return false;

        User? user = await _repository.GetByUsernameAsync(loginUser.Login);

        if (user == null)
            return false;

        return _passwordHasher.Compare(loginUser.Password, user.PasswordHash);
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
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        bool result = await _repository.DeleteAsync(id);

        if (result)
            await _unitOfWork.SaveChangesAsync();

        return result;
    }

    private async Task UpdateUser(User user, UpdateUserDto updateUser)
    {
        UpdateEmail(user, updateUser.Email);
        UpdateFullName(user, updateUser.FirstName, updateUser.LastName);
        user.UpdateAvatatUrl(updateUser.AvatarUrl);
    }

    private void UpdateEmail(User user, string? newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail))
            return;

        Email email = Email.Create(newEmail);
        user.UpdateEmail(email);
    }

    private void UpdateFullName(User user, string? newFirstName, string? newLastName)
    {
        if (string.IsNullOrWhiteSpace(newFirstName) && string.IsNullOrWhiteSpace(newLastName))
            return;

        string firstname = string.IsNullOrWhiteSpace(newFirstName) ? user.FullName.FirstName : newFirstName;
        string lastName = string.IsNullOrWhiteSpace(newLastName) ? user.FullName.LastName : newLastName;

        FullName fullName = FullName.Create(firstname, lastName);
        user.UpdateFullName(fullName);
    }
}
