using MSK.AbySalto.OMP.Core.DTO;
using MSK.AbySalto.OMP.Core.Interfaces;

namespace MSK.AbySalto.OMP.Core.Services
{
    public class ProductsService(IRepository repository)
    {
        public IAsyncEnumerable<ProductDTO> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            return repository.Products.Select(x =>
                new ProductDTO
                {
                    Id = x.Id,
                    Image = x.Image,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price
                })
                .ToAsyncEnumerable();
        }
    }
}
