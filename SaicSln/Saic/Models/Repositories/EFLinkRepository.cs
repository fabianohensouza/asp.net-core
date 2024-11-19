namespace Saic.Models.Repositories
{
    public class EFLinkRepository : ILinkRepository
    {
        private StoreDbContext context;

        public EFLinkRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Link> Links => context.Links;

        public bool CreateLink(Link r)
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

        public bool SaveLink(Link r)
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

        public bool DeleteLink(Link r)
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