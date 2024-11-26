﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saic.Models;

#nullable disable

namespace Saic.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Saic.Models.AuxiliarModels.Equipe", b =>
                {
                    b.Property<Guid>("EquipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EquipeDescrição")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EquipeNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EquipeID");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Saic.Models.AuxiliarModels.Fabricante", b =>
                {
                    b.Property<Guid>("FabricanteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FabricanteNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FabricanteTipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FabricanteID");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("Saic.Models.AuxiliarModels.SistOp", b =>
                {
                    b.Property<Guid>("SistOpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ServidorSuporte")
                        .HasColumnType("datetime2");

                    b.Property<string>("SistOpNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SistOpID");

                    b.ToTable("SistOps");
                });

            modelBuilder.Entity("Saic.Models.AuxiliarModels.TipoLink", b =>
                {
                    b.Property<Guid>("TipoLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoLinkNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TipoLinkID");

                    b.ToTable("TipoLinks");
                });

            modelBuilder.Entity("Saic.Models.Coop", b =>
                {
                    b.Property<Guid>("CoopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Adesao")
                        .HasColumnType("datetime2");

                    b.Property<string>("CoopCidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CoopNome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CoopNumero")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("QtdCompts")
                        .HasColumnType("int");

                    b.Property<Guid?>("RespID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CoopID");

                    b.HasIndex("RespID");

                    b.ToTable("Coops");
                });

            modelBuilder.Entity("Saic.Models.Firewall", b =>
                {
                    b.Property<Guid>("FirewallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoopID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FabricanteID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("FirewallBackup")
                        .HasColumnType("bit");

                    b.Property<string>("FirewallModelo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirewallObs")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FirewallSerial")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<Guid?>("UnidadeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FirewallID");

                    b.HasIndex("CoopID");

                    b.HasIndex("FabricanteID");

                    b.HasIndex("UnidadeID");

                    b.ToTable("Firewalls");
                });

            modelBuilder.Entity("Saic.Models.Link", b =>
                {
                    b.Property<Guid>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkIP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LinkObs")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("LinkProvedor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("TipoLinkID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UnidadeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LinkID");

                    b.HasIndex("TipoLinkID");

                    b.HasIndex("UnidadeID");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Saic.Models.RespCoop", b =>
                {
                    b.Property<Guid>("RespID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EquipeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RespNome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("RespID");

                    b.HasIndex("EquipeID");

                    b.ToTable("RespCoops");
                });

            modelBuilder.Entity("Saic.Models.Servidor", b =>
                {
                    b.Property<Guid>("ServidorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoopID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FabricanteID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServidorAcesso")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ServidorCPU")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("ServidorGarantia")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServidorIDrac")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ServidorIP")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ServidorModelo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ServidorNome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ServidorObs")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ServidorRAM")
                        .HasColumnType("int");

                    b.Property<string>("ServidorSerial")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<Guid>("SistOpID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UnidadeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ServidorID");

                    b.HasIndex("FabricanteID");

                    b.HasIndex("SistOpID");

                    b.ToTable("Servidores");
                });

            modelBuilder.Entity("Saic.Models.Unidade", b =>
                {
                    b.Property<Guid>("UnidadeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoopID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UnidadeNome")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("UnidadeNumero")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("UnidadeObs")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("UnidadeID");

                    b.HasIndex("CoopID");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("Saic.Models.Vlan", b =>
                {
                    b.Property<Guid>("VlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UnidadeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VlanNome")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("VlanObs")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("VlanRangeIP")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("VlanTag")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("VlanID");

                    b.HasIndex("UnidadeID");

                    b.ToTable("Vlans");
                });

            modelBuilder.Entity("Saic.Models.Coop", b =>
                {
                    b.HasOne("Saic.Models.RespCoop", "RespCoop")
                        .WithMany("Coops")
                        .HasForeignKey("RespID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("RespCoop");
                });

            modelBuilder.Entity("Saic.Models.Firewall", b =>
                {
                    b.HasOne("Saic.Models.Coop", "Coop")
                        .WithMany("Firewalls")
                        .HasForeignKey("CoopID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Saic.Models.AuxiliarModels.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("FabricanteID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Saic.Models.Unidade", "Unidade")
                        .WithMany("Firewalls")
                        .HasForeignKey("UnidadeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Coop");

                    b.Navigation("Fabricante");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Saic.Models.Link", b =>
                {
                    b.HasOne("Saic.Models.AuxiliarModels.TipoLink", "TipoLink")
                        .WithMany()
                        .HasForeignKey("TipoLinkID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Saic.Models.Unidade", "Unidade")
                        .WithMany("Links")
                        .HasForeignKey("UnidadeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("TipoLink");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Saic.Models.RespCoop", b =>
                {
                    b.HasOne("Saic.Models.AuxiliarModels.Equipe", "Equipe")
                        .WithMany("RespCoops")
                        .HasForeignKey("EquipeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Saic.Models.Servidor", b =>
                {
                    b.HasOne("Saic.Models.AuxiliarModels.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("FabricanteID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Saic.Models.Coop", "Coop")
                        .WithMany("Servidores")
                        .HasForeignKey("ServidorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Saic.Models.Unidade", "Unidade")
                        .WithMany("Servidores")
                        .HasForeignKey("ServidorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Saic.Models.AuxiliarModels.SistOp", "SistOp")
                        .WithMany()
                        .HasForeignKey("SistOpID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Coop");

                    b.Navigation("Fabricante");

                    b.Navigation("SistOp");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Saic.Models.Unidade", b =>
                {
                    b.HasOne("Saic.Models.Coop", "Coop")
                        .WithMany("Unidades")
                        .HasForeignKey("CoopID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Coop");
                });

            modelBuilder.Entity("Saic.Models.Vlan", b =>
                {
                    b.HasOne("Saic.Models.Unidade", "Unidade")
                        .WithMany("Vlans")
                        .HasForeignKey("UnidadeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Saic.Models.AuxiliarModels.Equipe", b =>
                {
                    b.Navigation("RespCoops");
                });

            modelBuilder.Entity("Saic.Models.Coop", b =>
                {
                    b.Navigation("Firewalls");

                    b.Navigation("Servidores");

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("Saic.Models.RespCoop", b =>
                {
                    b.Navigation("Coops");
                });

            modelBuilder.Entity("Saic.Models.Unidade", b =>
                {
                    b.Navigation("Firewalls");

                    b.Navigation("Links");

                    b.Navigation("Servidores");

                    b.Navigation("Vlans");
                });
#pragma warning restore 612, 618
        }
    }
}
