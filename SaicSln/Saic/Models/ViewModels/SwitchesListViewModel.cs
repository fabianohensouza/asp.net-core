namespace Saic.Models.ViewModels
{
    public class SwitchesListViewModel
    {
        public IEnumerable<Switch> Switches { get; set; } = Enumerable.Empty<Switch>();
        public Coop? CoopAtual { get; set; }
    }
}
