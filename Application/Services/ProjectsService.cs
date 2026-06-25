using Application.Dtos.Projects;
using Application.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ProjectsService
    {
        private readonly IProjectsRepository _repository;

        public ProjectsService(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Project project) =>
            await _repository.InsertAsync(project);

        public async Task<List<CreatedProjectDto>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<CreatedProjectDto?> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(int id, Project project) =>
            await _repository.UpdateAsync(id, project);

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
