using System.ComponentModel.DataAnnotations.Schema;

namespace Saic.Models
{
    public class Coop
    {
        public long? CoopID { get; set; }
        public string CoopNumero { get; set; } = String.Empty;
        public string CoopNome { get; set; } = String.Empty;
        public string CoopCidade { get; set; } = String.Empty;
    }
}
