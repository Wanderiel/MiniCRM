using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Email
    {
        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static Email Init(string value)
        {
            return new Email(value);
        }

        public bool IsValid()
        {
            var email = new EmailAddressAttribute();

            return email.IsValid(Value);
        }
    }
}
