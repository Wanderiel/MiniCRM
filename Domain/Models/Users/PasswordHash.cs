using Domain.HashGenerators;
using Domain.Models.Exceptions;

namespace Domain.Models.Users
{
    public class PasswordHash
    {
        private static int s_minLength = 8;
        private string _passwordHash;

        private PasswordHash(string passwordHash) => _passwordHash = passwordHash;

        public string Value => _passwordHash;

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

            if (password.Length < s_minLength)
                throw new InvalidPasswordException($"Пароль должен быть не менее {s_minLength} символов");
        }
    }
}
