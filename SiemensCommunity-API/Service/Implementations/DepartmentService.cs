using Data.Contracts;
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

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            var returnedDepartments = await _departmentRepository.GetAsync();
            return _departmentAdapter.AdaptList(returnedDepartments);
        }
    }
}
