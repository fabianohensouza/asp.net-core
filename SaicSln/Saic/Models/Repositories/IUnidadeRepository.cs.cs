namespace Saic.Models.Repositories
{
    public interface IUnidadeRepository
    {        
        IQueryable<Unidade> Unidades { get; }

        bool SaveUnidade(Unidade r);
        bool CreateUnidade(Unidade r);
        bool DeleteUnidade(Unidade r);
    }
}
