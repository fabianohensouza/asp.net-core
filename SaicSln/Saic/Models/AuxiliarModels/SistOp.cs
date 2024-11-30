using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class SistOp
    {
        [Key]
        public int SistOpID { get; set; }

        [MaxLength(50)]
        public string SistOpNome { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ServidorSuporte { get; set; }
    }
}
