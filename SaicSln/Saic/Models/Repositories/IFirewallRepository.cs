namespace Saic.Models.Repositories
{
    public interface IFirewallRepository
    {        
        IQueryable<Firewall> Firewalls { get; }

        bool SaveFirewall(Firewall r);
        bool CreateFirewall(Firewall r);
        bool DeleteFirewall(Firewall r);
    }
}