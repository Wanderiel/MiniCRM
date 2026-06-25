using Application.Dtos.Projects;
using Domain.Models;

namespace Application.Extentions
{
    public static class ProjectExtentions
    {
        public static Project ToEntity(this CreatedProjectDto projectDto) =>
            new Project()
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                Status = projectDto.Status,
            };

        public static CreatedProjectDto ToDto(this Project project) =>
            new CreatedProjectDto()
            {
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status,
            };

    }
}
