using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Adapters;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly DepartmentAdapter _userAdapter = new DepartmentAdapter();

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetAsync();
            return Ok(departments);
        }
    }
}
