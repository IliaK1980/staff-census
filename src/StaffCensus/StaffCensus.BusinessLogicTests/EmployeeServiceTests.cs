using Moq;
using StaffCensus.BusinessLogic.Interfaces;
using StaffCensus.BusinessLogic.Models;
using StaffCensus.BusinessLogic.Services;
using StaffCensus.BusinessLogicTests.Helpers;
using StaffCensus.DataAccess.Entities;
using StaffCensus.DataAccess.Repositories;

namespace StaffCensus.BusinessLogicTests;

public class EmployeeServiceTests
{
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
    private readonly IEmployeeService _employeeService;

    public EmployeeServiceTests()
    {
        // Set up the mock repository
        _employeeRepositoryMock = new Mock<IEmployeeRepository>();

        // Inject the mock repository into the service
        _employeeService = new EmployeeService(_employeeRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees_WhenNoSearchTermProvided()
    {
        // Arrange
        var employees = new List<EmployeeEntity>
        {
            new EmployeeEntity
            {
                Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male",
                Department = new DepartmentEntity { Name = "IT" }
            },
            new EmployeeEntity
            {
                Id = 2, FirstName = "Jane", LastName = "Smith", Age = 25, Gender = "Female",
                Department = new DepartmentEntity { Name = "HR" }
            }
        };
        
        var asyncEmployees = new TestAsyncEnumerable<EmployeeEntity>(employees);
        
        _employeeRepositoryMock
            .Setup(repo => repo.GetAll())
            .Returns(asyncEmployees);

        // Act
        var result = await _employeeService.GetAllEmployeesAsync(null);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, e => e.FirstName == "John");
        Assert.Contains(result, e => e.FirstName == "Jane");
    }

    [Fact]
    public async Task GetAllEmployeesAsync_ShouldFilterEmployees_WhenSearchTermProvided()
    {
        // Arrange
        var employees = new List<EmployeeEntity>
        {
            new EmployeeEntity { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Department = new DepartmentEntity { Name = "IT" } },
            new EmployeeEntity { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 25, Gender = "Female", Department = new DepartmentEntity { Name = "HR" } }
        }.AsQueryable();

        var asyncEmployees = new TestAsyncEnumerable<EmployeeEntity>(employees);

        _employeeRepositoryMock
            .Setup(repo => repo.GetAll())
            .Returns(asyncEmployees);

        // Act
        var result = await _employeeService.GetAllEmployeesAsync("John");

        // Assert
        Assert.Single(result);
        Assert.Equal("John", result.First().FirstName);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_ShouldReturnEmployee_WhenEmployeeExists()
    {
        // Arrange
        var employeeEntity = new EmployeeEntity
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Gender = "Male",
            DepartmentId = 1,
            WorkExperiences = new List<WorkExperienceEntity>
            {
                new WorkExperienceEntity { ProgrammingLanguageId = 1 }
            }
        };

        _employeeRepositoryMock
            .Setup(repo => repo.GetAsync(1))
            .ReturnsAsync(employeeEntity);

        // Act
        var result = await _employeeService.GetEmployeeByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("John", result.FirstName);
        Assert.Single(result.ProgrammingLanguages);
    }

    [Fact]
    public async Task AddEmployeeAsync_ShouldAddEmployee_WhenValidEmployeeProvided()
    {
        // Arrange
        var employee = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Gender = "Male",
            DepartmentId = 1,
            ProgrammingLanguages = new List<int> { 1, 2 }
        };

        // Act
        await _employeeService.AddEmployeeAsync(employee);

        // Assert
        _employeeRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<EmployeeEntity>()), Times.Once);
    }

    [Fact]
    public async Task UpdateEmployeeAsync_ShouldUpdateEmployee_WhenEmployeeExists()
    {
        // Arrange
        var employee = new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Gender = "Male",
            DepartmentId = 1,
            ProgrammingLanguages = new List<int> { 1, 2 }
        };

        // Act
        await _employeeService.UpdateEmployeeAsync(employee);

        // Assert
        _employeeRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<EmployeeEntity>(e => e.Id == 1)), Times.Once);
    }

    [Fact]
    public async Task SoftDeleteEmployeeAsync_ShouldCallDeleteAsync_WhenEmployeeExists()
    {
        // Arrange
        int employeeId = 1;

        // Act
        await _employeeService.SoftDeleteEmployeeAsync(employeeId);

        // Assert
        _employeeRepositoryMock.Verify(repo => repo.DeleteAsync(employeeId), Times.Once);
    }
}