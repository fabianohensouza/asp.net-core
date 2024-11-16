using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class TipoLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TipoLinkID { get; set; } = Guid.NewGuid();

        [MaxLength(20)]
        public string TipoLinkNome { get; set; } = string.Empty;
    }
}