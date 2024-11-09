using Microsoft.EntityFrameworkCore;

namespace Saic.Models.SeedData
{
    public class SeedCoop
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Coops.Any())
            {
                context.Coops.AddRange(
                    new Coop
                    {
                        CoopNumero = "0001",
                        CoopNome = "CrediOne",
                        CoopCidade = "Uberlandia",
                        Adesao = new DateTime(15/02/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0002",
                        CoopNome = "CrediTwo",
                        CoopCidade = "Betim",
                        Adesao = new DateTime(22/02/2013)
                    },
                    new Coop
                    {
                        CoopNumero = "0003",
                        CoopNome = "CrediThree",
                        CoopCidade = "BH",
                        Adesao = new DateTime(25/07/2021)
                    },
                    new Coop
                    {
                        CoopNumero = "0004",
                        CoopNome = "CrediFour",
                        CoopCidade = "Uberaba",
                        Adesao = new DateTime(09/09/2009)
                    },
                    new Coop
                    {
                        CoopNumero = "0005",
                        CoopNome = "CrediFive",
                        CoopCidade = "Rio de Janeiro",
                        Adesao = new DateTime(15/02/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0006",
                        CoopNome = "CrediSix",
                        CoopCidade = "São Paulo",
                        Adesao = new DateTime(15/02/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0007",
                        CoopNome = "CrediSeven",
                        CoopCidade = "Sete Lagoas",
                        Adesao = new DateTime(16/04/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0008",
                        CoopNome = "CrediEigth",
                        CoopCidade = "Nova Lima",
                        Adesao = new DateTime(19/02/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0009",
                        CoopNome = "CrediNine",
                        CoopCidade = "Sabará",
                        Adesao = new DateTime(10/02/2019)
                    },
                    new Coop
                    {
                        CoopNumero = "0010",
                        CoopNome = "CrediTen",
                        CoopCidade = "Porto Alegre",
                        Adesao = new DateTime(15/02/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0011",
                        CoopNome = "CrediEleven",
                        CoopCidade = "Vespaiano",
                        Adesao = new DateTime(15/02/2011)
                    },
                    new Coop
                    {
                        CoopNumero = "0012",
                        CoopNome = "CrediTwelve",
                        CoopCidade = "Cuiabá",
                        Adesao = new DateTime(15/02/2011)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
