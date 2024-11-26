namespace Saic.Models.Repositories
{
    public interface IServidorRepository
    {        
        IQueryable<Servidor> Servidores { get; }

        bool SaveServidor(Servidor r);
        bool CreateServidor(Servidor r);
        bool DeleteServidor(Servidor r);
    }
}