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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavoriteProducts([FromRoute] int userId)
        {
            var favoriteProducts = await _favoriteProductService.GetAsync(userId);
            return Ok(favoriteProducts);
        }

        [HttpPost] 
        public async Task<IActionResult> AddToFavorite([FromBody] FavoriteProduct product)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedProduct = await _favoriteProductService.AddAsync(_favoriteProductAdapter.Adapt(product));
                return Ok(returnedProduct);
            }
        }

    }
}
