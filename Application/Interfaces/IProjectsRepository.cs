using Application.Dtos.Projects;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IProjectsRepository
    {
        Task InsertAsync(Project project);
        Task<CreatedProjectDto?> GetByIdAsync(int id);
        Task<List<CreatedProjectDto>> GetAllAsync();
        Task<bool> UpdateAsync(int id, Project project);
        Task<bool> DeleteAsync(int id);
    }
}
