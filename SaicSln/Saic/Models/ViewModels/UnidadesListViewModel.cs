namespace Saic.Models.ViewModels
{
    public class UnidadesListViewModel
    {
        public IEnumerable<Unidade> Unidades { get; set; } = Enumerable.Empty<Unidade>();
        public Coop? CoopAtual { get; set; }
    }
}
