using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Adapters;
using SiemensCommunity.Models;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowedProductController : Controller
    {
        private readonly IBorrowedProductService _borrowedProductService;
        private readonly BorrowedProductAdapter _borrowedProductAdapter = new BorrowedProductAdapter();

        public BorrowedProductController(IBorrowedProductService borrowedProductService)
        {
            _borrowedProductService = borrowedProductService;
        }

        [HttpGet("getBorrowedProducts")]
        public async Task<IActionResult> Get(int userId)
        {
            var borrowedProductList = await _borrowedProductService.GetBorrowedByUserIdAsync(userId);
            return Ok(borrowedProductList);
        }

        [HttpGet("getBorrowedProductsByCategory")]
        public async Task<IActionResult> GetBorrowedProductsByCategory(int userId, int categoryId)
        {
            var borrowedProductList = await _borrowedProductService.GetByCategoryIdAsync(userId, categoryId);
            return Ok(borrowedProductList);
        }

        [HttpPost("borrowProduct")]
        public async Task<IActionResult> BorrowProduct(BorrowedProduct borrowProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var borrowedProduct = await _borrowedProductService.BorrowProduct(_borrowedProductAdapter.Adapt(borrowProduct));

            return Ok(borrowedProduct);

        }

        [HttpPost("returnBorrowedProduct")]
        public async Task<IActionResult> ReturnBorrowProduct(BorrowedProduct borrowedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var returnedProduct = await _borrowedProductService.ReturnBorrowedProduct(_borrowedProductAdapter.Adapt(borrowedProduct));

            return Ok(returnedProduct);
        }
    }
}
