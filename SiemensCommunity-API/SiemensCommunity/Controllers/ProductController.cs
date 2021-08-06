using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Adapters;
using SiemensCommunity.Models;
using System.Net;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly ProductAdapter _productAdapter = new ProductAdapter();
        private readonly UserAdapter _userAdapter = new UserAdapter();
        private readonly AddProductAdapter _addProductAdapter = new AddProductAdapter();
        private readonly UpdateProductAdapter _updateProductAdapter = new UpdateProductAdapter();
        private readonly TokenDetailsAdapter _optionDetailsDTOAdapter = new TokenDetailsAdapter();

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm]AddProduct addProduct)
        {

            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedProduct = await _productService.AddAsync(_addProductAdapter.Adapt(addProduct));
                if (returnedProduct != null)
                {
                    return Ok(_productAdapter.Adapt(returnedProduct));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] UpdateProductDTO addProduct)
        {


            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedProduct = await _productService.UpdateAsync(_updateProductAdapter.Adapt(addProduct));
                if (returnedProduct != null)
                {
                    return Ok(_productAdapter.Adapt(returnedProduct));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpGet("getproduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteByIdAsync(id);

            if (success)
            {
                return Ok(id);
            }
            else
            {
                return NotFound(id);
            }
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAsync();
            return Ok(products);
        }


        [HttpGet("optionDetails")]
        public async Task<IActionResult> Get(int selectedCategory, int selectedOption)
        {
           var filtredProducts = await _productService.GetFiltredProducts(selectedCategory, selectedOption);
           return Ok(filtredProducts);
        }

        [HttpGet("getUserProducts")]
        public async Task<IActionResult> GetUserProducts(int userId, int? categoryId)
        {
            var products = await _productService.GetUserProductsAsync(userId, categoryId);
            return Ok(products);
        }


        [HttpGet("getUserAvailableProducts")]
        public async Task<IActionResult> GetUserAvailableProducts(int userId, int? categoryId)
        {
            var products = await _productService.GetUserAvailableProductsAsync(userId, categoryId);
            return Ok(products);
        }

        [HttpGet("getUserLendProducts")]
        public async Task<IActionResult> GetUserLentedProducts(int userId, int? categoryId)
        {
            var products = await _productService.GetUserLendProductsAsync(userId, categoryId);
            return Ok(products);
        }
    }
}
