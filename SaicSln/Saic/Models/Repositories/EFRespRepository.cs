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

        public bool CreateRespCoop(RespCoop r)
        {
            try
            {
                context.Add(r);
                return context.SaveChanges() > 0; 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveRespCoop(RespCoop r)
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

        public bool DeleteRespCoop(RespCoop r)
        {
            try
            {
                context.Remove(r);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
