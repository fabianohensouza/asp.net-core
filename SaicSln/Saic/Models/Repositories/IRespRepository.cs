namespace Saic.Models.Repositories
{
    public interface IRespRepository
    {        
        IQueryable<RespCoop> RespCoops { get; }

        void SaveRespCoop(RespCoop r);
        void CreateRespCoop(RespCoop r);
        void DeleteRespCoop(RespCoop r);
    }
}
