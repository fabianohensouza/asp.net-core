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

        public void CreateCoop(Coop c)
        {
            context.Add(c);
            context.SaveChanges();
        }

        public void DeleteCoop(Coop c)
        {
            context.Remove(c);
            context.SaveChanges();
        }

        public void SaveCoop(Coop c)
        {
            context.SaveChanges();
        }
    }
}
