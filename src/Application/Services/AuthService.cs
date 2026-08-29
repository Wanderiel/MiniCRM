using Application.Dtos.Users;
using Application.Interfaces;
using Domain.Models.Exceptions;
using Domain.Models.Users;

namespace Application.Services;

public class AuthService
{
    private readonly IUsersRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUsersRepository repository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task Register(CreatedUserDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Username))
            throw new ArgumentException($"Имя пользователя не может быть пустым.");

        if (userDto.Password1 == userDto.Password2 == false)
            throw new InvalidPasswordException("Пароли должны совпадать.");

        if (await _repository.HasUserByUsernameAsync(userDto.Username))
            throw new ArgumentException("Имя пользователя уже занято, придумайте другое.");

        Email email = Email.Create(userDto.Email);

        if (await _repository.HasUserByEmailAsync(email))
            throw new ArithmeticException("Email уже используется, укажите другой.");

        FullName fullName = FullName.Create(userDto.FirstName, userDto.LastName);
        string passwordHash = _passwordHasher.CreateHash(userDto.Password1);
        User user = new User(userDto.Username.ToLower(), email, fullName, userDto.AvatarUrl, passwordHash);
        _repository.Insert(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> Login(LoginUserDto loginUser)
    {
        if (string.IsNullOrWhiteSpace(loginUser.Login))
            return false;

        User? user = await _repository.GetByUsernameAsync(loginUser.Login.ToLower());

        if (user == null)
            return false;

        return _passwordHasher.Compare(loginUser.Password, user.PasswordHash);
    }
}
