using API.Dtos;
using Domain.Models;

namespace API.Extentions
{
    public static class UserExtentions
    {
        public static User ToEntity(this CreatedUserDto userDto) =>
            new User()
            {
                Username = userDto.Username,
                Email = Email.Init(userDto.Email),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                AvatarUrl = userDto.AvatarUrl,
            };

        public static User ToEntity(this UpdateUserDto userDto) =>
            new User()
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                AvatarUrl = userDto.AvatarUrl,
            };
    }
}
