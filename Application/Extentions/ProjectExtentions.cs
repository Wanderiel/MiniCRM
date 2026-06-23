using Application.Dtos;
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
    }
}
