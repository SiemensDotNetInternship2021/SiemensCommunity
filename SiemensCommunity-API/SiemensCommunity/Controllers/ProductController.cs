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
        private readonly IAccountService _accountService;

        private readonly ProductAdapter _productAdapter = new ProductAdapter();
        private readonly UserAdapter _userAdapter = new UserAdapter();

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
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
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
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

        [HttpGet("{selectedValue}")]
        public async Task<IActionResult> Get([FromRoute] int selectedValue)
        {
            var products = await _productService.GetProducts(selectedValue);
            return Ok(products);
        }

    }
}
