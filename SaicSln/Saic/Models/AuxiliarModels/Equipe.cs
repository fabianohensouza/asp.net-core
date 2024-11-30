using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class Equipe
    {
        [Key]
        public int EquipeID { get; set; }

        [MaxLength(20)]
        public string EquipeNome { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? EquipeDescrição { get; set; }

        public ICollection<RespCoop> RespCoops { get; set; } = new List<RespCoop>();

        // Generalized method
        private int SumFromRespCoops(Func<RespCoop, int> selector)
        {
            return RespCoops.Sum(selector);
        }

        // Specific methods
        public int ReturnCoops() => SumFromRespCoops(resp => resp.ReturnCoops());
        public int ReturnFirewalls() => SumFromRespCoops(resp => resp.ReturnFirewalls());
        public int ReturnCompts() => SumFromRespCoops(resp => resp.ReturnCompts());
        public int ReturnServers() => SumFromRespCoops(resp => resp.ReturnServers());        
    }
}
