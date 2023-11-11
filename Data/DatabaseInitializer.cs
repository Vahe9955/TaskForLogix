using Microsoft.EntityFrameworkCore;

namespace TaskForLogix.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationContext _context;
        public DatabaseInitializer(ApplicationContext context)
        {
            _context = context;
        }

        virtual public async Task SeedAsync()
        {
            await MigrateAsync();
        }

        private async Task MigrateAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
        }

    }
}
