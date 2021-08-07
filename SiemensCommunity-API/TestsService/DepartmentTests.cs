using Data.Contracts;
using Microsoft.Extensions.Logging;
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
        //subject of test
        private DepartmentService departmentService;

        private Mock<IDepartmentService> departmentServiceMock;
        private Mock<IDepartmentRepository> departmentRepositoryMock = new Mock<IDepartmentRepository>();
        Mock<ILoggerFactory> _loggerFactory;
        Mock<ILogger> mockLogger = new Mock<ILogger>();

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

            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));
            _loggerFactory = new Mock<ILoggerFactory>();
            _loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);

            departmentService = new DepartmentService(departmentRepositoryMock.Object, _loggerFactory.Object);
        }

        [Test]
        public async Task GetDepartments_ShouldReturnListOfDepartments()
        {
            departmentRepositoryMock.Setup(c => c.GetAsync()).Returns(Task.FromResult(dataDepartment.AsEnumerable()));

            var result = await departmentService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<Department>>(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetDepartments_ShouldReturnEmptyListOfDepartments()
        {
            departmentRepositoryMock.Setup(c => c.GetAsync()).Returns(Task.FromResult(new List<Data.Models.Department>().AsEnumerable()));

            var result = await departmentService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<Department>>(result);
            Assert.IsEmpty(result);
        }
    }
}
