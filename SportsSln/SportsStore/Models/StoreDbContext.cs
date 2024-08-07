using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<CartLine> CartLines => Set<CartLine>();
    }
}
