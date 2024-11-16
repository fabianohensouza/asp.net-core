using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class Equipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EquipeID { get; set; } = Guid.NewGuid();

        [MaxLength(20)]
        public string EquipeNome { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? EquipeDescrição { get; set; }

        public ICollection<RespCoop> RespCoops { get; set; } = new List<RespCoop>();
    }
}
