using Domain.Models;
using Infrastructure.DbModels;

namespace Infrastructure.Extensions
{
    public static class UserMapping
    {
        public static UserDbModel ToDbModel(this User user) =>
            new UserDbModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            };

        public static User ToEntity(this UserDbModel dbModel) =>
            new User()
            {
                Id = dbModel.Id,
                Username = dbModel.Username,
                Email = dbModel.Email,
                PasswordHash = dbModel.PasswordHash,
                FirstName = dbModel.FirstName,
                LastName = dbModel.LastName,
                AvatarUrl = dbModel.AvatarUrl,
                CreatedAt = dbModel.CreatedAt,
                UpdatedAt = dbModel.UpdatedAt,
            };
    }
}
