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
        //public DbSet<ProjectDbModel> Projects { get; set; }
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

            modelBuilder.Entity<UserDbModel>()
                .Property(user => user.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<UserDbModel>()
                .Property(user => user.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<ProjectDbModel>()
            //    .HasMany(p => p.Tasks)
            //    .WithOne()
            //    .HasForeignKey(p => p.ProjectId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<TaskItemDbModel>()
            //    .HasOne(t => t.Project)
            //    .WithMany(p => p.Tasks)
            //    .HasForeignKey(t => t.ProjectId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        private void SetTimestampsForUsers()
        {
            var createdEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .OfType<UserDbModel>()
                .ToArray();

            foreach (var entity in createdEntities)
                entity.CreatedAt = DateTime.UtcNow;

            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .OfType<UserDbModel>()
                .ToArray();

            foreach (var entity in modifiedEntities)
                entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
