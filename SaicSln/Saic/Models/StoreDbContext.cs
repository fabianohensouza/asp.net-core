using Microsoft.EntityFrameworkCore;
using Saic.Models.AuxiliarModels;

namespace Saic.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }

        public DbSet<Coop> Coops => Set<Coop>();
        public DbSet<RespCoop> RespCoops => Set<RespCoop>();
        public DbSet<Unidade> Unidades => Set<Unidade>();
        public DbSet<Firewall> Firewalls => Set<Firewall>();
        public DbSet<Switch> Switches => Set<Switch>();
        public DbSet<Servidor> Servidores => Set<Servidor>();
        public DbSet<Link> Links => Set<Link>();
        public DbSet<Vlan> Vlans => Set<Vlan>();
        public DbSet<Ad> Ads => Set<Ad>();

        //Auxiliar models
        public DbSet<Equipe> Equipes => Set<Equipe>();
        public DbSet<Fabricante> Fabricantes => Set<Fabricante>();
        public DbSet<TipoAuxiliar> TipoAuxiliares => Set<TipoAuxiliar>();
        public DbSet<SistOp> SistOps => Set<SistOp>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship (Coop -> RespCoop)
            modelBuilder.Entity<Coop>()
                .HasOne(c => c.RespCoop)
                .WithMany(r => r.Coops)
                .HasForeignKey(c => c.RespID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (RespCoop -> Equipe)
            modelBuilder.Entity<RespCoop>()
                .HasOne(c => c.Equipe)
                .WithMany(r => r.RespCoops)
                .HasForeignKey(c => c.EquipeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Unidade -> Coop)
            modelBuilder.Entity<Unidade>()
                .HasOne(c => c.Coop)
                .WithMany(r => r.Unidades)
                .HasForeignKey(c => c.CoopID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Firewall -> Coop)
            modelBuilder.Entity<Firewall>()
                .HasOne(c => c.Coop)
                .WithMany(r => r.Firewalls)
                .HasForeignKey(c => c.CoopID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Firewall -> Unidade)
            modelBuilder.Entity<Firewall>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Firewalls)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Switch -> Coop)
            modelBuilder.Entity<Switch>()
                .HasOne(c => c.Coop)
                .WithMany(r => r.Switches)
                .HasForeignKey(c => c.CoopID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Switch -> Unidade)
            modelBuilder.Entity<Switch>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Switches)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Firewall -> Fabricante)
            modelBuilder.Entity<Firewall>()
                .HasOne(c => c.Fabricante)
                .WithMany()
                .HasForeignKey(c => c.FabricanteID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Link -> Unidade)
            modelBuilder.Entity<Link>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Links)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Link -> TipoAuxiliar)
            modelBuilder.Entity<Link>()
                .HasOne(c => c.TipoLink)
                .WithMany()
                .HasForeignKey(c => c.TipoLinkID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Vlan -> Unidade)
            modelBuilder.Entity<Vlan>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Vlans)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Servidor -> Coop)
            modelBuilder.Entity<Servidor>()
                .HasOne(c => c.Coop)
                .WithMany(r => r.Servidores)
                .HasForeignKey(c => c.CoopID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Servidor -> Unidade)
            modelBuilder.Entity<Servidor>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Servidores)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Servidor -> Fabricante)
            modelBuilder.Entity<Servidor>()
                .HasOne(c => c.Fabricante)
                .WithMany()
                .HasForeignKey(c => c.FabricanteID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Servidor -> SistOp)
            modelBuilder.Entity<Servidor>()
                .HasOne(c => c.SistOp)
                .WithMany()
                .HasForeignKey(c => c.SistOpID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Ad -> Coop)
            modelBuilder.Entity<Ad>()
                .HasOne(c => c.Coop)
                .WithMany()
                .HasForeignKey(c => c.CoopID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Ad -> DCPrimario)
            modelBuilder.Entity<Ad>()
                .HasOne(c => c.DCPrimario)
                .WithMany()
                .HasForeignKey(c => c.DCPrimarioID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Ad -> DCSecundario)
            modelBuilder.Entity<Ad>()
                .HasOne(c => c.DCSecundario)
                .WithMany()
                .HasForeignKey(c => c.DCSecundarioID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}