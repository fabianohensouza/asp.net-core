using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saic.Models
{
    public class Coop
    {
        public long? CoopID { get; set; }

        [MaxLength(4)]
        public string CoopNumero { get; set; } = String.Empty;

        [MaxLength(40)]
        public string CoopNome { get; set; } = String.Empty;

        [MaxLength(40)]
        public string CoopCidade { get; set; } = String.Empty;

        public DateTime Adesao { get; set; }

        public int? QtdCompts { get; set; }

        [NotMapped]
        public string? RespMonitor { get; set; } = String.Empty;

        [NotMapped]
        public int? QtdServers { get; set; }

        [NotMapped]
        public int? QtdFwlls { get; set; }
    }
}
