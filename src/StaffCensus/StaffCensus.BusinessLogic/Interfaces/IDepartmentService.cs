using StaffCensus.BusinessLogic.Models;

namespace StaffCensus.BusinessLogic.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
}