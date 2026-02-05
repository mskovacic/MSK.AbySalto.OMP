using MSK.AbySalto.OMP.Core.Entities;

namespace MSK.AbySalto.OMP.Core.Interfaces
{
    public interface IRepository
    {
        IQueryable<Product> Products { get; }

        IQueryable<Basket> Baskets { get; }

        IQueryable<BasketItem> BasketItems { get; }

        Task AddAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : BaseEntity;

        Task UpdateAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : BaseEntity;

        Task RemoveAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : BaseEntity;
    }
}
