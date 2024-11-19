using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Saic.Models.AuxiliarModels;

namespace Saic.Models
{
    public class Firewall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FirewallID { get; set; } = Guid.NewGuid();

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Modelo Obrigatório")]
        [MaxLength(40)]
        public string FirewallModelo { get; set; } = String.Empty;

        [Display(Name = "Serial")]
        [MaxLength(40)]
        public string? FirewallSerial { get; set; } = String.Empty;

        [Display(Name = "Backup")]
        [MaxLength(40)]
        public bool FirewallBackup { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres em observações")]
        public string? FirewallObs { get; set; } = String.Empty;

        [DisplayName("Coop")]
        public Guid? CoopID { get; set; }

        public Coop? Coop { get; set; }

        [DisplayName("Unidade")]
        public Guid? UnidadeID { get; set; }

        public Unidade? Unidade { get; set; }

        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "Fabricante Obrigatório")]
        public Guid? FabricanteID { get; set; }

        public Fabricante? Fabricante { get; set; }
    }
}
