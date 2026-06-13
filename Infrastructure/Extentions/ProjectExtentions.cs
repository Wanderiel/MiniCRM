using Domain.Models;
using Infrastructure.DbModels;

namespace Infrastructure.Extentions
{
    public static class ProjectExtentions
    {
        public static ProjectDbModel ToDbModel(this Project project) =>
            new ProjectDbModel()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status,
                CreatedAt = project.CreatedAt,
            };

        public static Project ToEntity(this ProjectDbModel dbModel) =>
            new Project()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Description = dbModel.Description,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
                Status = dbModel.Status,
                CreatedAt= dbModel.CreatedAt,
                Sources = "Database",
            };
    }
}
