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
                        CoopCidade = "Uberlandia"
                    },
                    new Coop
                    {
                        CoopNumero = "0002",
                        CoopNome = "CrediTwo",
                        CoopCidade = "Betim"
                    },
                    new Coop
                    {
                        CoopNumero = "0003",
                        CoopNome = "CrediThree",
                        CoopCidade = "BH"
                    },
                    new Coop
                    {
                        CoopNumero = "0004",
                        CoopNome = "CrediFour",
                        CoopCidade = "Uberaba"
                    },
                    new Coop
                    {
                        CoopNumero = "0005",
                        CoopNome = "CrediFive",
                        CoopCidade = "Rio de Janeiro"
                    },
                    new Coop
                    {
                        CoopNumero = "0006",
                        CoopNome = "CrediSix",
                        CoopCidade = "São Paulo"
                    },
                    new Coop
                    {
                        CoopNumero = "0007",
                        CoopNome = "CrediSeven",
                        CoopCidade = "Sete Lagoas"
                    },
                    new Coop
                    {
                        CoopNumero = "0008",
                        CoopNome = "CrediEigth",
                        CoopCidade = "Nova Lima"
                    },
                    new Coop
                    {
                        CoopNumero = "0009",
                        CoopNome = "CrediNine",
                        CoopCidade = "Sabará"
                    },
                    new Coop
                    {
                        CoopNumero = "0010",
                        CoopNome = "CrediTen",
                        CoopCidade = "Porto Alegre"
                    },
                    new Coop
                    {
                        CoopNumero = "0011",
                        CoopNome = "CrediEleven",
                        CoopCidade = "Vespaiano"
                    },
                    new Coop
                    {
                        CoopNumero = "0012",
                        CoopNome = "CrediTwelve",
                        CoopCidade = "Cuiabá"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
