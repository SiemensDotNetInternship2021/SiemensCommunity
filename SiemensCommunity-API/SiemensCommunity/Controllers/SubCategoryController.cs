using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController: ControllerBase
    {
        private readonly ISubCategoryService _subcategoryService;

        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetSubCategories()
        {
            var subcategories = await _subcategoryService.GetAsync();
            return Ok(subcategories);
        }
    }
}
