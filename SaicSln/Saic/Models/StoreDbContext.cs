﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Equipe> Equipes => Set<Equipe>();
        public DbSet<Fabricante> Fabricantes => Set<Fabricante>();
        public DbSet<TipoLink> TipoLinks => Set<TipoLink>();
        public DbSet<Firewall> Firewalls => Set<Firewall>();
        public DbSet<Link> Links => Set<Link>();
        public DbSet<Vlan> Vlans => Set<Vlan>();

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
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Firewall -> Unidade)
            modelBuilder.Entity<Firewall>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Firewalls)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Firewall -> Fabricante)
            modelBuilder.Entity<Firewall>()
                .HasOne(c => c.Fabricante)
                .WithMany()
                .HasForeignKey(c => c.FabricanteID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Link -> Unidade)
            modelBuilder.Entity<Link>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Links)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Link -> TipoLink)
            modelBuilder.Entity<Link>()
                .HasOne(c => c.TipoLink)
                .WithMany()
                .HasForeignKey(c => c.TipoLinkID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship (Vlan -> Unidade)
            modelBuilder.Entity<Vlan>()
                .HasOne(c => c.Unidade)
                .WithMany(r => r.Vlans)
                .HasForeignKey(c => c.UnidadeID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}