using Microsoft.EntityFrameworkCore;

namespace Saic.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }

        public DbSet<Coop> Coops => Set<Coop>();
        public DbSet<RespCoop> RespCoops => Set<RespCoop>();
        public DbSet<Equipe> Equipes => Set<Equipe>();

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

            modelBuilder.Entity<RespCoop>()
                .HasOne(c => c.Equipe)
                .WithMany(r => r.RespCoops)
                .HasForeignKey(c => c.EquipeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}