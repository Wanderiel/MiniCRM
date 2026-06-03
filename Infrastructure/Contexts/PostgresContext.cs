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
        public DbSet<TaskItemDbModel> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectDbModel>()
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskItemDbModel>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
