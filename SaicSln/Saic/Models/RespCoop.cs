using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saic.Models
{
    public class RespCoop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RespID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Favor informar o nome")]
        [MaxLength(40)]
        public string RespNome { get; set; } = String.Empty;

        public ICollection<Coop> Coops { get; set; } = new List<Coop>();
    }
}
