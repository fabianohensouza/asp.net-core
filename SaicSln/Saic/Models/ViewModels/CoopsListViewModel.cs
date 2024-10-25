namespace Saic.Models.ViewModels
{
    public class CoopsListViewModel
    {
        public List<string> ListaCoops { get; set; }
        public IEnumerable<Coop> Coops { get; set; } = Enumerable.Empty<Coop>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CoopAtual { get; set; }
    }
}
