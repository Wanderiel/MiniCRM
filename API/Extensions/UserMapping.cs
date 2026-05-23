using API.Dtos;
using Domain.Models;

namespace API.Extensions
{
    public static class UserMapping
    {
        public static User ToEntity(this CreatedUserDto userDto) =>
            new User(userDto.Name);
    }
}
