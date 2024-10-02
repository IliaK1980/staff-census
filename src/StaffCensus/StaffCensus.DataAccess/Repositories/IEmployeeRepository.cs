using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess.Repositories;

public interface IEmployeeRepository
{
    IQueryable<EmployeeEntity> GetAll();
    Task<EmployeeEntity?> GetAsync(int id);
    Task AddAsync(EmployeeEntity employee);
    Task UpdateAsync(EmployeeEntity employee);
    Task DeleteAsync(int id);
}