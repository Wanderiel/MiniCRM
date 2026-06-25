namespace Application.Dtos.Users
{
    public class CreatedUserDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public required string Password1 { get; set; }
        public required string Password2 { get; set; }
    }
}
