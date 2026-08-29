using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Models.Users;

public partial record Email
{
    private Email() { }

    private Email(string value) =>
        Value = value;

    public string Value { get; init; }

    public static Email Create(string value)
    {
        if (IsValid(value) == false)
            throw new ArgumentException("Неверный формат Email адреса");

        value = value.Trim().ToLowerInvariant();

        return new Email(value);
    }

    private static bool IsValid(string? value)
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
