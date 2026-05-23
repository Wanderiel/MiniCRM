using Domain.Models;
using Infrastructure.DbModels;

namespace Infrastructure.Extensions
{
    public static class UserMapping
    {
        public static UserDbModel ToDbModel(this User user) =>
            new UserDbModel(user.Id, user.Name);

        public static User ToEntity(this UserDbModel dbModel) =>
            new User(dbModel.Id, dbModel.Name);
    }
}
