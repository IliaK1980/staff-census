using StaffCensus.BusinessLogic.Interfaces;
using StaffCensus.BusinessLogic.Models;
using StaffCensus.DataAccess.Repositories;

namespace StaffCensus.BusinessLogic.Services;

public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
{
    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return (await repository.GetAllAsync()).Select(x => new Department { Id = x.Id, Name = x.Name });
    }
}