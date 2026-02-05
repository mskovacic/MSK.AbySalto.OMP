using Microsoft.EntityFrameworkCore;
using MSK.AbySalto.OMP.Core.DTO;
using MSK.AbySalto.OMP.Core.Entities;
using MSK.AbySalto.OMP.Core.Interfaces;

namespace MSK.AbySalto.OMP.Core.Services
{
    public class BasketService(IRepository repository)
    {
        public async Task<BasketDTO?> GetBasketAsync(string userId, long basketId, CancellationToken cancellationToken = default)
        {
            var basket = await repository.Baskets.Include("Items.Product").AsNoTracking().FirstOrDefaultAsync(b => b.Id == basketId && b.BuyerId == userId, cancellationToken);
            if (basket is null)
            {
                return null;
            }

            var dto = new BasketDTO
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = (basket.Items ?? []).Select(item =>
                    new BasketItemDTO
                    {
                        Id = item.Id,
                        Quantity = item.Quantity,
                        Product = new ProductDTO
                        {
                            Id = item.Product.Id,
                            Name = item.Product.Name,
                            Description = item.Product.Description,
                            Price = item.Product.Price,
                            Image = item.Product.Image
                        },
                        TotalPrice = item.UnitDiscount > item.Product.Price ? 0 : item.Quantity * (item.Product.Price - item.UnitDiscount),
                        UnitDiscount = item.UnitDiscount
                    }).ToArray()
            };
            return dto;
        }

        public async Task<bool> DeleteAsync(string userId, long basketId)
        {
            var basket = await repository.Baskets.FirstOrDefaultAsync(b => b.Id == basketId && b.BuyerId == userId);
            if (basket is null)
            {
                return false;
            }

            await repository.RemoveAsync(basket);
            return true;
        }

        public async Task<BasketDTO> CreateAsync(string userId, CancellationToken cancellationToken = default)
        {
            var basket = new Entities.Basket
            {
                BuyerId = userId
            };
            await repository.AddAsync(basket, cancellationToken: cancellationToken);
            return new BasketDTO
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = []
            };
        }

        public async Task<BasketItemDTO> AddBasketItemAsync(string userId, long basketId, int quantity, long productId, CancellationToken cancellationToken = default)
        {
            var basket = await repository.Baskets.AsNoTracking().FirstOrDefaultAsync(b => b.Id == basketId && b.BuyerId == userId, cancellationToken);
            if (basket is null)
            {
                throw new ArgumentException("Invalid basketId", nameof(basketId));
            }

            var product = await repository.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
            if (product is null)
            {
                throw new ArgumentException("Invalid productId", nameof(productId));
            }

            var basketItem = new BasketItem
            {
                BasketId = basket.Id,
                ProductId = product.Id,
                Quantity = quantity,
                UnitDiscount = 0
            };
            await repository.AddAsync(basketItem, cancellationToken: cancellationToken);

            return new BasketItemDTO
            {
                Id = basketItem.Id,
                Product = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Image
                },
                Quantity = quantity,
                UnitDiscount = 0,
                TotalPrice = quantity * product.Price
            };
        }

        public async Task<bool> RemoveBasketItemAsync(string userId, long basketId, long basketItemId, CancellationToken cancellationToken = default)
        {
            var basket = await repository.Baskets.AsNoTracking().FirstOrDefaultAsync(b => b.Id == basketId && b.BuyerId == userId, cancellationToken);
            if (basket is null)
            {
                return false;
            }
            var basketItem = basket.Items?.FirstOrDefault(i => i.Id == basketItemId);
            if (basketItem is null)
            {
                return false;
            }
            await repository.RemoveAsync(basketItem, cancellationToken: cancellationToken);
            return true;
        }

        public async Task<bool> UpdateBasketQuantityAsync(string userId, long basketId, long basketItemId, int quantity, CancellationToken cancellationToken = default)
        {
            var basket = await repository.Baskets.AsNoTracking().FirstOrDefaultAsync(b => b.Id == basketId && b.BuyerId == userId, cancellationToken);
            if (basket is null)
            {
                return false;
            }
            var basketItem = basket.Items?.FirstOrDefault(i => i.Id == basketItemId);
            if (basketItem is null)
            {
                return false;
            }

            if (quantity <= 0)
            {
                await repository.RemoveAsync(basketItem, cancellationToken: cancellationToken);
                return true;
            }

            basketItem.Quantity = quantity;
            await repository.UpdateAsync(basketItem, cancellationToken: cancellationToken);
            return true;
        }
    }
}
