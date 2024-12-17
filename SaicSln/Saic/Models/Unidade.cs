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

        [Display(Name = "Número *")]
        [Required(ErrorMessage = "Número Obrigatório")]
        [MaxLength(2)]
        public string UnidadeNumero { get; set; } = String.Empty;

        [Display(Name = "Nome")]
        [MaxLength(40)]
        public string? UnidadeNome { get; set; } = String.Empty;

        [Display(Name = "Observações")]
        [MaxLength(300)]
        public string? UnidadeObs { get; set; } = String.Empty;

        public DateTime LastChange { get; set; }

        [NotMapped]
        public bool UnidadeNova { get; set; } = false;

        [DisplayName("Coop")]
        public Guid CoopID { get; set; }
        public Coop? Coop { get; set; }

        public ICollection<Firewall> Firewalls { get; set; } = new List<Firewall>();
        public ICollection<Switch> Switches { get; set; } = new List<Switch>();
        public ICollection<Servidor> Servidores { get; set; } = new List<Servidor>();
        public ICollection<Link> Links { get; set; } = new List<Link>();
        public ICollection<Vlan> Vlans { get; set; } = new List<Vlan>();
    }
}
