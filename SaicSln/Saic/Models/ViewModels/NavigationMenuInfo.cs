namespace Saic.Models.ViewModels
{
    public class NavigationMenuInfo
    {
        public bool Drop { get; set; } = false;
        public List<NavigationMenuInfo>? DropLinks { get; set; } = new List<NavigationMenuInfo>();
        public string? Action { get; set; }
        public string? Controller { get; set; }
        public string? Label { get; set; }
        public string? Icone { get; set; }
    }
}
