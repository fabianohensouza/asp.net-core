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
        [MaxLength(4)]
        public string CoopNumero { get; set; } = String.Empty;

        [Display(Name = "Nome")]
        [MaxLength(40)]
        public string CoopNome { get; set; } = String.Empty;

        [Display(Name = "Cidade")]
        [MaxLength(40)]
        public string CoopCidade { get; set; } = String.Empty;

        [Display(Name = "Adesão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Adesao { get; set; }

        [Display(Name = "Equipamentos")]
        public int? QtdCompts { get; set; }

        [NotMapped]
        public int? QtdServers { get; set; }

        [NotMapped]
        public int? QtdFwlls { get; set; }

        // Foreign key to RespCoop
        [Display(Name = "Responsável")]
        public Guid? RespID { get; set; }

        public RespCoop? RespCoop { get; set; }
    }
}
