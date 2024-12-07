using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Saic.Models
{
    public class Ad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AdID { get; set; } = Guid.NewGuid();

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(40)]
        public string AdNome { get; set; } = String.Empty;

        [Display(Name = "Tiers")]
        public bool AdTiers { get; set; } = false;

        [Display(Name = "Observações")]
        [MaxLength(60, ErrorMessage = "Máximo de 300 caracteres em observações")]
        public string? AdObs { get; set; } = String.Empty;

        public DateTime LastChange { get; set; }

        [DisplayName("DC Primário")]
        [Required(ErrorMessage = "Informe o servidor Primário")]
        public Guid? DCPrimarioID { get; set; }

        public Servidor? DCPrimario { get; set; }

        [DisplayName("DC Secundário")]
        [Required(ErrorMessage = "Informe o servidor Secundário")]
        public Guid? DCSecundarioID { get; set; }

        public Servidor? DCSecundario { get; set; }

        [DisplayName("Coop")]
        [Required(ErrorMessage = "Informe a Cooperativa")]
        public Guid? CoopID { get; set; }

        public Coop? Coop { get; set; }


    }
}
