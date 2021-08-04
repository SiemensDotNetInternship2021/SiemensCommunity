using AutoMapper;
using SiemensCommunity.Models;
using System.Collections.Generic;

namespace SiemensCommunity.Adapters
{
    public class DepartmentAdapter
    {
        private readonly IMapper _departmentAdapter;

        public DepartmentAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Department, Service.Models.Department>();
                config.CreateMap<Service.Models.Department, Department>();
            });

            _departmentAdapter = config.CreateMapper();
        }

        public Service.Models.Department Adapt(Department department)
        {
            return _departmentAdapter.Map<Department, Service.Models.Department>(department);
        }

        public Department Adapt(Service.Models.Department department)
        {
            return _departmentAdapter.Map<Service.Models.Department, Department>(department);
        }

        public IEnumerable<Department> AdaptList(IEnumerable<Service.Models.Department> departments)
        {
            return _departmentAdapter.Map<IEnumerable<Service.Models.Department>, IEnumerable<Department>>(departments);
        }
    }
}
