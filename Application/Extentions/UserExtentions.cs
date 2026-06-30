using Application.Dtos.Users;
using Domain.Models;
using Domain.Models.Users;

namespace Application.Extentions
{
    public static class UserExtentions
    {
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
