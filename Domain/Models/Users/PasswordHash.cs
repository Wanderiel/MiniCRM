using Domain.HashGenerators;
using Domain.Models.Exceptions;

namespace Domain.Models.Users
{
    public class PasswordHash
    {
        private const int MINLENGTH = 8;

        private PasswordHash(string passwordHash) => Value = passwordHash;

        public string Value { get; }

        public static PasswordHash Create(string password, string passwordRepeat)
        {
            if (password == passwordRepeat == false)
                throw new InvalidPasswordException("Пароли не совпадают");

            Validate(password);
            string passwordHash = SHA256HashGenerator.Compute(password);

            return new PasswordHash(passwordHash);
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
