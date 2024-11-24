using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Saic.Models.AuxiliarModels;

namespace Saic.Models
{
    public class Servidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ServidorID { get; set; } = Guid.NewGuid();

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(40)]
        public string ServidorNome { get; set; } = String.Empty;

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Modelo Obrigatório")]
        [MaxLength(40)]
        public string ServidorModelo { get; set; } = String.Empty;

        [Display(Name = "Processador")]
        [MaxLength(40)]
        public string? ServidorCPU { get; set; } = String.Empty;

        [Display(Name = "Serial")]
        [Required(ErrorMessage = "Serial Obrigatório")]
        [MaxLength(40)]
        public string ServidorSerial { get; set; } = String.Empty;

        [Display(Name = "Memória em GB")]
        public int? ServidorRAM { get; set; }

        [Display(Name = "Disco SO")]
        public int? ServidorDisco1 { get; set; }

        [Display(Name = "Armazenamento Dados")]
        public int? ServidorDisco2 { get; set; }

        [Display(Name = "IP Principal")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres em observações")]
        public string? ServidorIP { get; set; } = String.Empty;

        [Display(Name = "IP Principal")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres em observações")]
        public string? ServidorIDrac { get; set; } = String.Empty;

        [Display(Name = "Acesso Remoto")]
        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres em observações")]
        public string? ServidorAcesso { get; set; } = String.Empty;

        [Display(Name = "Garantia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ServidorGarantia { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres em observações")]
        public string? ServidorObs { get; set; } = String.Empty;

        [DisplayName("Coop")]
        [Required(ErrorMessage = "Informe a Localização")]
        public Guid UnidadeID { get; set; }

        public Unidade? Unidade { get; set; }

        [DisplayName("Coop")]
        [Required(ErrorMessage = "Informe a Cooperativa")]
        public Guid CoopID { get; set; }

        public Coop? Coop { get; set; }

        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "Fabricante Obrigatório")]
        public Guid FabricanteID { get; set; }

        public Fabricante? Fabricante { get; set; }
    }
}
