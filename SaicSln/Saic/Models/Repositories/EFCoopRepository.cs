namespace Saic.Models.Repositories
{
    public class EFCoopRepository : ICoopRepository
    {
        private StoreDbContext context;

        public EFCoopRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Coop> Coops { get; }

        public void CreateCoop(Coop p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteCoop(Coop p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveCoop(Coop p)
        {
            context.SaveChanges();
        }
    }
}
