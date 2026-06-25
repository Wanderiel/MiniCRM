using Application.Dtos.Users;
using Domain.Models;
using Domain.Models.Users;

namespace Application.Extentions
{
    public static class UserExtentions
    {
        public static User ToEntity(this CreatedUserDto userDto)
        {
            Email email = Email.Create(userDto.Email);
            FullName fullName = FullName.Create(userDto.FirstName, userDto.LastName);
            PasswordHash passwordHash = PasswordHash.Create(userDto.Password1, userDto.Password2);

            return new User(userDto.Username, email, fullName, userDto.AvatarUrl, passwordHash.Value);
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto()
            {
                Username = user.Username,
                Email = user.Email.Value,
                FirstName = user.FullName.FirstName,
                LastName = user.FullName.LastName,
                AvatarUrl = user.AvatarUrl
            };
        }
    }
}
