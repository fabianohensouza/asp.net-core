using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Saic.Models
{
    public class Vlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VlanID { get; set; } = Guid.NewGuid();

        [Display(Name = "Tag *")]
        [Required(ErrorMessage = "Tag Obrigatória")]
        [MaxLength(20)]
        public string VlanTag { get; set; } = String.Empty;

        [Display(Name = "Nome")]
        [MaxLength(40)]
        public string? VlanNome { get; set; } = String.Empty;

        [Display(Name = "Range IP")]
        [MaxLength(40)]
        public string? VlanRangeIP { get; set; } = String.Empty;

        [Display(Name = "Observações")]
        [MaxLength(300)]
        public string? VlanObs { get; set; } = String.Empty;

        public DateTime LastChange { get; set; }

        [DisplayName("Unidade *")]
        [Required(ErrorMessage = "Favor informar a unidade")]
        public Guid? UnidadeID { get; set; }
        public Unidade? Unidade { get; set; }

        [NotMapped]
        public string? DisplayCoop => $"{Unidade?.Coop?.CoopNumero} - {Unidade?.Coop?.CoopNome}";

        [NotMapped]
        public string? DisplayUnidade => Unidade?.UnidadeNumero;
    }
}
