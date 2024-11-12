using Microsoft.EntityFrameworkCore;

namespace Saic.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }

        public DbSet<Coop> Coops => Set<Coop>();

        public DbSet<RespCoop> RespCoops => Set<RespCoop>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship
            modelBuilder.Entity<Coop>()
                .HasOne(c => c.RespCoop)
                .WithMany(r => r.Coops)
                .HasForeignKey(c => c.RespID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}