using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Adapters;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController: ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly PropertyAdapter _propertyAdapter = new PropertyAdapter();

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("getCategoryProperties")]
        public async Task<IActionResult> GetCategoryProperties(int categoryId)
        {
            var properties = await _propertyService.GetCategoryProperties(categoryId);
            return Ok(properties);
        }
    }
}
