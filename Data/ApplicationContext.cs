using Microsoft.EntityFrameworkCore;

namespace TaskForLogix.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
    }
}
