using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowedProductController : Controller
    {
        private readonly IBorrowedProductService _borrowedProductService;

        public BorrowedProductController(IBorrowedProductService borrowedProductService)
        {
            _borrowedProductService = borrowedProductService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var borrowedProductList = await _borrowedProductService.GetAsync();
            return Ok(borrowedProductList);
        }
    }
}
