using System.ComponentModel.DataAnnotations.Schema;

namespace Saic.Models.ViewModels
{
    public class EditCoopViewModel
    {
        public Coop? Coop { get; set; }
        public int? QtdServers { get; set; }
        public int? QtdFwlls { get; set; }
    }
}
