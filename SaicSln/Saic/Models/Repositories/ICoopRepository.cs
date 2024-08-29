namespace Saic.Models.Repositories
{
    public class ICoopRepository
    {
        IQueryable<Coop> Coops { get; }
    }
}
