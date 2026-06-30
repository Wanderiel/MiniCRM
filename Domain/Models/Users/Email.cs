using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Models.Users
{
    public record Email
    {
        private Email() { }

        private Email(string value) => Value = value;

        public string Value {  get; private set; }

        public static Email Create(string value)
        {
            value = value.Trim().ToLowerInvariant();

            if (IsValid(value) == false)
                throw new ArgumentException("Неверный формат Email адреса");

            return new Email(value);
        }

        private static bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            var email = new EmailAddressAttribute();

            if (email.IsValid(value) == false)
                return false;

            return Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            ;
        }
    }
}
