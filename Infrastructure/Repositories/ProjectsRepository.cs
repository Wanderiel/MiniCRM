using Application.Dtos.Projects;
using Application.Extentions;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
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
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CreatedProjectDto>> GetAllAsync() =>
            await _context.Projects.Select(project => project.ToDto()).ToListAsync();

        public async Task<CreatedProjectDto?> GetByIdAsync(int id)
        {
            Project? project = await _context.Projects.FirstOrDefaultAsync(project => project.Id == id);

            return project?.ToDto();
        }

        public async Task<bool> UpdateAsync(int id, Project updateProject)
        {
            Project? project = await _context.Projects.FindAsync(id);

            if (project == null)
                return false;

            //project.Update(updateProject);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Project? project = await _context.Projects.FindAsync(id);

            if (project == null)
                return false;

            _context.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
