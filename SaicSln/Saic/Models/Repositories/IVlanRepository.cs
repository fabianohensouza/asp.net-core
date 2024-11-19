namespace Saic.Models.Repositories
{
    public interface IVlanRepository
    {        
        IQueryable<Vlan> Vlans { get; }

        bool SaveVlan(Vlan r);
        bool CreateVlan(Vlan r);
        bool DeleteVlan(Vlan r);
    }
}