namespace Saic.Models.ViewModels
{
    public class ServidoresListViewModel
    {
        public IEnumerable<Servidor> Servidores { get; set; } = Enumerable.Empty<Servidor>();
        public Coop? CoopAtual { get; set; }
    }
}
