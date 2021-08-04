using AutoMapper;
using Service.Models;
using System.Collections.Generic;

namespace Service.Adapters
{
    public class DepartmentAdapter
    {
        private readonly IMapper _departmentAdapter;

        public DepartmentAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Department, Data.Models.Department>();
                config.CreateMap<Data.Models.Department, Department>();
            });

            _departmentAdapter = config.CreateMapper();
        }

        public Data.Models.Department Adapt(Department department)
        {
            return _departmentAdapter.Map<Department, Data.Models.Department>(department);
        }

        public Department Adapt(Data.Models.Department department)
        {
            return _departmentAdapter.Map<Data.Models.Department, Department>(department);
        }

        public IEnumerable<Department> AdaptList(IEnumerable<Data.Models.Department> departments)
        {
            return _departmentAdapter.Map<IEnumerable<Data.Models.Department>, IEnumerable<Department>>(departments);
        }
    }
}
