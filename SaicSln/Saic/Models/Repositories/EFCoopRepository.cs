namespace Saic.Models.Repositories
{
    public class EFCoopRepository : ICoopRepository
    {
        private StoreDbContext context;

        public EFCoopRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        IQueryable<Coop> Coops { get; }
    }
}
