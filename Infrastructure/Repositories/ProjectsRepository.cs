using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Infrastructure.DbModels;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private PostgresContext _context;

        public ProjectsRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Project project)
        {
            await _context.AddAsync(project.ToDbModel());
            await _context.SaveChangesAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            ProjectDbModel? project = await _context.Projects.FirstOrDefaultAsync(project => project.Id == id);

            return project?.ToEntity();
        }

        public async Task<List<Project>> GetAllAsync() =>
            await _context.Projects.Select(project => project.ToEntity()).ToListAsync();
    }
}
