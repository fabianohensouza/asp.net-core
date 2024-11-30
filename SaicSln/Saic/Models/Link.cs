using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Saic.Models.AuxiliarModels;

namespace Saic.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LinkID { get; set; } = Guid.NewGuid();

        [Display(Name = "Provedor")]
        [Required(ErrorMessage = "Provedor Obrigatório")]
        [MaxLength(30)]
        public string LinkProvedor { get; set; } = String.Empty;

        [Display(Name = "Endereço IP")]
        [MaxLength(15)]
        public string LinkIP { get; set; } = String.Empty;

        [Display(Name = "Observações")]
        [MaxLength(60)]
        public string? LinkObs { get; set; } = String.Empty;

        public DateTime LastChange { get; set; }

        [DisplayName("Unidade")]
        public Guid UnidadeID { get; set; }

        public Unidade? Unidade { get; set; }

        [DisplayName("Tipo de Link")]
        public int TipoLinkID { get; set; }

        public TipoLink? TipoLink { get; set; }

        [NotMapped]
        public string? DisplayCoop => $"{Unidade?.Coop?.CoopNumero} - {Unidade?.Coop?.CoopNome}";

        [NotMapped]
        public string? DisplayUnidade => Unidade?.UnidadeNumero;
    }
}
