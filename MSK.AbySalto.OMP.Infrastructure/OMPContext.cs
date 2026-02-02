using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSK.AbySalto.OMP.Core.Entities;

namespace MSK.AbySalto.OMP.Infrastructure
{
    public class OMPContext(DbContextOptions<OMPContext> options) : IdentityDbContext(options)
    {
        public DbSet<Basket> Baskets => Set<Basket>();
        public DbSet<BasketItem> BasketItems => Set<BasketItem>();
        public DbSet<Product> Products => Set<Product>();

    }
}
