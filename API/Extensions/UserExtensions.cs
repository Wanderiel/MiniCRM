using API.Dtos;
using Domain.Models;

namespace API.Extensions
{
    public static class UserExtensions
    {
        public static User ToEntity(this CreatedUserDto userDto) =>
            new User()
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                AvatarUrl = userDto.AvatarUrl,
            };
    }
}
