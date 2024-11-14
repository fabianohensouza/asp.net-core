namespace Saic.Models.Repositories
{
    public interface ICoopRepository
    {        
        IQueryable<Coop> Coops { get; }

        void SaveCoop(Coop c);
    }
}
