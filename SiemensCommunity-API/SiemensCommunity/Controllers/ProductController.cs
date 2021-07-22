using Microsoft.AspNetCore.Http;
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
        private readonly UserAdapter _userAdapter = new UserAdapter();
        private readonly AddProductAdapter _addProductAdapter = new AddProductAdapter();
        private readonly UpdateProductAdapter _updateProductAdapter = new UpdateProductAdapter();

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
                    return StatusCode((int) HttpStatusCode.InternalServerError);
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

        [HttpDelete]
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

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var productList = await _productService.GetAsync();
            return Ok(productList);
        }

    }
}
