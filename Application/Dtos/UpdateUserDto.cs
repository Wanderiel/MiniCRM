using Domain.Models;

namespace Application.Dtos
{
    public class UpdateUserDto
    {
        public Email Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
