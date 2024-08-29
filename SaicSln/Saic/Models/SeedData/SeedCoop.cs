using Microsoft.EntityFrameworkCore;

namespace Saic.Models.SeedData
{
    public class SeedData
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
                        CoopNumero = "Kayak",
                        CoopNome = "A boat for one person",
                        CoopCidade = "Watersports"
                    },
                    new Coop
                    {
                        CoopNumero = "Kayak",
                        CoopNome = "A boat for one person",
                        CoopCidade = "Watersports"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
