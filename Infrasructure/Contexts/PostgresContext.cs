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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
