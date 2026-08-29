using Application.Dtos.Users;
using Application.Interfaces;
using Domain.Models.Users;
using FluentValidation;

namespace API.Validators;

public class RegisterValidator : AbstractValidator<RegisteredUserDto>
{
    private const int MinimumLengthUsername = 3;
    private const int MinimumLengthPassword = 8;

    private readonly IUserLookup _userLookup;

    public RegisterValidator(IUserLookup userLookup)
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Имя пользователя не может быть пустым.")
            .MinimumLength(MinimumLengthUsername).WithMessage($"Имя пользователя должно содержать минимум {MinimumLengthUsername} символа.")
            .MustAsync(HasUserByUsername).WithMessage("Имя пользователя уже занято, придумайте другое.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email не может быть пустым.")
            .EmailAddress().WithMessage("Некорректный формат Email.")
            .MustAsync(HasUserByEmail).WithMessage("Email уже используется, укажите другой.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя не может быть пустым.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия не может быть пустой.");

        RuleFor(x => x.Password1)
            .NotEmpty().WithMessage("Пароль не может быть пустым.")
            .MinimumLength(MinimumLengthPassword).WithMessage($"Пароль должен содержать минимум {MinimumLengthPassword} символов.");

        RuleFor(x => x.Password2)
            .Equal(x => x.Password1).WithMessage("Пароли должны совпадать.");
        _userLookup = userLookup;
    }

    private async Task<bool> HasUserByUsername(string username, CancellationToken token) =>
        await _userLookup.HasUserByUsernameAsync(username) == false;

    private async Task<bool> HasUserByEmail(string email, CancellationToken token) =>
        await _userLookup.HasUserByEmail(Email.Create(email)) == false;
}
