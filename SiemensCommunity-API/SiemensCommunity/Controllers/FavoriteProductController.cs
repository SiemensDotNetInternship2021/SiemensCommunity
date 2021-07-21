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
    public class FavoriteProductController : ControllerBase
    {
        private readonly IFavoriteProductService _favoriteProductService;

        private readonly FavoriteProductAdapter _favoriteProductAdapter = new FavoriteProductAdapter();

        public FavoriteProductController(IFavoriteProductService productService)
        {
            _favoriteProductService = productService;
        }

        [HttpGet("favoriteProductDetails")]
        public async Task<IActionResult> GetFavoriteProducts(int userId, int selectedCategory, int selectedOption)
        {
            var favoriteProducts = await _favoriteProductService.GetAsync(userId, selectedCategory, selectedOption);
            return Ok(favoriteProducts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite([FromBody] FavoriteProduct productDetails)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedProduct = await _favoriteProductService.AddAsync(_favoriteProductAdapter.Adapt(productDetails));
                return Ok(returnedProduct);
            }
        }

        [HttpPost]
        [Route("DeleteFavoriteProduct")]
        public async Task<IActionResult> Delete(FavoriteProduct productDetails)
        {
            var product = await _favoriteProductService.DeleteAsync(_favoriteProductAdapter.Adapt(productDetails));

            if (product != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return NotFound(productDetails);
            }
        }

    }
}
