using Data.Models;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryAdapter _categoryAdapter = new CategoryAdapter();


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedCategory = await _categoryService.AddAsync(_categoryAdapter.Adapt(category));
                if (returnedCategory != null)
                {
                    return Ok(_categoryAdapter.Adapt(returnedCategory));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> Get()
        {
            var categoriesList = await _categoryService.GetAsync();
            return Ok(categoriesList);
        }
    }
}
