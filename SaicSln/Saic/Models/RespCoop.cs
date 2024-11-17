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

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Favor informar o nome")]
        [MaxLength(40)]
        public string RespNome { get; set; } = String.Empty;

        [NotMapped]
        public int? QtdCoops { get; set; }

        [NotMapped]
        public int? QtdCompts { get; set; }

        public ICollection<Coop> Coops { get; set; } = new List<Coop>();

        [DisplayName("Equipe")]
        public Guid? EquipeID { get; set; }

        public Equipe? Equipe { get; set; }

        public int ReturnServers()
        {
            var qtdServers = 0;

            return qtdServers;
        }

        public int ReturnFirewalls()
        {
            var qtdFirewalls = 0;

            return qtdFirewalls;
        }
    }
}
