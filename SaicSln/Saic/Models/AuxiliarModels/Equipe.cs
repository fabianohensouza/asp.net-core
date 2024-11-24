using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Saic.Models.AuxiliarModels
{
    public class Equipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EquipeID { get; set; } = Guid.NewGuid();

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

        //public int ReturnCoops()
        //{
        //    var qtdCoops = 0;

        //    foreach (var resp in RespCoops)
        //    {
        //        qtdCoops += resp.ReturnCoops();
        //    }

        //    return qtdCoops;
        //}

        //public int ReturnFirewalls()
        //{
        //    var qtdFirewalls = 0;

        //    foreach (var resp in RespCoops)
        //    {
        //        qtdFirewalls += resp.ReturnFirewalls();
        //    }

        //    return qtdFirewalls;
        //}

        //public int ReturnCompts()
        //{
        //    var qtdCompts = 0;

        //    foreach (var resp in RespCoops)
        //    {
        //        qtdCompts += resp.ReturnCompts();
        //    }

        //    return qtdCompts;
        //}

        //public int ReturnServers()
        //{
        //    var qtdServers = 0;

        //    foreach (var resp in RespCoops)
        //    {
        //        qtdServers += resp.ReturnServers();
        //    }

        //    return qtdServers;
        //}
    }
}
