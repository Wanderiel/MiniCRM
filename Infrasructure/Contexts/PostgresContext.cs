using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class PostgresContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
