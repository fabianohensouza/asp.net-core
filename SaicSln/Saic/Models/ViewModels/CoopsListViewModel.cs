namespace Saic.Models.ViewModels
{
    public class CoopsListViewModel
    {
        public IEnumerable<Coop> Coops { get; set; } = Enumerable.Empty<Coop>();
        public PagingInfo PagingInfo { get; set; } = new();
    }
}
