using Domain.HashGenerators;
using Domain.Models.Exceptions;

namespace Domain.Models.Users
{
    public class PasswordHasher
    {
        private const int MINLENGTH = 8;

        public static string Hash(string password, string passwordRepeat)
        {
            if (password == passwordRepeat == false)
                throw new InvalidPasswordException("Пароли не совпадают");

            Validate(password);

            return SHA256HashGenerator.Compute(password);
        }

        private static void Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidPasswordException($"Пароль не должен быть пустым");

            if (password.Length < MINLENGTH)
                throw new InvalidPasswordException($"Пароль должен быть не менее {MINLENGTH} символов");
        }
    }
}
