using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProjectsRepository
    {
        Task InsertAsync(Project project);
        Task<Project?> GetByIdAsync(int id);
        Task<List<Project>> GetAllAsync();
    }
}
