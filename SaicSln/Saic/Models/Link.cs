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
        [MaxLength(2)]
        public string LinkProvedor { get; set; } = String.Empty;

        [Display(Name = "Endereço IP")]
        [Required(ErrorMessage = "Endereço IP Obrigatório")]
        [MaxLength(15)]
        public string LinkIP { get; set; } = String.Empty;

        [DisplayName("Unidade")]
        public Guid? UnidadeID { get; set; }

        public Unidade? Unidade { get; set; }

        [DisplayName("Tipo de Link")]
        public Guid? TipoLinkID { get; set; }

        public TipoLink? TipoLink { get; set; }
    }
}
