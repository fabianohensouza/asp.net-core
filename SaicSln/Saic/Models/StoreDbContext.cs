using Microsoft.EntityFrameworkCore;

namespace Saic.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
        public DbSet<Coop> Coops => Set<Coop>();
    }
}