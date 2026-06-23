using Domain.Models;

namespace Application.Interfaces
{
    public interface IProjectsRepository
    {
        Task InsertAsync(Project project);
        Task<Project?> GetByIdAsync(int id);
        Task<List<Project>> GetAllAsync();
        Task<bool> UpdateAsync(int id, Project project);
        Task<bool> DeleteAsync(int id);
    }
}
