using Microsoft.EntityFrameworkCore;
using Saic.Models.AuxiliarModels;

namespace Saic.Models.SeedData
{
    public class SeedCoop
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

                // Verifica e aplica as migrações pendentes
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                // Chama os métodos para popular os dados
                SeedCoops(context);
                SeedFabricantes(context);
                SeedTipos(context);
                SeedSistOps(context);
            }
        }

        private static void SeedCoops(StoreDbContext context)
        {
            if (!context.Coops.Any())
            {
                context.Coops.AddRange(
                    new Coop { CoopNumero = "0001", CoopNome = "CrediOne", CoopCidade = "Uberlandia", Adesao = new DateTime(2011, 2, 15), QtdCompts = 150 },
                    new Coop { CoopNumero = "0002", CoopNome = "CrediTwo", CoopCidade = "Betim", Adesao = new DateTime(2013, 2, 22), QtdCompts = 200 },
                    new Coop { CoopNumero = "0003", CoopNome = "CrediThree", CoopCidade = "BH", Adesao = new DateTime(2021, 7, 25), QtdCompts = 300 },
                    new Coop { CoopNumero = "0004", CoopNome = "CrediFour", CoopCidade = "Uberaba", Adesao = new DateTime(2009, 9, 9), QtdCompts = 125 },
                    new Coop { CoopNumero = "0005", CoopNome = "CrediFive", CoopCidade = "Rio de Janeiro", Adesao = new DateTime(2011, 2, 15), QtdCompts = 275 },
                    new Coop { CoopNumero = "0006", CoopNome = "CrediSix", CoopCidade = "São Paulo", Adesao = new DateTime(2011, 2, 15), QtdCompts = 180 },
                    new Coop { CoopNumero = "0007", CoopNome = "CrediSeven", CoopCidade = "Sete Lagoas", Adesao = new DateTime(2011, 4, 16), QtdCompts = 220 },
                    new Coop { CoopNumero = "0008", CoopNome = "CrediEigth", CoopCidade = "Nova Lima", Adesao = new DateTime(2011, 2, 19), QtdCompts = 260 },
                    new Coop { CoopNumero = "0009", CoopNome = "CrediNine", CoopCidade = "Sabará", Adesao = new DateTime(2019, 2, 10), QtdCompts = 310 },
                    new Coop { CoopNumero = "0010", CoopNome = "CrediTen", CoopCidade = "Porto Alegre", Adesao = new DateTime(2011, 2, 15), QtdCompts = 140 },
                    new Coop { CoopNumero = "0011", CoopNome = "CrediEleven", CoopCidade = "Vespaiano", Adesao = new DateTime(2011, 2, 15), QtdCompts = 190 },
                    new Coop { CoopNumero = "0012", CoopNome = "CrediTwelve", CoopCidade = "Cuiabá", Adesao = new DateTime(2011, 2, 15), QtdCompts = 230 }
                );

                context.SaveChanges();
            }
        }

        private static void SeedFabricantes(StoreDbContext context)
        {
            if (!context.Fabricantes.Any())
            {
                context.Fabricantes.AddRange(
                    new Fabricante { FabricanteTipo = "Firewall", FabricanteNome = "SonicWall" },
                    new Fabricante { FabricanteTipo = "Firewall", FabricanteNome = "Fortinet" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "Fortinet" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "HPE-Aruba" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "Cisco" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "Intelbras" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "Mikrotik" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "Dell" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "3Com" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "TPLink" },
                    new Fabricante { FabricanteTipo = "Switch", FabricanteNome = "Outros" },
                    new Fabricante { FabricanteTipo = "Servidor", FabricanteNome = "Dell" },
                    new Fabricante { FabricanteTipo = "Servidor", FabricanteNome = "HP" },
                    new Fabricante { FabricanteTipo = "Servidor", FabricanteNome = "Montado" }
                );

                context.SaveChanges();
            }
        }

        private static void SeedTipos(StoreDbContext context)
        {
            if (!context.TipoAuxiliares.Any())
            {
                context.TipoAuxiliares.AddRange(
                    new TipoAuxiliar { TipoNome = "MPLS", TipoCategoria = "Link" },
                    new TipoAuxiliar { TipoNome = "SD-WAN", TipoCategoria = "Link" },
                    new TipoAuxiliar { TipoNome = "Internet", TipoCategoria = "Link" },
                    new TipoAuxiliar { TipoNome = "Apartado", TipoCategoria = "Link" }
                );

                context.SaveChanges();
            }
        }

        private static void SeedSistOps(StoreDbContext context)
        {
            if (!context.SistOps.Any())
            {
                context.SistOps.AddRange(
                    new SistOp { SistOpNome = "Windows Server 2008", ServidorSuporte = new DateTime(2020, 1, 14) },
                    new SistOp { SistOpNome = "Windows Server 2008 R2", ServidorSuporte = new DateTime(2020, 1, 14) },
                    new SistOp { SistOpNome = "Windows Server 2012", ServidorSuporte = new DateTime(2023, 10, 10) },
                    new SistOp { SistOpNome = "Windows Server 2012 R2", ServidorSuporte = new DateTime(2023, 10, 10) },
                    new SistOp { SistOpNome = "Windows Server 2016", ServidorSuporte = new DateTime(2027, 1, 12) },
                    new SistOp { SistOpNome = "Windows Server 2019", ServidorSuporte = new DateTime(2029, 1, 9) },
                    new SistOp { SistOpNome = "Windows Server 2022", ServidorSuporte = new DateTime(2031, 10, 14) },
                    new SistOp { SistOpNome = "Linux", ServidorSuporte = new DateTime(2099, 1, 1) }
                );

                context.SaveChanges();
            }
        }
    }
}


