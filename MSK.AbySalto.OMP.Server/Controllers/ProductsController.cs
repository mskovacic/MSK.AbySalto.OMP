using Microsoft.AspNetCore.Mvc;
using MSK.AbySalto.OMP.Core.Services;

namespace MSK.AbySalto.OMP.Server.Controllers
{
    [ApiController]
    public class ProductsController(ProductsService service) : Controller
    {
        [HttpGet("products")]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            service.GetProductsAsync(cancellationToken);
            return Ok("ok");
        }
    }
}
