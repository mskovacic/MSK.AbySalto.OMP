using Microsoft.AspNetCore.Mvc;
using MSK.AbySalto.OMP.Core.Services;

namespace MSK.AbySalto.OMP.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(ProductsService service) : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var products = service.GetProductsAsync(cancellationToken);
            return Ok(products);
        }
    }
}
