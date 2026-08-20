using Application.Dtos.Users;
using FluentValidation;

namespace API.Validators;

public class RegisterValidator : AbstractValidator<CreatedUserDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Имя пользователя не может быть пустым.")
            .MinimumLength(3).WithMessage("Имя пользователя должно содержать минимум 3 символа.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email не может быть пустым.")
            .EmailAddress().WithMessage("Некорректный формат Email.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя не может быть пустым.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия не может быть пустой.");

        RuleFor(x => x.Password1)
            .NotEmpty().WithMessage("Пароль не может быть пустым.")
            .MinimumLength(8).WithMessage("Пароль должен содержать минимум 8 символов.");

        RuleFor(x => x.Password2)
            .Equal(x => x.Password1).WithMessage("Пароли должны совпадать.");
    }
}
