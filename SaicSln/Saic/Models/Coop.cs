using Saic.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saic.Models
{
    public class Coop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CoopID { get; set; } = Guid.NewGuid();

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Número Obrigatório")]
        [MaxLength(4)]
        public string CoopNumero { get; set; } = String.Empty;

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(40)]
        public string CoopNome { get; set; } = String.Empty;

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade Obrigatória")]
        [MaxLength(40)]
        public string CoopCidade { get; set; } = String.Empty;

        [Display(Name = "Adesão")]
        [Required(ErrorMessage = "Adesão Obrigatória")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Adesao { get; set; }

        [Display(Name = "Equipamentos")]
        public int? QtdCompts { get; set; }

        public DateTime LastChange { get; set; }

        // Foreign key to RespCoop
        [Display(Name = "Responsável")]
        public Guid? RespID { get; set; }
        public RespCoop? RespCoop { get; set; }

        public ICollection<Unidade> Unidades { get; set; } = new List<Unidade>();
        public ICollection<Firewall> Firewalls { get; set; } = new List<Firewall>();
        public ICollection<Switch> Switches { get; set; } = new List<Switch>();
        public ICollection<Servidor> Servidores { get; set; } = new List<Servidor>();

        [NotMapped]
        public string DisplayName => $"{CoopNumero} - {CoopNome}";

        public int ReturnServers()
        {
            var qtdServers = Servidores.Where(c => c.CoopID == CoopID).Count();

            return qtdServers;
        }

        public int ReturnFirewalls()
        {
            var qtdFirewalls = Firewalls.Where(c => c.CoopID == CoopID).Count();

            return qtdFirewalls;
        }
    }
}
