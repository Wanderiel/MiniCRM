using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users
{
    public class User
    {
        public User(string userName, Email email, FullName fullName, string? avatarUrl, string passwordHash)
        {
            Username = userName;
            Email = email;
            FullName = fullName;
            AvatarUrl = avatarUrl;
            PasswordHash = passwordHash;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required, StringLength(50)]
        public string Username { get; private set; }
        [Required]
        public Email Email { get; private set; }
        [Required]
        public FullName FullName { get; private set; }
        [StringLength(500)]
        public string? AvatarUrl { get; private set; }
        [Required, StringLength(500)]
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void UpdateEmail(Email email)
        {
            if (email is null)
                throw new ArgumentNullException(nameof(email));

            Email = email;
        }

        public void UpdateFullName(FullName fullName)
        {
            if (fullName is null)
                throw new ArgumentNullException(nameof(fullName));
        }

        public void UpdateAvatatUrl(string value)
        {
            if (string.IsNullOrWhiteSpace(value) == false)
                AvatarUrl = value;
        }
    }
}
