using MSK.AbySalto.OMP.Core.Entities;

namespace MSK.AbySalto.OMP.Core.Interfaces
{
    public interface IRepository
    {
        IQueryable<Product> Products { get; }

        IAsyncQueryable<Basket> Baskets { get; }

        IQueryable<BasketItem> BasketItems { get; }

        Task AddAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : class;

        Task RemoveAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : class;
    }
}
