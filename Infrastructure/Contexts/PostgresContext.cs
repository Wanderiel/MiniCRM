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
            modelBuilder.Entity<User>(bilder =>
            {
                bilder.Property(u => u.Email)
                    .HasConversion(
                        email => email.Value,
                        email => Email.Create(email));

                bilder.OwnsOne(
                    user => user.FullName,
                    fName =>
                    {
                        fName.Property(p => p.FirstName).HasColumnName("FirstName");
                        fName.Property(p => p.LastName).HasColumnName("LastName");
                    });

                bilder.HasIndex(u => u.Email)
                    .IsUnique();

                bilder.HasIndex(user => user.Username)
                    .IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }

        private void SetTimestampsForUsers()
        {
            var modifiedEntities = ChangeTracker.Entries<User>()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntities)
                entry.Property(e => e.UpdatedAt).CurrentValue = DateTime.UtcNow;
        }
    }
}
