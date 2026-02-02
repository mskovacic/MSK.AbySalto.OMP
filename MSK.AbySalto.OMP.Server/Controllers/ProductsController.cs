using Microsoft.AspNetCore.Mvc;

namespace MSK.AbySalto.OMP.Server.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : Controller
    {
        [HttpGet("/")]
        public IActionResult Get()
        {
            return View();
        }
    }
}
