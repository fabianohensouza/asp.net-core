using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class Fabricante
    {
        [Key]
        public int FabricanteID { get; set; }

        [MaxLength(20)]
        public string FabricanteTipo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string FabricanteNome { get; set; } = string.Empty;
    }
}
