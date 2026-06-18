using Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<ProjectDbModel> Projects { get; set; }
        //public DbSet<TaskItemDbModel> TaskItems { get; set; }

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
            modelBuilder.Entity<UserDbModel>()
                .HasIndex(user => new { user.Username, user.Email })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        private void SetTimestampsForUsers()
        {
            var createdEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .OfType<UserDbModel>();

            foreach (var entity in createdEntities)
            {
                DateTime dateTime = DateTime.UtcNow;
                entity.CreatedAt = dateTime;
                entity.UpdatedAt = dateTime;
            }

            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .OfType<UserDbModel>();

            foreach (var entity in modifiedEntities)
                entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
