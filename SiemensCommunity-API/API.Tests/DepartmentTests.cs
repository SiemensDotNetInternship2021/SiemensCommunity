using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using SiemensCommunity.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Tests
{
    public class DepartmentTests
    {
        private Mock<DepartmentController> departmentControllerMock;
        private Mock<IDepartmentService> departmentServiceMock;
        DepartmentController departementController;

        private List<Service.Models.Department> dataDepartements = new List<Service.Models.Department>{
            new Service.Models.Department (){Id = 1, Name = "Department 1"},
            new Service.Models.Department (){Id = 2, Name = "Department 2"},
            new Service.Models.Department (){Id = 3, Name = "Department 3"}
        };

        [SetUp]
        public void SetUp()
        {
            departmentServiceMock = new Mock<IDepartmentService>(MockBehavior.Strict);
            departmentControllerMock = new Mock<DepartmentController>();
            departementController = new DepartmentController(departmentServiceMock.Object);
        }

        [Test]
        public async Task GetDepartments_ShouldReturnListOfDepartements()
        {
            departmentServiceMock.Setup(p => p.GetAsync()).Returns(Task.FromResult(dataDepartements.AsEnumerable()));

            var result = await departementController.GetDepartments();

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
