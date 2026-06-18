using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Models
{
    public partial class Email
    {
        private readonly string _value;

        private Email(string value) => _value = value;

        public string Value => _value;

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

            return EmailRegex().IsMatch(value);
        }

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();
    }
}
