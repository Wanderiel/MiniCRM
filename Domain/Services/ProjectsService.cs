using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
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

        public async Task<List<Project>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Project?> GetAsync(int id) =>
            await _repository.GetByIdAsync(id);
    }
}
