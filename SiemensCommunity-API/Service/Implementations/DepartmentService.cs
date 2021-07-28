using Common;
using Data.Contracts;
using Microsoft.Extensions.Logging;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentAdapter _departmentAdapter = new DepartmentAdapter();
        private readonly ILogger _logger;

        public DepartmentService(IDepartmentRepository departmentRepository, ILoggerFactory logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger.CreateLogger("DepartmentService");
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            var returnedDepartments = await _departmentRepository.GetAsync();
            _logger.LogInformation(MyLogEvents.ListItems, "Getting list of departments, {count} found.", returnedDepartments.Count());
            return _departmentAdapter.AdaptList(returnedDepartments);
        }
    }
}
