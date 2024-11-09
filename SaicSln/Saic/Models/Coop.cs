using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saic.Models
{
    public class Coop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CoopID { get; set; } = Guid.NewGuid();

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

        // Foreign key to RespCoop
        public Guid RespID { get; set; }

        public RespCoop? RespCoop { get; set; }
    }
}
