namespace Domain.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Email Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Sources { get; set; }
    }
}
