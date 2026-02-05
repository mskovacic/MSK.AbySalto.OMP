using Microsoft.EntityFrameworkCore;
using MSK.AbySalto.OMP.Core;
using MSK.AbySalto.OMP.Core.Entities;
using MSK.AbySalto.OMP.Core.Interfaces;

namespace MSK.AbySalto.OMP.Infrastructure
{
    public class RepositoryAdapter(OMPContext context) : IRepository
    {
        public IQueryable<Product> Products => context.Products;

        public IQueryable<Basket> Baskets => context.Baskets;

        public IQueryable<BasketItem> BasketItems => context.BasketItems;

        public async Task AddAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            context.Add(entity);
            if (save)
            {
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task RemoveAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            context.Remove(entity);
            if (save)
            {
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync<T>(T entity, bool save = true, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            context.Attach(entity);
            if (save)
            {
                await context.SaveChangesAsync(cancellationToken);
            }

        }
    }
}
