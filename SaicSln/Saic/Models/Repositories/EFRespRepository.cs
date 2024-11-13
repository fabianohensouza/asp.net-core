namespace Saic.Models.Repositories
{
    public class EFRespRepository : IRespRepository
    {
        private StoreDbContext context;

        public EFRespRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<RespCoop> RespCoops => context.RespCoops;

        public void CreateRespCoop(RespCoop r)
        {
            context.Add(r);
            context.SaveChanges();
        }

        public void DeleteRespCoop(RespCoop r)
        {
            context.Remove(r);
            context.SaveChanges();
        }

        public void SaveRespCoop(RespCoop r)
        {
            context.SaveChanges();
        }
    }
}
