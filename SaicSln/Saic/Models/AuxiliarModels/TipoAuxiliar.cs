using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class TipoAuxiliar
    {
        [Key]
        public int TipoID { get; set; }

        [MaxLength(20)]
        public string TipoNome { get; set; } = string.Empty;
        public string TipoCategoria { get; set; } = string.Empty;
    }
}
