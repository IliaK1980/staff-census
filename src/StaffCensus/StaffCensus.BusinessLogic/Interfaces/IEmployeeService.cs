using StaffCensus.BusinessLogic.Models;

namespace StaffCensus.BusinessLogic.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeShort>> GetAllEmployeesAsync(string searchTerm);
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task SoftDeleteEmployeeAsync(int id);
}