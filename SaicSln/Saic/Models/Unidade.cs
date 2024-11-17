using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Saic.Models
{
    public class Unidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UnidadeID { get; set; } = Guid.NewGuid();

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Número Obrigatório")]
        [MaxLength(2)]
        public string UnidadeNumero { get; set; } = String.Empty;

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(40)]
        public string UnidadeNome { get; set; } = String.Empty;

        [DisplayName("Coop")]
        [Required(ErrorMessage = "Coop Obrigatória")]
        public Guid? CoopID { get; set; }

        public Coop? Coop { get; set; }

        public ICollection<Firewall> Firewalls { get; set; } = new List<Firewall>();

        public ICollection<Link> Links { get; set; } = new List<Link>();
    }
}
