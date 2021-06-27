using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Adapters;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedProduct = await _productService.AddAsync(_productAdapter.Adapt(product));
                if (returnedProduct != null)
                {
                    return Ok(_productAdapter.Adapt(returnedProduct));
                }
                else
                {
                    return StatusCode((int) HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productList = await _productService.GetAsync();
            return Ok(productList);
        }
    }
}
