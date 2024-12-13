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

        [Display(Name = "Nome *")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(40)]
        public string ServidorNome { get; set; } = String.Empty;

        [Display(Name = "Modelo *")]
        [Required(ErrorMessage = "Modelo Obrigatório")]
        [MaxLength(40)]
        public string ServidorModelo { get; set; } = String.Empty;

        [Display(Name = "Processador")]
        [MaxLength(40)]
        public string? ServidorCPU { get; set; } = String.Empty;

        [Display(Name = "Serial")]
        [MaxLength(40)]
        public string? ServidorSerial { get; set; } = String.Empty;

        [Display(Name = "Virtual")]
        public bool ServidorVirtual { get; set; } = false;

        [Display(Name = "Memória em GB *")]
        [Required(ErrorMessage = "Favor informar memória")]
        public int ServidorRAM { get; set; }

        [Display(Name = "IP Principal *")]
        [Required(ErrorMessage = "Favor informar IP Principal")]
        [MaxLength(15)]
        public string ServidorIP { get; set; } = String.Empty;

        [Display(Name = "IP IDrac")]
        [MaxLength(15)]
        public string? ServidorIDrac { get; set; } = String.Empty;

        [Display(Name = "Acesso Remoto *")]
        [Required(ErrorMessage = "Favor informar endereço de acesso remoto")]
        [MaxLength(60)]
        public string ServidorAcesso { get; set; } = String.Empty;

        [Display(Name = "Garantia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ServidorGarantia { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(300)]
        public string? ServidorObs { get; set; } = String.Empty;

        public DateTime LastChange { get; set; }

        [NotMapped]
        public bool ServidorNovo { get; set; } = true;

        [DisplayName("Sistema Op *")]
        [Required(ErrorMessage = "Informe o Sistema Operacional")]
        public int? SistOpID { get; set; }
        public SistOp? SistOp { get; set; }

        [DisplayName("Local *")]
        [Required(ErrorMessage = "Informe a Localização")]
        public Guid? UnidadeID { get; set; }
        public Unidade? Unidade { get; set; }

        [DisplayName("Coop")]
        [Required(ErrorMessage = "Informe a Cooperativa")]
        public Guid CoopID { get; set; }
        public Coop? Coop { get; set; }

        [Display(Name = "Fabricante")]
        public int? FabricanteID { get; set; }
        public Fabricante? Fabricante { get; set; }
    }
}