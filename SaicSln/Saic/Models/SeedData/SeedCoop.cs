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
                        CoopNumero = "0003",
                        CoopNome = "CrediTwo",
                        CoopCidade = "Betim"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
