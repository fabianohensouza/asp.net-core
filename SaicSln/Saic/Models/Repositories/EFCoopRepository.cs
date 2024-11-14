namespace Saic.Models.Repositories
{
    public class EFCoopRepository : ICoopRepository
    {
        private StoreDbContext context;

        public EFCoopRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Coop> Coops => context.Coops;

        public void SaveCoop(Coop c)
        {
            context.SaveChanges();
        }
    }
}
