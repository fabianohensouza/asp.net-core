namespace Saic.Models.Repositories
{
    public class EFSwitchRepository : ISwitchRepository
    {
        private StoreDbContext context;

        public EFSwitchRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Switch> Switches => context.Switches;

        public bool CreateSwitch(Switch r)
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

        public bool SaveSwitch(Switch r)
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

        public bool DeleteSwitch(Switch r)
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