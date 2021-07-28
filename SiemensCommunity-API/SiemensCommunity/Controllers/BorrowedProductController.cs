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

        [HttpGet("getBorrowedProducts")]
        public async Task<IActionResult> Get()
        {
            var borrowedProductList = await _borrowedProductService.GetAsync();
            return Ok(borrowedProductList);
        }

        [HttpGet("getBorrowedProductsByCategory")]
        public async Task<IActionResult> GetBorrowedProductsByCategory(int categoryId)
        {
            var borrowedProductList = await _borrowedProductService.GetByCategoryIdAsync(categoryId);
            return Ok(borrowedProductList);
        }
    }
}
