using Domain.Models;
using Domain.Models.Users;
using Infrastructure.DbModels;

namespace Infrastructure.Extentions
{
    public static class UserExtentions
    {
        public static UserDbModel ToDbModel(this User user) =>
            new UserDbModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email.Value,
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
                Email = Email.Create(dbModel.Email),
                FirstName = dbModel.FirstName,
                LastName = dbModel.LastName,
                AvatarUrl = dbModel.AvatarUrl,
                CreatedAt = dbModel.CreatedAt,
                UpdatedAt = dbModel.UpdatedAt,
                Sources = "Database",
            };

        public static void Update(this UserDbModel dbModel, User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email.Value) == false)
                dbModel.Email = user.Email.Value;

            if (string.IsNullOrWhiteSpace(user.FirstName) == false)
                dbModel.FirstName = user.FirstName;

            if (string.IsNullOrWhiteSpace(user.LastName) == false)
                dbModel.LastName = user.LastName;

            if (string.IsNullOrWhiteSpace(user.AvatarUrl) == false)
                dbModel.AvatarUrl = user.AvatarUrl;
        }
    }
}
