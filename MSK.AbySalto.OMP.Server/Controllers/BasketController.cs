using Microsoft.AspNetCore.Mvc;
using MSK.AbySalto.OMP.Core.Services;

namespace MSK.AbySalto.OMP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController(BasketService service) : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBasketAsync(CancellationToken cancellationToken)
        {
            var basket = await service.CreateAsync("", cancellationToken);
            return Created((string?)null, basket);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBasketAsync(long basketId, CancellationToken cancellationToken)
        {
            var basket = service.GetBasketAsync("", basketId, cancellationToken);
            return Ok(basket);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBasketAsync(long basketId, CancellationToken cancellationToken)
        {
            var result = await service.DeleteAsync("", basketId);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("{basketId}/item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItemToBasketAsync(long basketId, int quantity, long productId, CancellationToken cancellationToken)
        {
            var basketItem = await service.AddBasketItemAsync("", basketId, quantity, productId, cancellationToken);
            return Ok(basketItem);
        }

        [HttpDelete("{basketId}/item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveItemFromBasketAsync(long basketId, long baskeItemId, CancellationToken cancellationToken)
        {
            var result = await service.RemoveBasketItemAsync("", basketId, baskeItemId, cancellationToken);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{basketId}/item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemQuantityAsync(long basketId, long baskeItemId, int quantity, CancellationToken cancellationToken)
        {
            var basketItem = await service.UpdateBasketQuantityAsync("", basketId, baskeItemId, quantity, cancellationToken);
            return Ok(basketItem);
        }
    }
}
