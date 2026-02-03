using MSK.AbySalto.OMP.Core.DTO;
using MSK.AbySalto.OMP.Core.Interfaces;

namespace MSK.AbySalto.OMP.Core.Services
{
    public class BasketService(IRepository repository)
    {
        public async Task<BasketDTO?> GetBasketAsync(string userId, long basketId, CancellationToken cancellationToken = default)
        {
            var basket = await repository.Baskets.FirstOrDefaultAsync(b => b.Id == basketId, cancellationToken);
            if (basket is null)
            {
                return null;
            }

            return new BasketDTO
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item =>
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
        }

        public async Task<bool> DeleteAsync(string userId, long basketId)
        {
            var basket = await repository.Baskets.FirstOrDefaultAsync(b => b.Id == basketId);
            if (basket is null)
            {
                return false;
            }

            await repository.RemoveAsync(basket);
            return true;
        }
    }
}
