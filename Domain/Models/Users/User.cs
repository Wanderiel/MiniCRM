namespace Domain.Models.Users
{
    public class User
    {
        public User(string userName, Email email, FullName fullName, string? avatarUrl, PasswordHash passwordHash)
        {
            Username = userName;
            Email = email;
            FullName = fullName;
            AvatarUrl = avatarUrl;
            PasswordHash = passwordHash;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public Email Email { get; private set; }
        public FullName FullName { get; private set; }
        public string? AvatarUrl { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void Update(User updateUser)
        {
            if (string.IsNullOrWhiteSpace(updateUser.AvatarUrl) == false)
                AvatarUrl = updateUser.AvatarUrl;
        }
    }
}
