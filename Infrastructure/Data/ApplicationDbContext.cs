using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Domain.Entities.Task> Task { get; set; }
    }
}
