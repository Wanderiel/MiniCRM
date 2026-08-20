using Application.Dtos.Users;
using FluentValidation;

namespace API.Validators;

public class RegisterValidator : AbstractValidator<CreatedUserDto>
{
    private const int MinimumLengthUsername = 3;
    private const int MaximumLengthPassword = 8;

    public RegisterValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Имя пользователя не может быть пустым.")
            .MinimumLength(MinimumLengthUsername).WithMessage($"Имя пользователя должно содержать минимум {MinimumLengthUsername} символа.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email не может быть пустым.")
            .EmailAddress().WithMessage("Некорректный формат Email.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя не может быть пустым.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия не может быть пустой.");

        RuleFor(x => x.Password1)
            .NotEmpty().WithMessage("Пароль не может быть пустым.")
            .MinimumLength(MaximumLengthPassword).WithMessage($"Пароль должен содержать минимум {MaximumLengthPassword} символов.");

        RuleFor(x => x.Password2)
            .Equal(x => x.Password1).WithMessage("Пароли должны совпадать.");
    }
}
