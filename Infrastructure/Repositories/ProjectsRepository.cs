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
            await _context.AddAsync(project.ToDbModel());
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync() =>
            await _context.Projects.Select(project => project.ToEntity()).ToListAsync();

        public async Task<Project?> GetByIdAsync(int id)
        {
            ProjectDbModel? project = await _context.Projects.FirstOrDefaultAsync(project => project.Id == id);

            return project?.ToEntity();
        }

        public async Task<bool> UpdateAsync(int id, Project project)
        {
            ProjectDbModel? dbModel = await _context.Projects.FindAsync(id);

            if (dbModel == null)
                return false;

            dbModel.Update(project);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ProjectDbModel? dbModel = await _context.Projects.FindAsync(id);

            if (dbModel == null)
                return false;

            _context.Remove(dbModel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
