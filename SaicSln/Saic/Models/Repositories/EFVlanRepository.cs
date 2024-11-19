namespace Saic.Models.Repositories
{
    public class EFVlanRepository : IVlanRepository
    {
        private StoreDbContext context;

        public EFVlanRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Vlan> Vlans => context.Vlans;

        public bool CreateVlan(Vlan r)
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

        public bool SaveVlan(Vlan r)
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

        public bool DeleteVlan(Vlan r)
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