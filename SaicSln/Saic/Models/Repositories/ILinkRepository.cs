namespace Saic.Models.Repositories
{
    public interface ILinkRepository
    {        
        IQueryable<Link> Links { get; }

        bool SaveLink(Link r);
        bool CreateLink(Link r);
        bool DeleteLink(Link r);
    }
}