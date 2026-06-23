namespace Application.Dtos.Users
{
    public class CreatedUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
