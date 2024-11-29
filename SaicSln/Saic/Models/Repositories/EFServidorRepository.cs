namespace Saic.Models.Repositories
{
    public class EFServidorRepository : IServidorRepository
    {
        private StoreDbContext context;

        public EFServidorRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Servidor> Servidores => context.Servidores;

        public bool CreateServidor(Servidor r)
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

        public bool SaveServidor(Servidor r)
        {
            try
            {
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteServidor(Servidor r)
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