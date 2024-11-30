using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class TipoLink
    {
        [Key]
        public int TipoLinkID { get; set; }

        [MaxLength(20)]
        public string TipoLinkNome { get; set; } = string.Empty;
    }
}