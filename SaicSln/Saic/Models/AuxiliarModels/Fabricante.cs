using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class Fabricante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FabricanteID { get; set; } = Guid.NewGuid();

        [MaxLength(20)]
        public string FabricanteTipo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string FabricanteNome { get; set; } = string.Empty;
    }
}
