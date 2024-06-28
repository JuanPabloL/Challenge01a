using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Factories
{
    public class ApplicationDbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<Infrastructure.Data.ApplicationDbContext> options;

        public ApplicationDbContextFactory(DbContextOptions<Data.ApplicationDbContext> options)
        {
            this.options = options;
        }

        public DbContext Create()
        {
            return new Data.ApplicationDbContext(this.options);
        }
    }

}
