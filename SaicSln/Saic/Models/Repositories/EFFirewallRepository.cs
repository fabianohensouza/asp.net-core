namespace Saic.Models.Repositories
{
    public class EFFirewallRepository : IFirewallRepository
    {
        private StoreDbContext context;

        public EFFirewallRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Firewall> Firewalls => context.Firewalls;

        public bool CreateFirewall(Firewall r)
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

        public bool SaveFirewall(Firewall r)
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

        public bool DeleteFirewall(Firewall r)
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