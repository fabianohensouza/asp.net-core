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

        public bool SaveCoop(Coop c)
        {
            try
            {
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
