namespace Saic.Models.Repositories
{
    public class EFUnidadeRepository : IUnidadeRepository
    {
        private StoreDbContext context;

        public EFUnidadeRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Unidade> Unidades => context.Unidades;

        public bool CreateUnidade(Unidade r)
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

        public bool SaveUnidade(Unidade r)
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

        public bool DeleteUnidade(Unidade r)
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
