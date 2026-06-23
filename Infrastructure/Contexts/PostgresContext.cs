using Domain.Models;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public override int SaveChanges()
        {
            SetTimestampsForUsers();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimestampsForUsers();

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(user => new { user.Username, user.Email })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        private void SetTimestampsForUsers()
        {
            var createdEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .OfType<User>();

            foreach (var entity in createdEntities)
            {
                DateTime dateTime = DateTime.UtcNow;
                entity.CreatedAt = dateTime;
                entity.UpdatedAt = dateTime;
            }

            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .OfType<User>();

            foreach (var entity in modifiedEntities)
                entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
