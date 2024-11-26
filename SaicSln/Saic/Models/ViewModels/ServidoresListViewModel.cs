namespace Saic.Models.ViewModels
{
    public class ServidoresListViewModel
    {
        public IEnumerable<Servidor> Servidores { get; set; } = Enumerable.Empty<Firewall>();
        public Coop? CoopAtual { get; set; }
    }
}
