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
    public class ProductRatingController : ControllerBase
    {
        private readonly IProductRatingService _productRatingService;

        private readonly ProductRatingAdapter _productRatingAdapter = new ProductRatingAdapter();

        public ProductRatingController(IProductRatingService productRatingService)
        {
            _productRatingService = productRatingService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRating product)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedProduct = await _productRatingService.AddWithCheck(_productRatingAdapter.Adapt(product));
                if (returnedProduct != null)
                {
                    return Ok(_productRatingAdapter.Adapt(returnedProduct));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}
