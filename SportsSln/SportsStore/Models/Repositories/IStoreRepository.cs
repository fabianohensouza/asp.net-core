namespace SportsStore.Models.Repositories
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
