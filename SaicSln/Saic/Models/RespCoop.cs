using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Saic.Models.AuxiliarModels;

namespace Saic.Models
{
    public class RespCoop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RespID { get; set; } = Guid.NewGuid();

        [DisplayName("Nome *")]
        [Required(ErrorMessage = "Favor informar o nome")]
        [MaxLength(40)]
        public string RespNome { get; set; } = String.Empty;

        [NotMapped]
        public int? QtdCoops { get; set; }

        [NotMapped]
        public int? QtdCompts { get; set; }

        public DateTime LastChange { get; set; }

        public ICollection<Coop> Coops { get; set; } = new List<Coop>();

        public int ReturnCoops()
        {
            return Coops.Count;
        }

        public int ReturnFirewalls()
        {
            var qtdFirewalls = 0;

            foreach (var firewall in Coops)
            {
                qtdFirewalls += firewall.ReturnFirewalls();
            }

            return qtdFirewalls;
        }

        public int ReturnCompts()
        {
            var qtdCompts = 0;

            foreach (var coop in Coops)
            {
                qtdCompts += coop.QtdCompts ?? 0;
            }

            return qtdCompts;
        }

        public int ReturnServers()
        {
            var qtdServers = 0;

            foreach (var coop in Coops)
            {
                qtdServers += coop.ReturnServers();
            }

            return qtdServers;
        }
    }
}
