using Data.Contracts;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using Service.Implementations;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    public class DepartmentTests
    {
        private DepartmentService departmentService;
        private Mock<IDepartmentService> departmentServiceMock;
        private Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
        private List<Data.Models.Department> dataDepartment = new List<Data.Models.Department> {
            new Data.Models.Department { Id = 1, Name = "department 1" },
            new Data.Models.Department {Id =2, Name = "department 2"}
        };

        private List<Department> departments = new List<Department> {
            new Department { Id = 1, Name = "department 1" },
            new Department {Id =2, Name = "department 2"}
        };

        [SetUp]
        public void SetUp()
        {
            departmentServiceMock = new Mock<IDepartmentService>(MockBehavior.Strict);
            departmentService = new DepartmentService(departmentRepository.Object);
        }

        [Test]
        public async Task GetDepartments_ShouldReturnListOfDepartments()
        {
            departmentRepository.Setup(c => c.GetAsync()).Returns(Task.FromResult(dataDepartment.AsEnumerable()));
            departmentServiceMock.Setup(p => p.GetAsync()).Returns(Task.FromResult(departments.AsEnumerable()));

            var result = await departmentService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<Department>>(result);
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
