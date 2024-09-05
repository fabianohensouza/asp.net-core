namespace Saic.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItens { get; set; }
        public int ItemsPorPag { get; set; }
        public int PagAtual { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItens / ItemsPorPag);
    }
}
