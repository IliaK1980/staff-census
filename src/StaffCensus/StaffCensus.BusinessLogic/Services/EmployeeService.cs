using Microsoft.EntityFrameworkCore;
using StaffCensus.BusinessLogic.Interfaces;
using StaffCensus.BusinessLogic.Models;
using StaffCensus.DataAccess.Entities;
using StaffCensus.DataAccess.Repositories;

namespace StaffCensus.BusinessLogic.Services;

public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
{
    public async Task<IEnumerable<EmployeeShort>> GetAllEmployeesAsync(string searchTerm)
    {
        var employees = await repository.GetAll()
            .Where(x => string.IsNullOrWhiteSpace(searchTerm) || x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm))
            .Select(x => new EmployeeShort
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Gender = x.Gender,
                Department = x.Department.Name,
            })
            .ToListAsync();

        return employees;
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        var employee = await repository.GetAsync(id);

        return new Employee
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Age = employee.Age,
            Gender = employee.Gender,
            DepartmentId = employee.DepartmentId,
            ProgrammingLanguages = employee.WorkExperiences.Select(x => x.ProgrammingLanguageId).ToList()
        };
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await repository.AddAsync(new EmployeeEntity
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Age = employee.Age,
            Gender = employee.Gender,
            DepartmentId = employee.DepartmentId,
            WorkExperiences = employee.ProgrammingLanguages.Select(x => new WorkExperienceEntity
            {
                ProgrammingLanguageId = x
            }).ToList()
        });
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await repository.UpdateAsync(new EmployeeEntity
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Age = employee.Age,
            Gender = employee.Gender,
            DepartmentId = employee.DepartmentId,
            WorkExperiences = employee.ProgrammingLanguages.Select(x => new WorkExperienceEntity
            {
                EmployeeId = employee.Id,
                ProgrammingLanguageId = x
            }).ToList()
        });
    }

    public async Task SoftDeleteEmployeeAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}