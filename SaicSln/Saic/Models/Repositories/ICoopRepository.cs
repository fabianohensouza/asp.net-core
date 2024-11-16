namespace Saic.Models.Repositories
{
    public interface ICoopRepository
    {        
        IQueryable<Coop> Coops { get; }

        bool SaveCoop(Coop c);
    }
}
