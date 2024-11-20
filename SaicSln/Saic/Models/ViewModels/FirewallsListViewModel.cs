namespace Saic.Models.ViewModels
{
    public class FirewallsListViewModel
    {
        public IEnumerable<Firewall> Firewalls { get; set; } = Enumerable.Empty<Firewall>();
        public Coop? CoopAtual { get; set; }
    }
}
