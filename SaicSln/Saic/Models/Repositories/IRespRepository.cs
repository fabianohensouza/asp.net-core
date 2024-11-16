namespace Saic.Models.Repositories
{
    public interface IRespRepository
    {        
        IQueryable<RespCoop> RespCoops { get; }

        bool SaveRespCoop(RespCoop r);
        bool CreateRespCoop(RespCoop r);
        bool DeleteRespCoop(RespCoop r);
    }
}
