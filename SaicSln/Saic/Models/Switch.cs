using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Saic.Models.AuxiliarModels;

namespace Saic.Models
{
    public class Switch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SwitchID { get; set; } = Guid.NewGuid();

        [Display(Name = "Modelo *")]
        [Required(ErrorMessage = "Modelo Obrigatório")]
        [MaxLength(40)]
        public string SwitchModelo { get; set; } = String.Empty;

        [Display(Name = "Serial *")]
        [Required(ErrorMessage = "Serial Obrigatório")]
        [MaxLength(40)]
        public string? SwitchSerial { get; set; } = String.Empty;

        [Display(Name = "IP Console")]
        [MaxLength(15)]
        public string SwitchAcesso { get; set; } = String.Empty;

        [Display(Name = "Portas *")]
        [Required(ErrorMessage = "Favor informar o numero de portas")]
        [Range(1, 48)]
        public int SwitchPortas { get; set; }

        [Display(Name = "Backup")]
        public bool SwitchBackup { get; set; } = false;

        [Display(Name = "Observações")]
        [MaxLength(300)]
        public string? SwitchObs { get; set; } = String.Empty;

        public DateTime LastChange { get; set; }

        [DisplayName("Coop *")]
        [Required(ErrorMessage = "Informe a Cooperativa")]
        public Guid? CoopID { get; set; }
        public Coop? Coop { get; set; }

        [DisplayName("Unidade")]
        public Guid? UnidadeID { get; set; }
        public Unidade? Unidade { get; set; }

        [Display(Name = "Fabricante *")]
        [Required(ErrorMessage = "Fabricante Obrigatório")]
        public int? FabricanteID { get; set; }
        public Fabricante? Fabricante { get; set; }
    }
}
