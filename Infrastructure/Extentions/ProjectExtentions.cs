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

        public static void Update(this ProjectDbModel dbModel, Project project)
        {
            if (string.IsNullOrWhiteSpace(project.Name) == false)
                dbModel.Name = project.Name;

            if (string.IsNullOrWhiteSpace(project.Description) == false)
                dbModel.Description = project.Description;

            if (project.StartDate == null == false)
                dbModel.StartDate = project.StartDate;

            if (project.EndDate == null == false)
                dbModel.EndDate = project.EndDate;

            if (string.IsNullOrWhiteSpace(project.Status) == false)
                dbModel.Status = project.Status;
        }
    }
}
